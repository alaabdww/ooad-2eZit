using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKaartspel
{
    internal class Deck
    {
        private static Random rnd = new Random();

        // properties
        public List<Kaart> Kaarten { get; }

        // constructors
        public Deck()
        {
            Kaarten = new List<Kaart>();

            string[] kleuren = { "C", "S", "H", "D" };

            foreach (string kleur in kleuren)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Kaart kaart = new Kaart(i, kleur); 
                    Kaarten.Add(kaart);
                }
            }
        }

        // methodes
        public void Schudden()
        {
            for (int i = Kaarten.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1); // random index tussen 0 en i
                Kaart temp = Kaarten[i];   
                Kaarten[i] = Kaarten[j];
                Kaarten[j] = temp;
            }
        }

        public Kaart NeemKaart()
        {
            if (Kaarten.Count == 0)
                throw new InvalidOperationException("Geen kaarten meer");
            int laatsteKaart = Kaarten.Count - 1;
            Kaart kaart = Kaarten[laatsteKaart];
            Kaarten.Remove(kaart);
            return kaart;
            
        }
    }
}

