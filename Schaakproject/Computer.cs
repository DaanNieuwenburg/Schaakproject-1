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
            _vorigschaakstuk = _spel.selected.vakje.schaakstuk;
            bepaalMensPositie();
            bepaalMensTactiekEnAntwoord();
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
        }

        private void bepaalMensTactiekEnAntwoord()
        {
            // "French defense"
            if (_positieWest == 5 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("FRENCH DEFENSE");
                _tegenstanderstactiek = "French defense";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.pbox;                     // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.pbox;                               // geselecteerd vak
                voerZetUit();
            }

            // "Dutch defense"
            else if (_positieWest == 4 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("DUTCH DEFENSE");
                _tegenstanderstactiek = "Dutch defense";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.pbox;   // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurOost.buurOost.pbox;                       // geselecteerd vak
                voerZetUit();
            }

            // "Anderssen's Opening"
            else if(_positieWest == 1 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Anderssen's Opening");
                _tegenstanderstactiek = "Anderssen's opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost.pbox;     // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.buurOost.buurOost.buurOost.buurOost.pbox;               // geselecteerd vak
                voerZetUit();
            }

            // "English Opening"
            else if (_positieWest == 3 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("English Opening");
                _tegenstanderstactiek = "English Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.pbox;   // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurOost.buurOost.pbox;             // geselecteerd vak
                voerZetUit();
            }

            // "Larsens Opening"
            else if(_positieWest == 2 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Larsens Opening");
                _tegenstanderstactiek = "Larsens Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurOost.buurOost.buurOost.pbox;   // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.buurOost.pbox;             // geselecteerd vak
                voerZetUit();
            }

            // "Birds Opening"
            else if (_positieWest == 6 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Birds Opening");
                _tegenstanderstactiek = "Birds Opening";
                selected = _spel.selected.vakje.buurWest.buurWest.buurNoord.buurNoord.buurNoord.pbox;   // geselecteerd stuk
                pictures = _spel.selected.vakje.buurWest.buurWest.buurNoord.pbox;                       // geselecteerd vak
                voerZetUit();
            }

            // "Sokolsky Opening"
            else if (_positieWest == 2 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Sokolsky Opening");
                _tegenstanderstactiek = "Sokolsky Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.pbox;   // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurOost.buurOost.pbox;                       // geselecteerd vak
                voerZetUit();
            }

            // "Hungarian Opening"
            else if (_positieWest == 7 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Hungarian Opening");
                _tegenstanderstactiek = "Hungarian Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurWest.buurWest.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurWest.buurWest.buurWest.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Ware Opening"
            else if(_positieWest == 1 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Ware Opening");
                _tegenstanderstactiek = "Ware Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.buurOost.buurOost.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurOost.buurOost.buurOost.buurOost.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Clemenz Opening"
            else if (_positieWest == 8 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Clemenz Opening");
                _tegenstanderstactiek = "Clemenz Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurWest.buurWest.buurWest.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurWest.buurWest.buurWest.buurWest.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Desprez Opening"
            else if (_positieWest == 8 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Desprez Opening");
                _tegenstanderstactiek = "Desprez Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurWest.buurWest.buurWest.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurWest.buurWest.buurWest.buurWest.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Grob Attack"
            else if (_positieWest == 7 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Grob Attack");
                _tegenstanderstactiek = "Grob Attack";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurWest.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurWest.buurWest.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Barnes Opening"
            else if (_positieWest == 6 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Barnes Opening");
                _tegenstanderstactiek = "Barnes Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurWest.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Van 't kruijs Opening"
            else if (_positieWest == 5 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Van 't kruijs Opening");
                _tegenstanderstactiek = "Van 't kruijs Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Mieses Opening"
            else if (_positieWest == 4 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Mieses Opening");
                _tegenstanderstactiek = "Mieses Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurOost.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurOost.pbox;                        // geselecteerd vak
                voerZetUit();
            }

            // "Saragossa Opening"
            else if (_positieWest == 3 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Saragossa Opening");
                _tegenstanderstactiek = "Saragossa Opening";
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.pbox;                        // geselecteerd vak
                voerZetUit();
            }
        }

        private void voerZetUit()
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

