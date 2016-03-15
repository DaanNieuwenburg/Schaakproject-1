using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Computer : Speler
    {
        private Vakje _vorigvakje { get; set; }
        private Schaakstuk _vorigschaakstuk { get; set; }
        private Mens _tegenspeler { get; set; }
        private Spel _spel { get; set; }
        private SpecialPB selected { get; set; }
        private SpecialPB pictures { get; set; }
        private string _tegenstanderstactiek { get; set; }
        private string _schaakstuk { get; set; }
        private int _positieZuid { get; set; }
        private int _positieWest { get; set; }

        public Computer(string naam, string kleur)
        {
            Naam = naam;
            Kleur = kleur;
        }

        public void Zet(SpecialPB _pictures, Spel spel, Mens tegenspeler)
        {
            _spel = spel;
            _vorigvakje = _spel.selected.vakje;
            selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.pbox;
            selected.BackColor = System.Drawing.Color.DarkRed;
            pictures = _spel.selected.vakje.buurNoord.buurNoord.pbox;
            pictures.BackColor = System.Drawing.Color.Firebrick;
            _vorigschaakstuk = _spel.selected.vakje.schaakstuk;
            bepaalMensSchaakStuk();
            bepaalMensPositie();
            bepaalTegenstandersTactiek();
            bepaalReactie();
        }


        private void bepaalMensSchaakStuk()
        {
            // Kijk welk schaakstuk door mens verplaatst is
            if (_vorigschaakstuk is Pion)
            {
                _schaakstuk = "pion";
            }
            else if (_vorigschaakstuk is Paard)
            {
                _schaakstuk = "paard";
            }
            else if (_vorigschaakstuk is Toren)
            {
                _schaakstuk = "toren";
            }
            else if (_vorigschaakstuk is Loper)
            {
                _schaakstuk = "loper";
            }
            else if (_vorigschaakstuk is Dame)
            {
                _schaakstuk = "dame";
            }
            else if (_vorigschaakstuk is Koning)
            {
                _schaakstuk = "koningq";
            }
        }

        private void bepaalMensPositie()
        {
            // kijk naar welke positie de mens zijn schaakstuk heeft verplaats
            bool buurzuid = false;
            int zuidteller = 0;
            _vorigvakje = _spel.selected.vakje;
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
                    _positieZuid = zuidteller;
                    buurzuid = true;
                }
            }

            bool buurnoord = false;
            int noordteller = 0;
            _vorigvakje = _spel.selected.vakje; // reset vakje
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

            bool buurwest = false;
            int westteller = 0;
            _vorigvakje = _spel.selected.vakje; // reset vakje
            while (buurwest == false)
            {
                if (buurwest == false && _vorigvakje != null)
                {
                    _vorigvakje = _vorigvakje.buurWest;
                    westteller++;
                    Console.WriteLine(westteller);
                }
                else
                {
                    buurwest = true;
                    _positieWest = westteller;
                }
            }

            bool buuroost = false;
            int oostteller = 0;
            _vorigvakje = _spel.selected.vakje; // reset vakje
            while (buuroost == false)
            {
                if (buuroost == false && _vorigvakje != null)
                {
                    _vorigvakje = _vorigvakje.buurOost;
                    oostteller++;
                    Console.WriteLine(oostteller);
                }
                else
                {
                    buuroost = true;
                }
            }
            Console.WriteLine("Zuidbuur " + zuidteller);
            Console.WriteLine("Noordbuur " + noordteller);
            Console.WriteLine("Westbuur " + westteller);
            Console.WriteLine("Oostbuur " + oostteller);
        }

        private void bepaalTegenstandersTactiek()
        {
            // "French defense"
            if (_positieWest == 5 && _positieZuid == 4 && _schaakstuk == "pion")
            {
                Console.WriteLine("WE HEBBEN TE MAKEN MET EEN FRENCH DEFENSE");
                _tegenstanderstactiek = "French defense";
            }
        }


        private void bepaalReactie()
        {
            if (_tegenstanderstactiek == "French defense")
            {
                Console.WriteLine("AAMVAL");
                voerZetUit("French defense");
            }
        }


        private void voerZetUit(string aanval)
        {
            if (aanval == "French defense")
            {
                Mens hierhoortgeenmens = new Mens("ikhoorhierniet", "zwart");
                selected.vakje.schaakstuk.Verplaats(pictures, selected, hierhoortgeenmens);
                selected.vakje.update();
                pictures.vakje.update();
                selected = null;
                _spel.VeranderSpeler();
            }
        }
    }
}

