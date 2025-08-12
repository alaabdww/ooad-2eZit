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

        }
        static void Main(string[] args)
        {
        }
    }
}
