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
        private SpecialPB koning { get; set; }
        private string _tegenstanderstactiek { get; set; }
        private int _ronde { get; set; }
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
            bepaalKoningPositie();
            bepaalRondeEnAntwoord();
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

        private void bepaalKoningPositie()
        {
            // kijk waar de koning staat
            bool koningGevonden = false;
            Vakje vorigvakjeHorizontaalOost = _spel.selected.vakje;
            Vakje vorigvakjeHorizontaalWest = _spel.selected.vakje;
            Vakje vorigvakjeVerticaal = _spel.selected.vakje;

            // Loop tot de koning gevonden is
            while (koningGevonden == false)
            {
                //VorigvakjeVerticaal loopt naar boven toe
                if (vorigvakjeVerticaal != null)
                {
                    //VorigvakjeHorizontaal loopt naar het oosten (rechts) toe
                    while(vorigvakjeHorizontaalOost != null)
                    {
                        if(vorigvakjeHorizontaalOost.schaakstuk is Koning)
                        {
                            koningGevonden = true;
                            koning = vorigvakjeHorizontaalOost.pbox;
                            vorigvakjeHorizontaalOost = null;
                        }
                        else
                        {
                            vorigvakjeHorizontaalOost = vorigvakjeHorizontaalOost.buurOost;
                        }
                    }

                    //VorigvakjeHorizontaal loopt naar het westen (links) toe
                    while (vorigvakjeHorizontaalWest != null)
                    {
                        if (vorigvakjeHorizontaalWest.schaakstuk is Koning)
                        {
                            koningGevonden = true;
                            koning = vorigvakjeHorizontaalWest.pbox;
                            vorigvakjeHorizontaalWest = null;
                        }
                        else
                        {
                            vorigvakjeHorizontaalWest = vorigvakjeHorizontaalWest.buurWest;
                        }
                    }
                    vorigvakjeVerticaal = vorigvakjeVerticaal.buurNoord;
                    vorigvakjeHorizontaalOost = vorigvakjeVerticaal.buurNoord;
                    vorigvakjeHorizontaalWest = vorigvakjeVerticaal.buurNoord;
                }
            }  
        }

        private void bepaalRondeEnAntwoord()
        {
            if (_ronde == 0)
            {
                TactiekEnAntwoordR0();
                _ronde++;
            }
            else if (_ronde == 1)
            {
                TactiekEnAntwoordR1();
                _ronde++;
            }
        }
        private void TactiekEnAntwoordR0()
        {
            // Mogelijke openingszetten voor pionnen
            // "French defense"
            if (_positieWest == 5 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("FRENCH DEFENSE");
                _tegenstanderstactiek = "French defense";
                selected = koning.vakje.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Dutch defense"
            else if (_positieWest == 4 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("DUTCH DEFENSE");
                _tegenstanderstactiek = "Dutch defense";
                selected = koning.vakje.buurOost.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurOost.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Anderssen's Opening"
            else if (_positieWest == 1 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Anderssen's Opening");
                _tegenstanderstactiek = "Anderssen's opening";
                selected = koning.vakje.buurOost.buurOost.buurZuid.pbox;                // geselecteerd stuk
                pictures = koning.vakje.buurOost.buurOost.buurZuid.buurZuid.pbox;       // geselecteerd vak
                voerZetUit();
            }

            // "English Opening"
            else if (_positieWest == 3 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("English Opening");
                _tegenstanderstactiek = "English Opening";
                selected = koning.vakje.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Larsens Opening"
            else if (_positieWest == 2 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Larsens Opening");
                _tegenstanderstactiek = "Larsens Opening";
                selected = koning.vakje.buurZuid.pbox;          // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.pbox; // geselecteerd vak
                voerZetUit();
            }

            // "Birds Opening"
            else if (_positieWest == 6 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Birds Opening");
                _tegenstanderstactiek = "Birds Opening";
                selected = koning.vakje.buurWest.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurWest.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Sokolsky Opening"
            else if (_positieWest == 2 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Sokolsky Opening");
                _tegenstanderstactiek = "Sokolsky Opening";
                selected = koning.vakje.buurWest.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurWest.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Hungarian Opening"
            else if (_positieWest == 7 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Hungarian Opening");
                _tegenstanderstactiek = "Hungarian Opening";
                selected = koning.vakje.buurWest.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurWest.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Ware Opening"
            else if (_positieWest == 1 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Ware Opening");
                _tegenstanderstactiek = "Ware Opening";
                selected = koning.vakje.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Clemenz Opening"
            else if (_positieWest == 8 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Clemenz Opening");
                _tegenstanderstactiek = "Clemenz Opening";
                selected = koning.vakje.buurWest.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurWest.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Desprez Opening"
            else if (_positieWest == 8 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Desprez Opening");
                _tegenstanderstactiek = "Desprez Opening";
                selected = koning.vakje.buurWest.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurWest.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Grob Attack"
            else if (_positieWest == 7 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Grob Attack");
                _tegenstanderstactiek = "Grob Attack";
                selected = koning.vakje.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Barnes Opening"
            else if (_positieWest == 6 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Barnes Opening");
                _tegenstanderstactiek = "Barnes Opening";
                selected = koning.vakje.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Van 't kruijs Opening"
            else if (_positieWest == 5 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("Van 't kruijs Opening");
                _tegenstanderstactiek = "Van 't kruijs Opening";
                selected = koning.vakje.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Mieses Opening"
            else if (_positieWest == 4 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                _tegenstanderstactiek = "Mieses Opening";
                selected = koning.vakje.buurZuid.pbox;                      // geselecteerd stuk
                pictures = koning.vakje.buurZuid.buurZuid.buurZuid.pbox;    // geselecteerd vak
                voerZetUit();
            }

            // "Saragossa Opening"
            else if (_positieWest == 3 && _positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                _tegenstanderstactiek = "Saragossa Opening";
                selected = koning.vakje.buurWest.buurWest.buurZuid.pbox;            // geselecteerd stuk
                pictures = koning.vakje.buurWest.buurWest.buurZuid.buurZuid.buurZuid.pbox;   // geselecteerd vak
                voerZetUit();
            }
        }

        private void TactiekEnAntwoordR1()
        {
            if (_tegenstanderstactiek == "French defense")
            {
                if (_positieWest == 4 && _positieZuid == 4)
                {
                    selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.pbox;     // geselecteerd stuk
                    pictures = _spel.selected.vakje.buurNoord.pbox;                         // geselecteerd vak
                    voerZetUit();
                }
                else if (_positieWest == 5 && _positieZuid == 5)
                {
                    selected = _spel.selected.vakje.buurNoord.buurNoord.buurWest.pbox;      // geselecteerd stuk
                    pictures = _spel.selected.vakje.buurWest.pbox;                          // geselecteerd vak
                    voerZetUit();
                }
                else
                {
                    AlgoritmeR1();
                }
            }
            else
            {
                AlgoritmeR1();
            }
        }

        private void AlgoritmeR1()
        {
            // kijk of speler defensief flankt links met Pion
            if (_positieWest <= 3 && _positieZuid >= 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("DEFENSIEF FLANK LINKS");
            }
            else if (_positieWest >= 6 && _positieZuid >= 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("DEFENSIEF FLANK RECHTS");
            }


            // Bepaal positie van koning
            /*bool positiegevonden = false;
            while (positiegevonden == false)
            {
                bool buurwest = false;
                _vorigvakje = _spel.selected.vakje; // reset vakje

               for(int tellerZ = _positieZuid; tellerZ < 8; tellerZ++)
                {
                    _vorigvakje = _vorigvakje.buurZuid;
                    for (int tellerW = _positieWest; tellerW < 8; tellerW++)
                    {
                        _vorigvakje = _vorigvakje.buurWest;
                    }
                }

                if (_spel.selected.vakje.schaakstuk.kleur == "wit" && _spel.selected.vakje.schaakstuk is Koning)
                {
                    positiegevonden = true;
                }
                else
                {
                    //_spel.selected.vakje.buurWest;
                }
            }*/


            // Dit is lelijk :(
            else if (_positieZuid == 3 && _positieWest == 1 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurOost.buurOost.buurOost.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.buurOost.pbox;              // geselecteerd vak
                voerZetUit();
            }
            else if (_positieZuid == 3 && _positieWest == 2 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurOost.buurOost.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.buurOost.pbox;              // geselecteerd vak
                voerZetUit();
            }
            else if (_positieZuid == 3 && _positieWest == 3 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurOost.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurOost.pbox;              // geselecteerd vak
                voerZetUit();
            }
            else if (_positieZuid == 3 && _positieWest == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.pbox;              // geselecteerd vak
                voerZetUit();
            }
            else if (_positieZuid == 3 && _positieWest == 5 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurWest.pbox;              // geselecteerd vak
                voerZetUit();
            }
            else if (_positieZuid == 3 && _positieWest == 6 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurWest.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurWest.buurWest.pbox;              // geselecteerd vak
                voerZetUit();
            }
            else if (_positieZuid == 3 && _positieWest == 7 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurWest.buurWest.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurWest.buurWest.buurWest.pbox;              // geselecteerd vak
                voerZetUit();
            }
            else if (_positieZuid == 3 && _positieWest == 8 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("BEETJE LELIJK");
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.buurWest.buurWest.buurWest.buurWest.pbox;    // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurWest.buurWest.buurWest.buurWest.pbox;              // geselecteerd vak
                voerZetUit();
            }

            // Paard midden spel
            else if (_positieWest == 3 || _positieWest == 6 && _vorigschaakstuk is Paard)
            {
                selected = _spel.selected.vakje.buurNoord.buurNoord.buurNoord.buurNoord.pbox;      // geselecteerd stuk
                pictures = _spel.selected.vakje.buurNoord.buurNoord.pbox;                          // geselecteerd vak
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

