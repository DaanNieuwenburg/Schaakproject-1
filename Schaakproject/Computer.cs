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
                selected = Koning.vakje.buurOost.buurZuid;             // geselecteerd stuk
                pictures = Koning.vakje.buurOost.buurZuid.buurZuid;    // geselecteerd vak
                selected.pbox.BackColor = System.Drawing.Color.Black;
                pictures.pbox.BackColor = System.Drawing.Color.Black;
                voerZetUit();
            }
            else
            {
                Console.WriteLine("ER IS GEEN OPENINGSZET, GA NAAR HET ALGORITME");
                Algoritme();
            }
        }

        private void Algoritme()
        {
            // Dit wordt het algemene algoritme
            // Foreach kan niet gebruikt worden om door twee lijsten te loopen, daarom for loop

            // Creert een percentage van 25% / 75% voor het verplaatsen van stukken bij geen slaan mogelijkheden
            Random rnd = new Random();
            //int percentage = rnd.Next(1, 4);
            int percentage = 1;

            // Bij slaanmogelijkheden
            if (slaanmogelijkheden.Count > 0)
            {
                Console.WriteLine("SLA EEN STUK");
                slaEenStuk();
            }

            // Verplaats een verplaatst stuk


            // Bij geen mogelijkheden verplaats een nieuw stuk
            else if (percentage == 1)
            {
                verplaatsNieuwStuk();
            }

            // Verplaats een eerder verplaatst stuk
            else if (percentage == 2 || percentage == 3)
            {
                //verplaatsVerplaatstStuk();
            }
        }

        private void slaEenStuk()
        {
            Console.WriteLine("SLAANMOGELIJKHEDEN");
            for (int i = 0; i < slaanmogelijkheden.Count; i++)
            {
                Schaakstuk schaakstuk = slaanmogelijkheden[i].schaakstuk;
                slaanmogelijkheden[i].pbox.BackColor = System.Drawing.Color.Black;
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

        private void verplaatsNieuwStuk()
        {
            Random rnd = new Random();
            // Verdeelt het speelbord in 5 stukken d.m.v. random getal
            int randomgetal = rnd.Next(1, 6);

            // Linkerkantbord
            if (randomgetal == 1)
            {
                Console.WriteLine("A");
                int randomstuk = rnd.Next(1, 4);
                if (randomstuk == 1 && Koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && Koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.schaakstuk != null)
                {
                    selected = Koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid;                // geselecteerd stuk
                    Console.WriteLine("A1");
                    pictures = Koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 2 && Koning.vakje.buurWest.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && Koning.vakje.buurWest.buurWest.buurWest.buurZuid != null)
                {
                    selected = Koning.vakje.buurWest.buurWest.buurWest.buurZuid;                // geselecteerd stuk
                    Console.WriteLine("A2");
                    pictures = Koning.vakje.buurWest.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 3 && Koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && Koning.vakje.buurWest.buurWest.buurWest != null)
                {
                    selected = Koning.vakje.buurWest.buurWest.buurWest;                                   // geselecteerd stuk
                    Console.WriteLine("A3");
                    pictures = Koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    voerZetUit();
                }
                else
                {
                    Console.WriteLine("ALGO + " + randomstuk);
                    Algoritme();
                }
            }

            // Linksmiddenbord
            else if (randomgetal == 2)
            {
                Console.WriteLine("B");
                int randomstuk = rnd.Next(1, 3);
                if (randomstuk == 1 && Koning.vakje.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurWest.buurWest.buurWest;                // geselecteerd stuk
                    Console.WriteLine("B1");
                    pictures = Koning.vakje.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 2 && Koning.vakje.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurWest.buurWest.buurZuid;                // geselecteerd stuk
                    Console.WriteLine("B2");
                    pictures = Koning.vakje.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    voerZetUit();
                }
                else
                {
                    Console.WriteLine("ALGO + " + randomstuk);
                    Algoritme();
                }
            }

            // Midden
            else if (randomgetal == 3)
            {
                Console.WriteLine("C");
                int randomstuk = rnd.Next(1, 3);
                if (randomstuk == 1 && Koning.vakje.buurWest.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurWest.buurZuid;          // geselecteerd stuk
                    pictures = Koning.vakje.buurWest.buurZuid.buurZuid; // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 2 && Koning.vakje.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurZuid;           // geselecteerd stuk
                    pictures = Koning.vakje.buurZuid.buurZuid;  // geselecteerd vak
                    voerZetUit();
                }
                else
                {
                    Console.WriteLine("ALGO + " + randomstuk);
                    Algoritme();
                }
            }

            // Rechtsmiddenbord
            else if (randomgetal == 4)
            {
                Console.WriteLine("D");
                int randomstuk = rnd.Next(1, 3);
                if (randomstuk == 1 && Koning.vakje.buurOost.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurOost;                   // geselecteerd stuk
                    Console.WriteLine("D1");
                    pictures = Koning.vakje.buurOost.buurZuid.buurZuid; // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 2 && Koning.vakje.buurOost.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurOost.buurOost;                // geselecteerd stuk
                    Console.WriteLine("D2");
                    pictures = Koning.vakje.buurOost.buurZuid.buurZuid;      // geselecteerd vak
                    voerZetUit();
                }
                else
                {
                    Console.WriteLine("ALGO + " + randomstuk);
                    Algoritme();
                }
            }

            // Rechterkantbord
            else if (randomgetal == 5)
            {
                Console.WriteLine("E");
                int randomstuk = rnd.Next(1, 4);
                if (randomstuk == 1 && Koning.vakje.buurOost.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurOost.buurZuid;                // geselecteerd stuk
                    Console.WriteLine("E1");
                    pictures = Koning.vakje.buurOost.buurZuid.buurZuid;      // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 2 && Koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurOost.buurOost.buurOost.buurZuid;            // geselecteerd stuk
                    Console.WriteLine("E2");
                    pictures = Koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid;   // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 3 && Koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurOost.buurOost;                              // geselecteerd stuk
                    Console.WriteLine("E3");
                    pictures = Koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid;   // geselecteerd vak
                    voerZetUit();
                }
                else if (randomstuk == 4 && Koning.vakje.buurOost.buurOost.buurZuid.buurZuid.schaakstuk == null)
                {
                    selected = Koning.vakje.buurOost.buurOost.buurZuid;             // geselecteerd stuk
                    Console.WriteLine("E4");
                    pictures = Koning.vakje.buurOost.buurOost.buurZuid.buurZuid;    // geselecteerd vak
                    voerZetUit();
                }
                else
                {
                    Console.WriteLine("ALGO + " + randomstuk);
                    Algoritme();
                }
            }
        }

        private void verplaatsVerplaatstStuk()
        {
            bool verplaats = false;
            int teller = 0;
            while (verplaats == false)
            {
                teller++;

                // Dit stukje kijkt of er de teller niet of range gaat, dit gebeurd als bij alle mogelijke computerzetten de computer aangevallen kan worden
                if (teller == verplaatsingsLijst.Count)
                {
                    verplaatsNieuwStuk();
                }

                Vakje vak = verplaatsingsLijst[teller];
                if (vak.schaakstuk is Pion && vak.schaakstuk.kleur == "zwart")
                {
                    Schaakstuk buurvakje1;
                    Schaakstuk buurvakje2;
                    // if else voorkomt dat er naar niet bestaande vakjes wordt gekeken
                    if (vak.buurZuid.buurZuidoost.schaakstuk == null)
                    {
                        buurvakje1 = null;
                    }
                    else
                    {
                        buurvakje1 = vak.buurZuid.buurZuidoost.schaakstuk;
                    }

                    if (vak.buurZuid.buurZuidwest.schaakstuk == null)
                    {
                        buurvakje2 = null;
                    }
                    else
                    {
                        buurvakje2 = vak.buurZuid.buurZuidwest.schaakstuk;
                    }

                    verplaats = BijVerplaatsingSlaan(buurvakje1, buurvakje2, null, null, null, null, null, null);
                    if (verplaats == true)
                    {
                        selected = vak;                // geselecteerd stuk
                        pictures = vak.buurZuid;      // geselecteerd vak
                        voerZetUit();
                    }
                }
            }
        }

        // Dit is lelijk ja, is bekend
        private bool BijVerplaatsingSlaan(Schaakstuk buurvakje1, Schaakstuk buurvakje2, Schaakstuk buurvakje3, Schaakstuk buurvakje4, Schaakstuk buurvakje5, Schaakstuk buurvakje6, Schaakstuk buurvakje7, Schaakstuk buurvakje8)
        {
            bool verplaatsen = true;
            if (buurvakje1 != null)
            {
                verplaatsen = false;
            }
            else if (buurvakje2 != null)
            {
                verplaatsen = false;
            }
            else if (buurvakje3 != null)
            {
                verplaatsen = false;
            }
            else if (buurvakje4 != null)
            {
                verplaatsen = false;
            }
            else if (buurvakje5 != null)
            {
                verplaatsen = false;
            }
            else if (buurvakje6 != null)
            {
                verplaatsen = false;
            }
            else if (buurvakje7 != null)
            {
                verplaatsen = false;
            }
            else if (buurvakje8 != null)
            {
                verplaatsen = false;
            }
            return verplaatsen;
        }

        private void voerZetUit()
        {
            verplaatsingsLijst.Add(pictures);       // slaat de positie van de computerszet in lijst op 
            Mens hierhoortgeenmens = new Mens("ikhoorhierniet", "zwart", spel);
            hierhoortgeenmens.Koning = Koning;
            hierhoortgeenmens.selected = selected;
            selected.schaakstuk.Verplaats(pictures, selected, hierhoortgeenmens, _spel);
            selected.pbox.update();
            pictures.pbox.update();
            selected = null;
            _spel.VeranderSpeler();
        }
    }
}

