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
        private List<Vakje> _verplaatsingslijst = new List<Vakje>();
        public List<Vakje> verplaatsingsLijst
        {
            get { return _verplaatsingslijst; }
            set { _verplaatsingslijst = value; }
        }

        private List<Vakje> _slaanmogelijkheden = new List<Vakje>();
        public List<Vakje> slaanmogelijkheden
        {
            get { return _slaanmogelijkheden; }
            set { _slaanmogelijkheden = value; }
        }

        private List<Vakje> _slaanmogelijkhedenVanaf = new List<Vakje>();
        public List<Vakje> slaanmogelijkhedenVanaf
        {
            get { return _slaanmogelijkhedenVanaf; }
            set { _slaanmogelijkhedenVanaf = value; }
        }

        private string _tegenstandersopening { get; set; }
        private string _tegenstanderstactiek { get; set; }
        private int _ronde { get; set; }
        private int _positieZuid { get; set; }
        private int _positieWest { get; set; }
        public bool spelerkanslaan { get; set; }
        public bool computerkanslaan { get; set; }
        public Computer(string naam, string kleur)
        {
            Naam = naam;
            Kleur = kleur;
        }

        public void Zet(Vakje _pictures, Spel spel, Mens tegenspeler)
        {
            _spel = spel;
            _vorigvakje = _spel.selected;                   // slaat het door de speler geselecteerde vakje op
            _vorigschaakstuk = _spel.selected.schaakstuk;   // slaat het door de speler geselecteerde schaakstuk op     -- dit moet ook vanuit vorigvakje kunnen, scheelt code?
            verplaatsingsLijst.Add(_spel.selected);     // slaat de positie van de spelerszet in lijst op 
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
                        if (vorigvakjeHorizontaalOost.schaakstuk is Koning && vorigvakjeHorizontaalOost.schaakstuk.kleur == "zwart")
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
                        if (vorigvakjeHorizontaalWest.schaakstuk is Koning && vorigvakjeHorizontaalWest.schaakstuk.kleur == "zwart")
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

        private void controleerOpSlaan()
        {
            // Reset de slaan mogelijkheden
            spelerkanslaan = false;
            computerkanslaan = false;

            // Kijk nu per stuk of er geslagen kan worden door de mens
            foreach (Vakje kleurvakje in verplaatsingsLijst)
            {
                if (kleurvakje.schaakstuk is Pion)
                {
                    kleurvakje.schaakstuk.kanStukSlaan(this, kleurvakje);
                }
                else if (kleurvakje.schaakstuk is Loper)
                {
                    kleurvakje.schaakstuk.kanStukSlaan(this, kleurvakje);
                    Console.WriteLine("Loper kan stuk slaan");
                }
                else if (kleurvakje.schaakstuk is Toren)
                {
                    kleurvakje.schaakstuk.kanStukSlaan(this, kleurvakje);
                }
                else if (kleurvakje.schaakstuk is Paard)
                {
                    kleurvakje.schaakstuk.kanStukSlaan(this, kleurvakje);
                }
                else if (kleurvakje.schaakstuk is Dame)
                {
                    kleurvakje.schaakstuk.kanStukSlaan(this, kleurvakje);
                }
                else if (kleurvakje.schaakstuk is Koning)
                {
                    kleurvakje.schaakstuk.kanStukSlaan(this, kleurvakje);
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
                Algoritme();
                _ronde++;
            }
            else if (_ronde == 2)
            {
                Algoritme();
                _ronde++;
            }
            else
            {
                Algoritme();
                _ronde++;
            }
        }

        private void TactiekEnAntwoordR0()
        {
            // Mogelijke openingszetten voor pionnen
            // "French defense"
            if (_positieWest == 5 && _positieZuid == 4 && _vorigschaakstuk is Pion)
            {
                Console.WriteLine("R0");
                _tegenstandersopening = "French defense";
                _tegenstanderstactiek = "midcontrol";
                selected = koning.buurOost.buurZuid;             // geselecteerd stuk
                pictures = koning.buurOost.buurZuid.buurZuid;    // geselecteerd vak
                voerZetUit();
            }
        }

        private void TactiekEnAntwoordR1()
        {
            Console.WriteLine("R1");
            selected = koning.buurOost;            // geselecteerd stuk
            selected.pbox.BackColor = System.Drawing.Color.Blue;
            pictures = selected.buurZuidwest.buurZuidwest.buurZuidwest;                   // geselecteerd vak
            pictures.pbox.BackColor = System.Drawing.Color.CadetBlue;

            voerZetUit();
        }

        private void Algoritme()
        {
            // Dit wordt het algemene algoritme
            // Foreach kan niet gebruikt worden om door twee lijsten te loopen, daarom for loop

            // Bij slaanmogelijkheden
            if (slaanmogelijkheden.Count >= 0)
            {
                for (int i = 0; i < slaanmogelijkheden.Count; i++)
                {
                    Schaakstuk schaakstuk = slaanmogelijkheden[i].schaakstuk;
                    if (schaakstuk is Koning && schaakstuk.kleur == "wit")
                    {
                        selected = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                        pictures = slaanmogelijkheden[i];       // geselecteerd vak
                        voerZetUit();
                    }
                    else if (schaakstuk is Dame && schaakstuk.kleur == "wit")
                    {
                        selected = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                        pictures = slaanmogelijkheden[i];       // geselecteerd vak
                        voerZetUit();
                    }
                    else if (schaakstuk is Toren || schaakstuk is Paard || schaakstuk is Loper && schaakstuk.kleur == "wit")
                    {
                        selected = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                        pictures = slaanmogelijkheden[i];       // geselecteerd vak
                        voerZetUit();
                    }
                    else if (schaakstuk is Pion && schaakstuk.kleur == "wit")
                    {
                        selected = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                        pictures = slaanmogelijkheden[i];       // geselecteerd vak
                        voerZetUit();
                    }
                }
            }

            // Bij geen mogelijkheden doe iets randoms
            else
            {
                // Verdeelt het speelbord in 5 stukken d.m.v. random getal
                Random rnd = new Random();
                int randomgetal = rnd.Next(1, 5);

                // Linkerkantbord
                if(randomgetal == 1)
                {

                }
                // Linksmiddenbord
                else if(randomgetal == 2)
                {

                }
                // Midden
                else if(randomgetal == 3)
                {

                }
                // Rechtsmiddenbord
                else if (randomgetal == 4)
                {

                }
                // Rechterkantbord
                else if (randomgetal == 5)
                {

                }
            }
        }

        private void voerZetUit()
        {
            verplaatsingsLijst.Add(pictures);       // slaat de positie van de computerszet in lijst op 
            Mens hierhoortgeenmens = new Mens("ikhoorhierniet", "zwart");
            selected.schaakstuk.Verplaats(pictures, selected, hierhoortgeenmens);
            selected.pbox.update();
            pictures.pbox.update();
            selected = null;
            _spel.VeranderSpeler();
        }
    }
}

