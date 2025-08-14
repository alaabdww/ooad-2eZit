using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleComplexiteit
{
    internal class Program
    {

        private static bool IsKlinker(char C)
        {
            if (C == 'a' || C == 'e' || C == 'i' || C == 'o' || C == 'u' || C == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int AantalLettergrepen(string a)
        {
            if (string.IsNullOrEmpty(a))
            {
                return 0;
            }
            a = a.ToLower();
            bool vorigeWasKlinker = false;
            string klinkers = "aeiouy";
            int aantal = 0;

            foreach (char c in a)
            {
                if (klinkers.Contains(c))
                {
                    if (vorigeWasKlinker == false)
                    {
                        aantal++;
                        vorigeWasKlinker = true;
                    }
                    else
                    {
                        vorigeWasKlinker = true;
                    }
                }
                else
                {
                    vorigeWasKlinker = false;
                }
            }

            return aantal;



        }

        private static double Complexiteit(string a)
        {
            a = a.ToLower();
            int lettergrepen = AantalLettergrepen(a);
            int lengte = a.Length;
            double complexiteit = 0;
            int letters = 0;

            foreach (char c in a)
            {
                if (c == 'x' || c == 'y' || c == 'q')
                { letters++; }
            }

            complexiteit = (double)lettergrepen + (double)lengte / 3 + (double)letters;
            complexiteit = Math.Round(complexiteit, 1);
            return complexiteit;

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Geef een woord (enter om te stoppen): ");
                string woord = Console.ReadLine();

                if (string.IsNullOrEmpty(woord))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Bedankt en tot ziens.");
                    break;
                }

                Console.WriteLine($"aantal karakters: {woord.Length}");
                Console.WriteLine($"aantal lettergrepen: {AantalLettergrepen(woord)}");
                Console.WriteLine($"complexiteit: {Complexiteit(woord)}");
                Console.WriteLine("");
            }
        }
    }
}
