using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Computer : Speler
    {
        private Vakje _vorigvakje { get; set; }
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
            bool buurnoord = false;
            int noordteller = 0;
            _vorigvakje = _spel.vorigVakje.vakje.buurNoord;
            while (buurnoord == false)
        {

                if (buurnoord == false && _vorigvakje != null)
                {
                    _vorigvakje = _vorigvakje.buurNoord;
                    noordteller++;
                    Console.WriteLine(noordteller);
                }
                else
                {
                    buurnoord = true;
                }
        }


            bool buurzuid = false;
            int zuidteller = 0;
            _vorigvakje = _spel.vorigVakje.vakje.buurOost; // reset vakje
            while (buurzuid == false)
            {
                if (buurzuid == false && _vorigvakje != null)
                {
                    _vorigvakje = _vorigvakje.buurOost;
                    zuidteller++;
                    Console.WriteLine(zuidteller);
                }
                else
        {
                    buurzuid = true;
                }
            }
            Console.WriteLine("Noordelijke buren" + noordteller);
            Console.WriteLine("Zuidelijke buren" + zuidteller);
        }
    }
}

