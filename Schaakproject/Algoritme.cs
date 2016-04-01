using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaakproject
{
    public class Algoritme
    {
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
        private Computer _computer { get; set; }
        private Schaakstuk _koning { get; set; }
        private Vakje _geselecteerdStuk { get; set; }
        private Vakje _geselecteerdVakje { get; set; }
        private bool _koningVerplaats { get; set; }
        private int _recursieTeller { get; set; }
        private string _slaanRichting { get; set; }
        public bool StaatSchaak { get; set; }
        public Algoritme(Computer computer)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Algoritme()");
            _computer = computer;
            _koning = computer.koning;
            // kijk of er geslagen kan worden
            controleerOpSlaan();
            if (slaanmogelijkheden.Count > 0)
            {
                slaEenStuk();
            }
            else
            {
                Random rnd = new Random();
                //int percentage = 1337;
                int percentage = rnd.Next(1, 4);
                if (percentage == 1 && _koningVerplaats == false)
                {
                    verplaatsNieuwStuk();
                }
                else if (percentage > 1 && computer.VerplaatsingsLijst.Count > 0)
                {
                    verplaatsVerplaatstStuk();
                }
                else if (_koningVerplaats == true)
                {
                    verplaatsVerplaatstStuk();
                }
                else
                {
                    verplaatsNieuwStuk();
                }
            }
        }

        private void controleerOpSlaan()
        {
            // Reset de slaanmogelijkheden
            slaanmogelijkheden.Clear();
            slaanmogelijkhedenVanaf.Clear();
            // Kijk nu per niet verplaatst stuk of er geslagen kan worden
            foreach (Vakje nietverplaatststuk in _computer.NietVerplaatstLijst)
            {
                if (nietverplaatststuk.schaakstuk is Pion)
                {
                    nietverplaatststuk.schaakstuk.kanStukSlaan(this, nietverplaatststuk);
                }
                else if (nietverplaatststuk.schaakstuk is Loper)
                {
                    nietverplaatststuk.schaakstuk.kanStukSlaan(this, nietverplaatststuk);
                }
                else if (nietverplaatststuk.schaakstuk is Toren)
                {
                    nietverplaatststuk.schaakstuk.kanStukSlaan(this, nietverplaatststuk);
                }
                else if (nietverplaatststuk.schaakstuk is Paard)
                {
                    nietverplaatststuk.schaakstuk.kanStukSlaan(this, nietverplaatststuk);
                }
                else if (nietverplaatststuk.schaakstuk is Dame)
                {
                    nietverplaatststuk.schaakstuk.kanStukSlaan(this, nietverplaatststuk);
                }
            }

            // Kijk nu per verplaatst stuk of er geslagen kan worden
            foreach (Vakje verplaatststuk in _computer.VerplaatsingsLijst)
            {
                if (verplaatststuk.schaakstuk is Pion)
                {
                    verplaatststuk.schaakstuk.kanStukSlaan(this, verplaatststuk);
                }
                else if (verplaatststuk.schaakstuk is Loper)
                {
                    verplaatststuk.schaakstuk.kanStukSlaan(this, verplaatststuk);
                }
                else if (verplaatststuk.schaakstuk is Toren)
                {
                    verplaatststuk.schaakstuk.kanStukSlaan(this, verplaatststuk);
                }
                else if (verplaatststuk.schaakstuk is Paard)
                {
                    verplaatststuk.schaakstuk.kanStukSlaan(this, verplaatststuk);
                }
                else if (verplaatststuk.schaakstuk is Dame)
                {
                    verplaatststuk.schaakstuk.kanStukSlaan(this, verplaatststuk);
                }
                else if (verplaatststuk.schaakstuk is Koning)
                {
                    verplaatststuk.schaakstuk.kanStukSlaan(this, verplaatststuk);
                }
            }
        }

        private void slaEenStuk()
        {
            Console.WriteLine("Sla een Stuk");
            bool alGeslagen = false;
            for (int i = 0; i < slaanmogelijkheden.Count; i++)
            {
                Schaakstuk schaakstuk = slaanmogelijkheden[i].schaakstuk;
                if (schaakstuk is Koning && schaakstuk.Kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Pion && schaakstuk.Kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Toren && schaakstuk.Kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Paard && schaakstuk.Kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Loper && schaakstuk.Kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (schaakstuk is Dame && schaakstuk.Kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
            }
        }

        private void verplaatsNieuwStuk()
        {
            Console.WriteLine("Verplaats nieuw Stuk");
            Random rnd = new Random();
            // Verdeelt het speelbord in 5 stukken d.m.v. random getal
            int randomgetal = rnd.Next(1, 6);

            // Linkerkantbord
            if (randomgetal == 1)
            {
                int randomstuk = rnd.Next(1, 4);
                if (randomstuk == 1 && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurWest;                                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else
                {
                    verplaatsVerplaatstStuk();
                }
            }

            // Linksmiddenbord
            else if (randomgetal == 2)
            {
                int randomstuk = rnd.Next(1, 3);
                if (randomstuk == 1 && _koning.Vakje.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurWest;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else
                {
                    verplaatsVerplaatstStuk();
                }
            }

            // Midden
            else if (randomgetal == 3)
            {
                int randomstuk = rnd.Next(1, 3);
                if (randomstuk == 1 && _koning.Vakje.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurZuid;          // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurZuid.BuurZuid; // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurZuid;           // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurZuid.BuurZuid;  // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else
                {
                    verplaatsVerplaatstStuk();
                }
            }

            // Rechtsmiddenbord
            else if (randomgetal == 4)
            {
                int randomstuk = rnd.Next(1, 3);
                if (randomstuk == 1 && _koning.Vakje.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurZuid;                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurZuid.BuurZuid;          // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurOost;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else
                {
                    verplaatsVerplaatstStuk();
                }
            }

            // Rechterkantbord
            else if (randomgetal == 5)
            {
                int randomstuk = rnd.Next(1, 4);
                if (randomstuk == 1 && _koning.Vakje.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid;            // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid;   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurOost;                              // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid;   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 4 && _koning.Vakje.BuurOost.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurOost.BuurZuid;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurOost.BuurZuid.BuurZuid;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else
                {
                    // vangt een eventuele stack overflow af
                    if (_recursieTeller > 100)
                    {
                        voorkomStackOverflow();
                    }
                    else
                    {
                        _recursieTeller++;
                        verplaatsVerplaatstStuk();
                    }
                }
            }
        }
        private void verplaatsVerplaatstStuk()
        {
            int[] nietBestaandeStukken = new int[4];
            Console.WriteLine("Verplaats verplaatst Stuk");
            // Kijk nu per verplaatst stuk of er geslagen kan worden
            bool alVerplaatst = false;
            for (int i = 0; i < _computer.VerplaatsingsLijst.Count; i++)
            {
                _geselecteerdStuk = _computer.VerplaatsingsLijst[i];  // geselecteerd stuk
                Schaakstuk schaakstuk = _computer.VerplaatsingsLijst[i].schaakstuk;

                // Controleert of het stuk nog wel bestaat
                if (schaakstuk != null && schaakstuk.Kleur == "zwart")
                {
                    Console.WriteLine("Bestaat");
                    if (schaakstuk is Pion && alVerplaatst == false)
                    {
                        Console.WriteLine("HIER KOM IK WEL");
                        if (_geselecteerdStuk.BuurZuid != null && _geselecteerdStuk.BuurZuid.schaakstuk == null)
                        {
                            if (_geselecteerdStuk.BuurZuid.BuurZuidOost != null && _geselecteerdStuk.BuurZuid.BuurZuidOost.schaakstuk == null && _geselecteerdStuk.BuurZuid.BuurZuidWest != null && _geselecteerdStuk.BuurZuid.BuurZuidWest.schaakstuk == null)
                            {
                                Console.WriteLine("BuurZuid verplaatst");
                                alVerplaatst = true;
                                _geselecteerdVakje = _computer.VerplaatsingsLijst[i].BuurZuid;       // geselecteerd vak
                                _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                                _geselecteerdStuk.Pbox.BackColor = System.Drawing.Color.Brown;
                                _geselecteerdVakje.Pbox.BackColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
                /*else if (schaakstuk is Paard && alVerplaatst == false)
                {
                    Console.WriteLine("PAARD VERPLAATS");
                    if (_geselecteerdStuk.buurZuid.buurZuidoost != null && _geselecteerdStuk.buurZuid.buurZuidoost.schaakstuk == null)
                    {
                        Console.WriteLine("ZO");
                        alVerplaatst = true;
                        _geselecteerdVakje = _computer.verplaatsingsLijst[i];       // geselecteerd vak
                        _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    }
                    else if (_geselecteerdStuk.buurZuid.buurZuidwest != null && _geselecteerdStuk.buurZuid.buurZuidwest.schaakstuk == null)
                    {
                        Console.WriteLine("ZW");
                        alVerplaatst = true;
                        _geselecteerdVakje = _computer.verplaatsingsLijst[i];       // geselecteerd vak
                        _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    }
                }*/

                // Als er niets verplaatst kan worden, verplaats nieuw stuk
                if (i + 1 == _computer.VerplaatsingsLijst.Count && alVerplaatst == false)
                {
                    Console.WriteLine("Er zijn geen verplaatsingen meer en verplaats nieuw stuk");
                    alVerplaatst = true;
                    // vangt een eventuele stack overflow af
                    if (_recursieTeller > 100)
                    {
                        voorkomStackOverflow();
                    }
                    else
                    {
                        _recursieTeller++;
                        verplaatsNieuwStuk();
                    }
                }
            }
        }

        private void voorkomStackOverflow()
        {
            Console.WriteLine("Voorkom Stack Overflow");
            bool verplaatst = false;
            int teller = 0;
            // voorkom een stack overflow door een domme zet te doen
            while (verplaatst == false)
            {
                teller++;
                Vakje vakje = _computer.VerplaatsingsLijst[teller];
                Schaakstuk schaakstuk = _computer.VerplaatsingsLijst[teller].schaakstuk;
                if (schaakstuk is Pion && vakje.BuurZuid != null && vakje.BuurZuid.schaakstuk == null)
                {
                    _computer.voerZetUit(vakje, vakje.BuurZuid);
                    verplaatst = true;
                }
            }
        }

        public void reageerOpSchaak(Vakje geselecteerd)
        {
            geselecteerd.Pbox.BackColor = System.Drawing.Color.White;
            Console.WriteLine("Reageer op schaak");
            Vakje waarVanDaan = geselecteerd;
            Vakje volgendVakje;
            bool reactie = false;

            // bepaal richting van het slaan
            bool mogelijkloop = false;
            volgendVakje = geselecteerd.BuurNoord;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "Noord";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurNoord;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.BuurNoordoost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "Noordoost";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurNoordoost;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.BuurNoordWest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "Noordwest";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurNoordWest;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.BuurOost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "Oost";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurOost;
                }
            }


            mogelijkloop = false;
            volgendVakje = geselecteerd.BuurZuid;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "Zuid";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurZuid;
                }
            }


            mogelijkloop = false;
            volgendVakje = geselecteerd.BuurZuidOost;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "Zuidoost";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurZuidOost;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.BuurZuidWest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "Zuidwest";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurZuidWest;
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.BuurWest;
            while (mogelijkloop == false)
            {
                if (volgendVakje == null)
                {
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        mogelijkloop = true;
                        _slaanRichting = "West";
                    }
                    else if (volgendVakje.schaakstuk != null && volgendVakje.schaakstuk.Kleur == "wit")
                    {
                        mogelijkloop = true;
                    }
                    volgendVakje = volgendVakje.BuurWest;
                }
            }

            // verplaats schaakstuk naar een leeg vak wanneer mogelijk
            if (reactie == false)
            {
                _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                Console.WriteLine("Reageer op schaak in algoritme");
                Console.WriteLine("Slaanrichting = " + _slaanRichting);
                if (_koning.Vakje.BuurNoord != null && _koning.Vakje.BuurNoord.schaakstuk == null && _slaanRichting != "Noord" && _slaanRichting != "Zuid")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("noord");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurNoord;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else if (_koning.Vakje.BuurNoordoost != null && _koning.Vakje.BuurNoordoost.schaakstuk == null && _slaanRichting != "Noordoost" && _slaanRichting != "Zuidwest")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("noordoost");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurNoordoost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else if (_koning.Vakje.BuurNoordWest != null && _koning.Vakje.BuurNoordWest.schaakstuk == null && _slaanRichting != "Noordwest" && _slaanRichting != "Zuidoost")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("noordwest");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurNoordWest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else if (_koning.Vakje.BuurWest != null && _koning.Vakje.BuurWest.schaakstuk == null && _slaanRichting != "West" && _slaanRichting != "Oost")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("west");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else if (_koning.Vakje.BuurOost != null && _koning.Vakje.BuurOost.schaakstuk == null && _slaanRichting != "Oost" && _slaanRichting != "West")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("oost");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else if (_koning.Vakje.BuurZuid != null && _koning.Vakje.BuurZuid.schaakstuk == null && _slaanRichting != "Zuid" && _slaanRichting != "Noord")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("zuid");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurZuid;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else if (_koning.Vakje.BuurZuidOost != null && _koning.Vakje.BuurZuidOost.schaakstuk == null && _slaanRichting != "Zuidoost" && _slaanRichting != "Noordwest")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("zuidoost");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurZuidOost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else if (_koning.Vakje.BuurZuidWest != null && _koning.Vakje.BuurZuidWest.schaakstuk == null && _slaanRichting != "Zuidwest" && _slaanRichting != "Noordoost")
                {
                    _koningVerplaats = true;
                    Console.WriteLine("zuidwest");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurZuidWest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                    _koning.Vakje.Pbox.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    Console.WriteLine("Kan koning niet verplaatsen");
                    controleerBurenSchaak(_slaanRichting, waarVanDaan);
                }
            }
            else
            {
                Console.WriteLine("Kan koning niet verplaatsen");
                controleerBurenSchaak(_slaanRichting, waarVanDaan);
            }
        }

        private void controleerBurenSchaak(string richting, Vakje waarVanDaan)
        {
            Console.WriteLine("ControleerBurenSchaak");
            string slaRichting = richting;
            Vakje volgendVakje = waarVanDaan;
            bool mogelijkloop = false;
            if (richting == "noord")
            {

                volgendVakje = waarVanDaan.BuurNoord;
            }
            else if (richting == "Noordoost")
            {
                Console.WriteLine("RNO");
                volgendVakje = waarVanDaan.BuurNoordoost;
            }
            else if (richting == "Noordwest")
            {
                Console.WriteLine("RNW");
                volgendVakje = waarVanDaan.BuurNoordWest;
            }
            else if (richting == "West")
            {
                Console.WriteLine("RW");
                volgendVakje = waarVanDaan.BuurWest;
            }
            else if (richting == "Zuid")
            {
                Console.WriteLine("Z");
                volgendVakje = waarVanDaan.BuurZuid;
            }
            else if (richting == "Zuidoost")
            {
                Console.WriteLine("RZO");
                volgendVakje = waarVanDaan.BuurZuidOost;
            }
            else if (richting == "Zuidwest")
            {
                Console.WriteLine("RZO");
                volgendVakje = waarVanDaan.BuurZuidWest;
            }
            else
            {
                Console.WriteLine("RO");
                volgendVakje = waarVanDaan.BuurOost;
            }
            while (mogelijkloop == false)
            {
                Console.WriteLine("Mogelijkloop");
                if (volgendVakje == null)
                {
                    Console.WriteLine("VOLGEND VAKJE IS NULL");
                    mogelijkloop = true;
                }
                else
                {
                    if (volgendVakje != null && volgendVakje.schaakstuk != null && volgendVakje.schaakstuk is Koning && volgendVakje.schaakstuk.Kleur == "zwart")
                    {
                        Console.WriteLine("Niets gevonden");
                        mogelijkloop = true;
                    }
                    else
                    {
                        Console.WriteLine("VERDER DE LOOP IN");
                        if (volgendVakje.BuurNoord != null && volgendVakje.BuurNoord.schaakstuk != null && volgendVakje.BuurNoord.schaakstuk is Pion || volgendVakje.BuurNoord.schaakstuk is Dame || volgendVakje.BuurNoord.schaakstuk is Toren)
                        {
                            if (volgendVakje.BuurNoord.schaakstuk is Pion)
                            {
                                Console.WriteLine("N-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord, volgendVakje);
                                volgendVakje.BuurNoord.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurNoord.schaakstuk is Dame)
                            {
                                Console.WriteLine("N-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord, volgendVakje);
                                volgendVakje.BuurNoord.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurNoord.schaakstuk is Toren)
                            {
                                Console.WriteLine("N-T");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord, volgendVakje);
                                volgendVakje.BuurNoord.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("N+");
                            }
                        }
                        else if (volgendVakje.BuurWest != null && volgendVakje.BuurWest.schaakstuk != null && volgendVakje.BuurWest.schaakstuk is Toren || volgendVakje.BuurWest.schaakstuk is Dame)
                        {
                            if (volgendVakje.BuurWest.schaakstuk is Toren)
                            {
                                Console.WriteLine("W-T");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurWest, volgendVakje);
                                volgendVakje.BuurWest.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurWest.schaakstuk is Dame)
                            {
                                Console.WriteLine("W-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurWest, volgendVakje);
                                volgendVakje.BuurWest.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("W+");
                            }
                        }
                        else if (volgendVakje.BuurZuid != null && volgendVakje.BuurZuid.schaakstuk != null && volgendVakje.BuurZuid.schaakstuk is Toren || volgendVakje.BuurZuid.schaakstuk is Dame)
                        {
                            if (volgendVakje.BuurZuid.schaakstuk is Toren)
                            {
                                Console.WriteLine("Z-T");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuid, volgendVakje);
                                volgendVakje.BuurZuid.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurZuid.schaakstuk is Dame)
                            {
                                Console.WriteLine("Z-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuid, volgendVakje);
                                volgendVakje.BuurZuid.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("Z+");
                            }
                        }
                        else if (volgendVakje.BuurOost != null && volgendVakje.BuurOost.schaakstuk != null && volgendVakje.BuurOost.schaakstuk is Toren || volgendVakje.BuurOost.schaakstuk is Dame)
                        {
                            if (volgendVakje.BuurOost.schaakstuk is Toren)
                            {
                                Console.WriteLine("O-T");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurOost, volgendVakje);
                                volgendVakje.BuurOost.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurOost.schaakstuk is Dame)
                            {
                                Console.WriteLine("O-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurOost, volgendVakje);
                                volgendVakje.BuurOost.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("O+");
                            }
                        }
                        else if (volgendVakje.BuurNoordoost != null && volgendVakje.BuurNoordoost.schaakstuk != null && volgendVakje.BuurNoordoost.schaakstuk is Loper || volgendVakje.BuurNoordoost.schaakstuk is Dame)
                        {
                            if (volgendVakje.BuurNoordoost.schaakstuk is Loper)
                            {
                                Console.WriteLine("NO-L");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordoost, volgendVakje);
                                volgendVakje.BuurNoordoost.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurNoordoost.schaakstuk is Dame)
                            {
                                Console.WriteLine("NO-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordoost, volgendVakje);
                                volgendVakje.BuurNoordoost.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("NO+");
                            }
                        }
                        else if (volgendVakje.BuurNoordWest != null && volgendVakje.BuurNoordWest.schaakstuk != null && volgendVakje.BuurNoordWest.schaakstuk is Loper || volgendVakje.BuurNoordWest.schaakstuk is Dame)
                        {
                            if (volgendVakje.BuurNoordWest.schaakstuk is Loper)
                            {
                                Console.WriteLine("NW-L");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordWest, volgendVakje);
                                volgendVakje.BuurNoordWest.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurNoordWest.schaakstuk is Dame)
                            {
                                Console.WriteLine("NW-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordWest, volgendVakje);
                                volgendVakje.BuurNoordWest.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("NW+");
                            }
                        }
                        else if (volgendVakje.BuurZuidWest != null && volgendVakje.BuurZuidWest.schaakstuk != null && volgendVakje.BuurZuidWest.schaakstuk is Loper || volgendVakje.BuurZuidWest.schaakstuk is Dame)
                        {
                            if (volgendVakje.BuurZuidWest.schaakstuk is Loper)
                            {
                                Console.WriteLine("ZW-L");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidWest, volgendVakje);
                                volgendVakje.BuurZuidWest.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurZuidWest.schaakstuk is Dame)
                            {
                                Console.WriteLine("ZW-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidWest, volgendVakje);
                                volgendVakje.BuurZuidWest.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("ZW+");
                            }
                        }
                        else if (volgendVakje.BuurZuidOost != null && volgendVakje.BuurZuidOost.schaakstuk != null && volgendVakje.BuurZuidOost.schaakstuk is Loper || volgendVakje.BuurZuidOost.schaakstuk is Dame)
                        {
                            if (volgendVakje.BuurZuidOost.schaakstuk is Loper)
                            {
                                Console.WriteLine("ZO-L");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidOost, volgendVakje);
                                volgendVakje.BuurZuidOost.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else if (volgendVakje.BuurZuidOost.schaakstuk is Dame)
                            {
                                Console.WriteLine("ZO-D");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidOost, volgendVakje);
                                volgendVakje.BuurZuidOost.Pbox.BackColor = System.Drawing.Color.DarkCyan;
                            }
                            else
                            {
                                Console.WriteLine("ZO+");
                            }
                        }

                        // Voor de paarden
                        else if (volgendVakje.BuurZuid.BuurZuidOost != null && volgendVakje.BuurZuid.BuurZuidOost.schaakstuk != null)
                        {
                            if (volgendVakje.BuurZuid.BuurZuidOost.schaakstuk is Paard)
                            {
                                Console.WriteLine("ZZO-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuid.BuurZuidOost, volgendVakje);
                            }
                        }
                        else if (volgendVakje.BuurZuid.BuurZuidWest != null && volgendVakje.BuurZuid.BuurZuidWest.schaakstuk != null)
                        {
                            if (volgendVakje.BuurZuid.BuurZuidWest.schaakstuk is Paard)
                            {
                                Console.WriteLine("ZZW-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuid.BuurZuidWest, volgendVakje);
                            }
                        }
                        else if (volgendVakje.BuurNoord.BuurNoordWest != null && volgendVakje.BuurNoord.BuurNoordWest.schaakstuk != null)
                        {
                            if (volgendVakje.BuurNoord.BuurNoordWest.schaakstuk is Paard)
                            {
                                Console.WriteLine("NNW-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord.BuurNoordWest, volgendVakje);
                            }
                        }
                        else if (volgendVakje.BuurNoord.BuurNoordoost != null && volgendVakje.BuurNoord.BuurNoordoost.schaakstuk != null)
                        {
                            if (volgendVakje.BuurNoord.BuurNoordoost.schaakstuk is Paard)
                            {
                                Console.WriteLine("NNO-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord.BuurNoordoost, volgendVakje);
                            }
                        }
                        else if (volgendVakje.BuurWest.BuurNoord != null && volgendVakje.BuurWest.BuurNoord.schaakstuk != null)
                        {
                            if (volgendVakje.BuurWest.BuurNoord.schaakstuk is Paard)
                            {
                                Console.WriteLine("WNO-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurWest.BuurNoord, volgendVakje);
                            }
                        }
                        else if (volgendVakje.BuurWest.BuurZuid != null && volgendVakje.BuurWest.BuurZuid.schaakstuk != null)
                        {
                            if (volgendVakje.BuurWest.BuurZuid.schaakstuk is Paard)
                            {
                                Console.WriteLine("WZO-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurWest.BuurZuid, volgendVakje);
                            }
                        }
                        else if (volgendVakje.BuurOost.BuurNoord != null && volgendVakje.BuurOost.BuurNoord.schaakstuk != null)
                        {
                            if (volgendVakje.BuurOost.BuurNoord.schaakstuk is Paard)
                            {
                                Console.WriteLine("ONO-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurOost.BuurNoord, volgendVakje);
                            }
                        }
                        else if (volgendVakje.BuurOost.BuurZuid != null && volgendVakje.BuurOost.BuurZuid.schaakstuk != null)
                        {
                            if (volgendVakje.BuurOost.BuurZuid.schaakstuk is Paard)
                            {
                                Console.WriteLine("OZO-P");
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurOost.BuurZuid, volgendVakje);
                            }
                        }
                        else
                        {
                            Console.WriteLine("LOOPT");
                            // verder in de richting
                            if(richting == "noord")
                            {
                                volgendVakje = volgendVakje.BuurNoord;
                            }
                            else if (richting == "noordoost")
                            {
                                volgendVakje = volgendVakje.BuurNoordoost;
                            }
                            else if (richting == "noordwest")
                            {
                                volgendVakje = volgendVakje.BuurNoordWest;
                            }
                            else if (richting == "west")
                            {
                                volgendVakje = volgendVakje.BuurWest;
                            }
                            else if (richting == "zuid")
                            {
                                volgendVakje = volgendVakje.BuurZuid;
                            }
                            else if (richting == "zuidoost")
                            {
                                volgendVakje = volgendVakje.BuurZuidOost;
                            }
                            else if (richting == "zuidoost")
                            {
                                volgendVakje = volgendVakje.BuurZuidWest;
                            }
                            else if (richting == "oost")
                            {
                                volgendVakje = volgendVakje.BuurOost;
                            }
                            volgendVakje.Pbox.BackColor = System.Drawing.Color.DarkSeaGreen;
                        }
                    }
                }
            }
            _koningVerplaats = true;
        }
    }
}
