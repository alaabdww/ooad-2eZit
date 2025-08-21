using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAnagram
{
    internal class Program
    {
        static string MaakAnagram(string woord)
        {
            Random rnd = new Random();
            char[] letters = woord.ToCharArray();

            // Fisher–Yates shuffle
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                (letters[i], letters[j]) = (letters[j], letters[i]);
            }

            return new string(letters);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("CONSOLE ANAGRAM");
            Console.WriteLine("===============");
            Console.WriteLine("");
            string[] woorden = File.ReadAllLines(@"Files\1000woorden.txt"); // lees regels bestand in
            Console.Write("Kies het aantal letters (5-15): ");
            int aantalLetters = Convert.ToInt32(Console.ReadLine());

            Random rnd = new Random();
            string[] gefilterd = woorden.Where(w => w.Length == aantalLetters).ToArray();
            string gekozenWoord = gefilterd[rnd.Next(0, gefilterd.Length)];
            string anagram = MaakAnagram(gekozenWoord);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (true) 
            {
                Console.WriteLine($"Anagram: {anagram}");
                Console.Write("Het woord (druk op enter om opnieuw te schudden): ");
                string antwoord = Console.ReadLine();

                if (string.IsNullOrEmpty(antwoord))
                {
                    anagram = MaakAnagram(gekozenWoord);
                    continue;
                }
                if (antwoord == gekozenWoord)
                {
                    sw.Stop();
                    TimeSpan tijd = sw.Elapsed;
                    Console.WriteLine($"Proficiat! Je hebt het juiste woord geraden in {tijd.Minutes}min {tijd.Seconds}sec {tijd.Milliseconds}ms");
                    break;
                }
                else
                {
                    Console.WriteLine("Fout. Probeer opnieuw of druk op enter om opnieuw te schudden");
                }
            }
            

            

            Console.ReadKey();

        }
    }
}
