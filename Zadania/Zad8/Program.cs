/*
 * Proszę przy pomocy klasy Ping (z System.Net.NetworkInformation) sprawdzić dostępność
serwerów zawartych w pliku ping.txt pllik proszę utworzyć plik na podstawie listy poniżej.
Proszę przygotować i zmierzyć czas wykonania zadania realizując je na trzy sposoby:
● Sekwencyjnie.
● Równolegle (max. 4 wątki) za pomocą AsParallel.
● Równolegle (max. 4 wątki) korzystając z mechanizmu Tasków (Dla chętnych na
plusa proszę użyć
https://learn.microsoft.com/en-us/dotnet/api/system.threading.monitor.tryenter?view=
net-8.0#system-threading-monitor-tryenter(system-object-system-timespan))
 */


using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Zad8;

internal class Program
{
    private static int _completedTasks = 0; // Licznik zakończonych zadań
    private static object _lockObject = new(); // Obiekt do zabezpieczenia dostępu do wspólnej zmiennej
    static SemaphoreSlim _semaphore = new SemaphoreSlim(4); // Semafor do kontrolowania liczby równocześnie uruchomionych zadań

    
    private static int _reachableServers = 0; // Licznik dostępnych serwerów
    private static int _unreachableServers = 0; // Licznik niedostępnych serwerów

    private static void Main()
    {
        var filePath = "ping.txt";
        var addresses = ReadFileToArray(filePath);

        Console.WriteLine($"Liczba adresów {addresses.Length}:");
        
        // Sekwencyjne sprawdzenie dostępności serwerów
        MeasureTime(() => PingSequentially(addresses), "Sekwencyjnie");
        
        // Równoległe sprawdzenie dostępności serwerów za pomocą AsParallel
        MeasureTime(() => PingInParallelAsParallel(addresses), "Równolegle (AsParallel)");
        

        // Równoległe sprawdzenie dostępności serwerów za pomocą Task
        MeasureTime(() => PingInParallelWithTasks(addresses), "Równolegle (Task)");
        
        
        

        Console.ReadLine(); 
    }

    static void PingInParallelWithTasks(string[] addresses)
    {
        Task[] tasks = new Task[addresses.Length];

        for (int i = 0; i < addresses.Length; i++)
        {
            int index = i;

            tasks[i] = Task.Run(async () =>
            {
                await _semaphore.WaitAsync(); // Czekaj na dostęp do semafora (maksymalnie 4 jednocześnie)

                try
                {
                    //Console.WriteLine($"Zadanie {Task.CurrentId} rozpoczęło działanie. Liczba zadań w trakcie wykonywania: {_semaphore.CurrentCount + 1}");
                    PingResult result = PingServer(addresses[index]);
                    //Console.WriteLine($"{addresses[index]}: {result}");
                }
                finally
                {
                    _semaphore.Release();
                    //Console.WriteLine($"Zadanie {Task.CurrentId} zakończyło działanie. Liczba zadań w trakcie wykonywania: {_semaphore.CurrentCount}");
                    Interlocked.Increment(ref _completedTasks);
                }
            });
        }

        
        if (Monitor.TryEnter(_lockObject, TimeSpan.FromSeconds(30)))
        {
            try
            {
                
                Task.WaitAll(tasks);
            }
            finally
            {
                
                Monitor.Exit(_lockObject);
            }
        }
        
        SpinWait.SpinUntil(() => Interlocked.CompareExchange(ref _completedTasks, 0, 0) == addresses.Length);
    }

    private static void PingInParallelAsParallel(string[] addresses)
    {
        addresses.AsParallel().WithDegreeOfParallelism(4).ForAll(address =>
        {
            var result = PingServer(address);
            //Console.WriteLine($"{address}: {result}");
        });
    }

    private static void PingSequentially(string[] addresses)
    {
        foreach (var address in addresses)
        {
            var result = PingServer(address);
            //Console.WriteLine($"{address}: {result}");
        }
    }

    private static PingResult PingServer(string address)
    {
        var ping = new Ping();

        try
        {
            var reply = ping.Send(address);
            if (reply.Status == IPStatus.Success)
            {
                _reachableServers++;
                return PingResult.Reachable;
            }
            else
            {
                _unreachableServers++;
                return PingResult.Unreachable;
            }
        }
        catch (Exception)
        {
            return PingResult.Error;
        }
    }
    
    private static void ResetCounters()
    {
        _reachableServers = 0;
        _unreachableServers = 0;
    }
    
    private static void DisplayCounters()
    {
        Console.WriteLine($"Dostępne serwery: {_reachableServers}");
        Console.WriteLine($"Niedostępne serwery: {_unreachableServers}");
    }

    private static string[] ReadFileToArray(string filePath)
    {
        try
        {
            var lines = File.ReadAllLines(filePath);
            return lines.Select(line => line.Trim()).ToArray();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas odczytu pliku: {ex.Message}");
            return new string[0];
        }
    }

    private static void MeasureTime(Action action, string method)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        ResetCounters();
        action();
        DisplayCounters();

        stopwatch.Stop();
        Console.WriteLine($"{method} - Czas wykonania: {stopwatch.Elapsed}");
    }

    private enum PingResult
    {
        Reachable,
        Unreachable,
        Error
    }
}