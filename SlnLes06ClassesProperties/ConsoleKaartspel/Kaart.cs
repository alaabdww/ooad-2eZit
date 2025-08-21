using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel
{
    internal class Kaart
    {
        private int _nummer;
        private string _kleur;

        // properties
        public int Nummer
        {
            get { return _nummer; }
            set
            {
                if (value < 1 || value > 13)
                {
                    throw new ArgumentOutOfRangeException("Nummer moet tussen 1 en 13 zitten");
                }
                _nummer = value;
            }
        }


        public string Kleur
        {
            get { return _kleur; }
            set
            {
                if (value != "C" && value != "H" && value != "S" && value != "D")
                {
                    throw new ArgumentException("Ongeldige kleur");
                }
                _kleur = value;
            }
        }

        // Constructors
        public Kaart() { }

        public Kaart(int nummer)
        {
            Nummer = nummer;
        }

        public Kaart(int nummer, string kleur) : this(nummer)
        {
            Kleur = kleur;
        }
        
    }
}
