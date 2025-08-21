using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel
{
    internal class Speler
    {
        // properties
        private static Random rnd = new Random();
        public string Naam {  get; set; }
        public List<Kaart> Kaarten { get; set; }

        private bool _heeftNogKaarten;
        public bool HeeftNogKaarten
        {
            get
            {
                if (Kaarten.Count <= 0)
                {
                    _heeftNogKaarten = false;
                }
                else
                {
                    _heeftNogKaarten = true;
                }
                return _heeftNogKaarten;
            }
        }

        // Constructors
        public Speler(string nm) 
        { 
            Naam = nm;
            Kaarten = new List<Kaart>();
        }

        public Speler(string nm, List<Kaart> kt) :this(nm)
        {
            Kaarten = kt;
        }

        // Methodes
        public Kaart LegKaart()
        {
            if (Kaarten.Count == 0)
                throw new InvalidOperationException("Geen kaarten meer");
            int indexGekozenKaart = rnd.Next(Kaarten.Count);
            Kaart gekozenKaart = Kaarten[indexGekozenKaart];
            Kaarten.RemoveAt(indexGekozenKaart);
            return gekozenKaart;
        }



        
    }
}
