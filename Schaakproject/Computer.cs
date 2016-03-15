using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Computer : Speler
    {
        private Vakje _vorigvakje { get; set; }
        public SpecialPB selected { get; set; }
        public bool validezet { get; set; }
        private int aggresiviteit { get; set; }
        private Mens _tegenspeler { get; set; }
        private Spel _spel { get; set; }

        public Computer(string naam, string kleur)
        {
            Naam = naam;
            Kleur = kleur;
        }

        public void Zet(Spel spel, Mens tegenspeler)
        {
            _spel = spel;
            if (_spel.vorigVakje.vakje.buurNoord != null)
            {
                Console.WriteLine("buurnoord is niet null");
            }
            else
            {
                Console.WriteLine("HIJ IS GVD NIET NULL");
            }
            Console.WriteLine("TEST");
            bepaalMensZet();
        }


        // Kijk waar de menselijke speler ziin of haar schaakstuk naar toe heeft verplaatst
        private void bepaalMensZet()
        {
            bool buurzuid = false;
            int zuidteller = 0;
            _vorigvakje = _spel.vorigVakje.vakje.buurZuid;
            while (buurzuid == false)
            {
                if (buurzuid == false && _vorigvakje != null)
                {
                    _vorigvakje = _vorigvakje.buurZuid;
                    zuidteller++;
                    Console.WriteLine(zuidteller);
                }
                else
                {
                    buurzuid = true;
                }
            }


            bool buurwest = false;
            int westteller = 0;
            _vorigvakje = _spel.vorigVakje.vakje.buurWest; // reset vakje
            while (buurwest == false)
            {
                if (buurwest == false && _vorigvakje != null)
                {
                    _vorigvakje = _vorigvakje.buurOost;
                    westteller++;
                    Console.WriteLine(westteller);
                }
                else
                {
                    buurwest = true;
                }
            }

            Console.WriteLine("Zuidelijke buren " + zuidteller);
            Console.WriteLine("Noordelijke buren ", 8 - zuidteller);
            Console.WriteLine("Westelijke buren " + westteller);
            Console.WriteLine("Oostelijke buren ", 8 - westteller);
        }

        private void verplaats()
        {
            
        }


    }
}

