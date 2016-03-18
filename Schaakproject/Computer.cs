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
        private Vakje selected { get; set; }
        private Vakje pictures { get; set; }
        private Vakje koning { get; set; }
        private List<Vakje> _verplaatsingslijstMens = new List<Vakje>();
        public List<Vakje> verplaatsingsLijstMens
        {
            get { return _verplaatsingslijstMens; }
            set { _verplaatsingslijstMens = value; }
        }
        private List<Vakje> _verplaatsingsLijstComputer = new List<Vakje>();
        public List<Vakje> verplaatsingsLijstComputer
        {
            get { return _verplaatsingsLijstComputer; }
            set { _verplaatsingsLijstComputer = value; }
        }
        private string _tegenstandersopening { get; set; }
        private string _tegenstanderstactiek { get; set; }
        private int _ronde { get; set; }
        private int _positieZuid { get; set; }
        private int _positieWest { get; set; }

        public Computer(string naam, string kleur)
        {
            Naam = naam;
            Kleur = kleur;
        }

        public void Zet(Vakje _pictures, Spel spel, Mens tegenspeler)
        {
            _spel = spel;
            _vorigvakje = _spel.selected;                     // slaat het door de speler geselecteerde vakje op
            _vorigschaakstuk = _spel.selected.schaakstuk;     // slaat het door de speler geselecteerde schaakstuk op     -- dit moet ook vanuit vorigvakje kunnen, scheelt code?
            verplaatsingsLijstMens.Add(_spel.selected);  // slaat de positie van de spelerszet in lijst op 

            foreach (Vakje kleurvakje in verplaatsingsLijstMens)
            {
                kleurvakje.pbox.BackColor = System.Drawing.Color.AliceBlue;
            }

            foreach (Vakje kleurvakje in verplaatsingsLijstComputer)
            {
                kleurvakje.pbox.BackColor = System.Drawing.Color.Yellow;
            }

            bepaalMensPositie();
            bepaalKoningPositie();
            controleerOpSlaan();
            bepaalRondeEnAntwoord();
        }

        private void bepaalMensPositie()
        {
            // kijk naar welke positie de mens zijn schaakstuk heeft verplaats
            bool buurzuid = false;
            int zuidteller = 0;
            _vorigvakje = _spel.selected;
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
            _vorigvakje = _spel.selected; // reset vakje
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
            Vakje vorigvakjeHorizontaalOost = _spel.selected;
            Vakje vorigvakjeHorizontaalWest = _spel.selected;
            Vakje vorigvakjeVerticaal = _spel.selected;

            // Loop tot de koning gevonden is
            while (koningGevonden == false)
            {
                //VorigvakjeVerticaal loopt naar boven toe
                if (vorigvakjeVerticaal != null)
                {
                    //VorigvakjeHorizontaal loopt naar het oosten (rechts) toe
                    while (vorigvakjeHorizontaalOost != null)
                    {
                        if (vorigvakjeHorizontaalOost.schaakstuk is Koning)
                        {
                            koningGevonden = true;
                            koning = vorigvakjeHorizontaalOost;
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
                            koning = vorigvakjeHorizontaalWest;
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
                if(_vorigvakje != null)
                {
                    TactiekEnAntwoordR0();
                    _ronde++;
                }
                else
                {
                    Console.WriteLine("");
                }
                TactiekEnAntwoordR0();
                _ronde++;
            }
            else if (_ronde == 1)
            {
                TactiekEnAntwoordR1();
                _ronde++;
            }
        }

        private void controleerOpSlaan()
        {

            foreach (Vakje kleurvakje in verplaatsingsLijstComputer)
            {
                if (kleurvakje.schaakstuk is Pion)
                {
                    bool kanslaan = kleurvakje.schaakstuk.kanStukSlaan(kleurvakje);
                    Console.WriteLine("Kan stuk slaan" + kanslaan); 
                }
            }
            // inprincipe moet dit vanuit de schaakstuk klassen maar dat gaat nog niet,
        }

        private void TactiekEnAntwoordR0()
        {
            // Mogelijke openingszetten voor pionnen
            // "French defense"
            if (_positieWest == 5 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("FRENCH DEFENSE");
                _tegenstandersopening = "French defense";
                _tegenstanderstactiek = "midcontrol";
                selected = koning.buurZuid;             // geselecteerd stuk
                pictures = koning.buurZuid.buurZuid;    // geselecteerd vak
                voerZetUit();
            }
        }

        private void TactiekEnAntwoordR1()
        {
            if (_tegenstandersopening == "French defense")
            {
                if (_positieWest == 4 && _positieZuid == 4)
                {
                    selected = koning.buurWest.buurZuid;                      // geselecteerd stuk
                    pictures = koning.buurWest.buurZuid.buurZuid.buurZuid;    // geselecteerd vak
                    voerZetUit();
                }
                else if (_positieWest == 5 && _positieZuid == 5)
                {
                    selected = koning.buurWest.buurZuid;                      // geselecteerd stuk
                    pictures = koning.buurWest.buurZuid.buurZuid.buurZuid;    // geselecteerd vak
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
            // Flank links
            if (_positieWest <= 3 && _positieZuid >= 4 && _vorigschaakstuk is Pion)
            {
                selected = koning.buurWest.buurWest.buurWest;            // geselecteerd stuk
                pictures = koning.buurWest.buurWest.buurZuid.buurZuid;   // geselecteerd vak
                voerZetUit();
            }
            // Flank rechts
            else if (_positieWest >= 6 && _positieZuid >= 4 && _vorigschaakstuk is Pion)
            {
                selected = koning.buurOost.buurOost;                     // geselecteerd stuk
                pictures = koning.buurOost.buurZuid.buurZuid;            // geselecteerd vak
                Console.WriteLine("FLANKR");
                voerZetUit();
            }
            // Defensief op 3de rij
            else if (_positieZuid == 3 && _vorigschaakstuk is Pion)
            {
                selected = koning.buurWest.buurZuid;            // geselecteerd stuk
                pictures = koning.buurWest.buurZuid.buurZuid;   // geselecteerd vak
                voerZetUit();
            }
            // Aanvallend paard vanuit west
            else if (_positieWest == 3 && _vorigschaakstuk is Paard)
            {
                selected = koning.buurWest.buurWest.buurZuid;                    // geselecteerd stuk
                pictures = koning.buurWest.buurWest.buurZuid.buurZuid.buurZuid;  // geselecteerd vak
                voerZetUit();
            }
            // Aanvallend paard vanuit oost
            else if (_positieWest == 6 && _vorigschaakstuk is Paard)
            {
                selected = koning.buurOost.buurZuid;                     // geselecteerd stuk
                pictures = koning.buurOost.buurZuid.buurZuid.buurZuid;   // geselecteerd vak
                voerZetUit();
            }
        }

        private void voerZetUit()
        {
            _verplaatsingsLijstComputer.Add(pictures);       // slaat de positie van de computerszet in lijst op 
            Mens hierhoortgeenmens = new Mens("ikhoorhierniet", "zwart");
            selected.schaakstuk.Verplaats(pictures, selected, hierhoortgeenmens);
            selected.pbox.update();
            pictures.pbox.update();
            selected = null;
            _spel.VeranderSpeler();
        }
    }
}

