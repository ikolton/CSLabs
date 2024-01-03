// ZlecenieKanapka.cs
using System;
using System.Threading;
using Common;

namespace SandwichProcessor
{
    public class ZlecenieKanapka : IZlecenie
    {
        public string Title { get; set; }

        public void Process()
        {
            Console.WriteLine($"Zlecenie Kanapka: {Title}");
            Console.WriteLine("Rozpoczynam przygotowywanie kanapki...");

            // Simulate sandwich making steps with a delay of 1 second
            PrepareIngredients();
            Console.WriteLine("Składniki przygotowane.");

            AssembleSandwich();
            Console.WriteLine("Kanapka złożona.");

            CutAndServe();
            Console.WriteLine("Kanapka pokrojona i gotowa do podania.");
        }

        private void PrepareIngredients()
        {
            Console.WriteLine("Przygotowuję składniki...");
            Thread.Sleep(1000);
        }

        private void AssembleSandwich()
        {
            Console.WriteLine("Składam kanapkę...");
            Thread.Sleep(1000);
        }

        private void CutAndServe()
        {
            Console.WriteLine("Kroję kanapkę i podaję...");
            Thread.Sleep(1000);
        }
    }
}