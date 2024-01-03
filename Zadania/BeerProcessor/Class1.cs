// ZleceniePiwo.cs
using System;
using System.Threading;
using Common;

namespace BeerProcessor
{
    public class ZleceniePiwo : IZlecenie
    {
        public string Title { get; set; }

        public void Process()
        {
            Console.WriteLine($"Zlecenie Piwo: {Title}");
            Console.WriteLine("Rozpoczynam warzenie West Coast IPA...");

            // Simulate beer brewing steps with a delay of 2 seconds
            Mash();
            Console.WriteLine("Zacieranie zakończone.");

            Boil();
            Console.WriteLine("Gotowanie zakończone.");

            Ferment();
            Console.WriteLine("Fermentacja zakończona.");

            Package();
            Console.WriteLine("Rozlew i pakowanie zakończone.");
        }

        private void Mash()
        {
            Console.WriteLine("Rozpoczynam zacieranie...");
            Thread.Sleep(2000);
        }

        private void Boil()
        {
            Console.WriteLine("Rozpoczynam gotowanie...");
            Thread.Sleep(2000);
        }

        private void Ferment()
        {
            Console.WriteLine("Rozpoczynam fermentację...");
            Thread.Sleep(2000);
        }

        private void Package()
        {
            Console.WriteLine("Rozlewam i pakuję piwo...");
            Thread.Sleep(2000);
        }
    }
}