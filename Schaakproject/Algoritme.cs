using System;
using System.Collections.Generic;

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
        private int _recursieTeller { get; set; }
        private string _slaanRichting { get; set; }
        public bool StaatSchaak { get; set; }
        public Algoritme(Computer computer)
        {
            _computer = computer;
            _koning = computer.koning;
            // kijk of er geslagen kan worden
            controleerOpSlaan();
            if (slaanmogelijkheden.Count > 0 && _computer.ZojuistSchaak == false)
            {
                slaEenStuk();
            }
            else if (_computer.ZojuistSchaak == true)
            {
                // Als de koning schaak stond doet de computer 2 beurten, dit voorkomt dat
                _geselecteerdStuk = _koning.Vakje;          // geselecteerd stuk
                _geselecteerdVakje = _koning.Vakje;         // geselecteerd vak
                _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                _computer.ZojuistSchaak = false;
                _computer.spel.VeranderSpeler();
            }
            else
            {
                Random rnd = new Random();
                int percentage = rnd.Next(1, 4);
                if (percentage == 1 && _computer.KoningVerplaats == false)
                {
                    verplaatsNieuwStuk();
                }
                else if (percentage > 1 && computer.VerplaatsingsLijst.Count > 0)
                {
                    verplaatsVerplaatstStuk();
                }
                else if (_computer.KoningVerplaats == true)
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
            // Kijk per niet verplaatst stuk of er geslagen kan worden
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

            // Kijk per verplaatst stuk of er geslagen kan worden
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
            // Slaat een stuk die in de methode controleerOpSlaan in de lijst slaanmogelijkheden lijst gezet is
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
            Random rnd = new Random();
            // Verdeelt het speelbord in 5 stukken d.m.v. random getal
            int randomgetal = rnd.Next(1, 6);

            // Linkerkantbord
            if (randomgetal == 1)
            {
                int randomstuk = rnd.Next(1, 4);
                if (randomstuk == 1 && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest != null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid != null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurWest.BuurWest.BuurWest != null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid != null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest != null && _koning.Vakje.BuurWest.BuurWest.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest != null && _koning.Vakje.BuurWest.BuurWest.BuurWest.schaakstuk != null)
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
                if (randomstuk == 1 && _koning.Vakje.BuurWest.BuurWest != null && _koning.Vakje.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurWest != null && _koning.Vakje.BuurWest.BuurWest.BuurWest.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurWest.BuurWest;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurWest.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurWest.BuurWest != null && _koning.Vakje.BuurWest.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurWest.BuurZuid != null && _koning.Vakje.BuurWest.BuurWest.BuurZuid.schaakstuk != null)
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
                if (randomstuk == 1 && _koning.Vakje.BuurWest.BuurZuid.BuurZuid != null && _koning.Vakje.BuurWest.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurWest.BuurZuid != null && _koning.Vakje.BuurWest.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurWest.BuurZuid;          // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest.BuurZuid.BuurZuid; // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurZuid.BuurZuid != null && _koning.Vakje.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurZuid != null && _koning.Vakje.BuurZuid.schaakstuk != null)
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
                if (randomstuk == 1 && _koning.Vakje.BuurOost != null && _koning.Vakje.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurZuid != null && _koning.Vakje.BuurOost.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurZuid;                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurZuid.BuurZuid;          // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurOost != null && _koning.Vakje.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost != null && _koning.Vakje.BuurOost.BuurOost.schaakstuk != null)
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
                if (randomstuk == 1 && _koning.Vakje.BuurOost.BuurZuid.BuurZuid != null && _koning.Vakje.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurZuid != null && _koning.Vakje.BuurOost.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurZuid.BuurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.BuurOost.BuurOost.BuurOost != null && _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid != null && _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid;            // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid;   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.Vakje.BuurOost.BuurOost.BuurOost != null && _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost != null && _koning.Vakje.BuurOost.BuurOost.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.BuurOost.BuurOost;                              // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost.BuurOost.BuurOost.BuurZuid.BuurZuid;   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 4 && _koning.Vakje.BuurOost.BuurOost != null && _koning.Vakje.BuurOost.BuurOost.BuurZuid.BuurZuid.schaakstuk == null && _koning.Vakje.BuurOost.BuurOost.BuurZuid != null && _koning.Vakje.BuurOost.BuurOost.BuurZuid.schaakstuk != null)
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
            // Kijk nu per verplaatst stuk of er geslagen kan worden
            bool alVerplaatst = false;
            for (int i = 0; i < _computer.VerplaatsingsLijst.Count; i++)
            {
                _geselecteerdStuk = _computer.VerplaatsingsLijst[i];  // geselecteerd stuk
                Schaakstuk schaakstuk = _computer.VerplaatsingsLijst[i].schaakstuk;

                // Controleert of het stuk nog wel bestaat
                if (schaakstuk != null && schaakstuk.Kleur == "zwart")
                {
                    if (schaakstuk is Pion && alVerplaatst == false)
                    {
                        if (_geselecteerdStuk.BuurZuid != null && _geselecteerdStuk.BuurZuid.schaakstuk == null)
                        {
                            if (_geselecteerdStuk.BuurZuid.BuurZuidOost != null && _geselecteerdStuk.BuurZuid.BuurZuidOost.schaakstuk == null && _geselecteerdStuk.BuurZuid.BuurZuidWest != null && _geselecteerdStuk.BuurZuid.BuurZuidWest.schaakstuk == null)
                            {
                                alVerplaatst = true;
                                _geselecteerdVakje = _computer.VerplaatsingsLijst[i].BuurZuid;       // geselecteerd vak
                                _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                            }
                        }
                    }
                }

                // Als er niets verplaatst kan worden, verplaats nieuw stuk
                if (i + 1 == _computer.VerplaatsingsLijst.Count && alVerplaatst == false)
                {
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
            bool verplaatst = false;
            int teller = 0;
            // voorkom een stack overflow door een domme zet te doen
            while (verplaatst == false)
            {
                Vakje vakje = _computer.VerplaatsingsLijst[teller];
                Schaakstuk schaakstuk = _computer.VerplaatsingsLijst[teller].schaakstuk;
                if (schaakstuk is Pion && vakje.BuurZuid != null && vakje.BuurZuid.schaakstuk == null)
                {
                    _computer.voerZetUit(vakje, vakje.BuurZuid);
                    verplaatst = true;
                }
                else if (schaakstuk is Paard)
                {
                    if(vakje.BuurNoordoost != null && vakje.BuurNoordoost.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurNoordoost);
                        verplaatst = true;
                    }
                    else if (vakje.BuurNoordWest != null && vakje.BuurNoordWest.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurNoordWest);
                        verplaatst = true;
                    }
                    else if (vakje.BuurZuidOost != null && vakje.BuurZuidOost.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurZuidOost);
                        verplaatst = true;
                    }
                    else if (vakje.BuurZuidWest != null && vakje.BuurZuidWest.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurZuidWest);
                        verplaatst = true;
                    }
                    else if (vakje.BuurWest.BuurNoord != null && vakje.BuurWest.BuurNoord.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurWest.BuurNoord);
                        verplaatst = true;
                    }
                    else if (vakje.BuurWest.BuurZuid != null && vakje.BuurWest.BuurZuid.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurWest.BuurZuid);
                        verplaatst = true;
                    }
                    else if (vakje.BuurOost.BuurNoord != null && vakje.BuurOost.BuurNoord.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurOost.BuurNoord);
                        verplaatst = true;
                    }
                    else if (vakje.BuurOost.BuurZuid != null && vakje.BuurOost.BuurZuid.schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.BuurOost.BuurZuid);
                        verplaatst = true;
                    }
                }
                if (teller < _computer.VerplaatsingsLijst.Count)
                {
                    teller++;
                }
                else
                {
                    verplaatst = true;
                    verplaatsNieuwStuk();
                }
            }
        }

        public void reageerOpSchaak(Vakje geselecteerd)
        {
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
            // Reageert op het schaak zetten van de computer
            if (reactie == false)
            {
                // sla waar mogelijk
                if (_koning.Vakje.BuurNoord != null && _koning.Vakje.BuurNoord.schaakstuk != null && _koning.Vakje.BuurNoord.schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurNoord);
                    reactie = true;
                }
                else if (_koning.Vakje.BuurNoordoost != null && _koning.Vakje.BuurNoordoost.schaakstuk != null && _koning.Vakje.BuurNoordoost.schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurNoordoost);
                    reactie = true;
                }
                else if (_koning.Vakje.BuurNoordWest != null && _koning.Vakje.BuurNoordWest.schaakstuk != null && _koning.Vakje.BuurNoordWest.schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurNoordWest);
                    reactie = true;
                }
                else if (_koning.Vakje.BuurWest != null && _koning.Vakje.BuurWest.schaakstuk != null && _koning.Vakje.BuurWest.schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurWest);
                    reactie = true;
                }
                else if (_koning.Vakje.BuurZuid != null && _koning.Vakje.BuurZuid.schaakstuk != null && _koning.Vakje.BuurZuid.schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurZuid);
                    reactie = true;
                }
                else if (_koning.Vakje.BuurZuidOost != null && _koning.Vakje.BuurZuidOost.schaakstuk != null && _koning.Vakje.BuurZuidOost.schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurZuidOost);
                    reactie = true;
                }
                else if (_koning.Vakje.BuurOost != null && _koning.Vakje.BuurOost.schaakstuk != null && _koning.Vakje.BuurOost.schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurOost);
                    reactie = true;
                }

                // verplaats naar een vakje waar koning niet schaak gezet kan worden
                if (_koning.Vakje.BuurNoord != null && _koning.Vakje.BuurNoord.schaakstuk == null && _slaanRichting != "Noord" && _slaanRichting != "Zuid" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurNoord);
                }
                else if (_koning.Vakje.BuurNoordoost != null && _koning.Vakje.BuurNoordoost.schaakstuk == null && _slaanRichting != "Noordoost" && _slaanRichting != "Zuidwest" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurNoordoost);
                }
                else if (_koning.Vakje.BuurNoordWest != null && _koning.Vakje.BuurNoordWest.schaakstuk == null && _slaanRichting != "Noordwest" && _slaanRichting != "Zuidoost" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurNoordWest);
                }
                else if (_koning.Vakje.BuurWest != null && _koning.Vakje.BuurWest.schaakstuk == null && _slaanRichting != "West" && _slaanRichting != "Oost" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurWest);
                }
                else if (_koning.Vakje.BuurOost != null && _koning.Vakje.BuurOost.schaakstuk == null && _slaanRichting != "Oost" && _slaanRichting != "West" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurOost);
                }
                else if (_koning.Vakje.BuurZuid != null && _koning.Vakje.BuurZuid.schaakstuk == null && _slaanRichting != "Zuid" && _slaanRichting != "Noord" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurZuid);
                }
                else if (_koning.Vakje.BuurZuidOost != null && _koning.Vakje.BuurZuidOost.schaakstuk == null && _slaanRichting != "Zuidoost" && _slaanRichting != "Noordwest" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurZuidOost);
                }
                else if (_koning.Vakje.BuurZuidWest != null && _koning.Vakje.BuurZuidWest.schaakstuk == null && _slaanRichting != "Zuidwest" && _slaanRichting != "Noordoost" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.BuurZuidWest);
                }

                if(reactie == true)
                {
                    // voorkomt dat computer twee zetten achter elkaar doet
                    _computer.ZojuistSchaak = true;
                }
                else if (reactie == false)
                {
                    controleerBurenSchaak(_slaanRichting, waarVanDaan);
                }
            }
        }

        private void controleerBurenSchaak(string richting, Vakje waarVanDaan)
        {
            bool reactie = false;
            string slaRichting = richting;
            Vakje oudVakje = waarVanDaan;
            Vakje volgendVakje = waarVanDaan;
            bool mogelijkloop = false;
            if (richting == "Noord")
            {
                volgendVakje = waarVanDaan.BuurNoord;
            }
            else if (richting == "Noordoost")
            {
                volgendVakje = waarVanDaan.BuurNoordoost;
            }
            else if (richting == "Noordwest")
            {
                volgendVakje = waarVanDaan.BuurNoordWest;
            }
            else if (richting == "West")
            {
                volgendVakje = waarVanDaan.BuurWest;
            }
            else if (richting == "Zuid")
            {
                volgendVakje = waarVanDaan.BuurZuid;
            }
            else if (richting == "Zuidoost")
            {
                volgendVakje = waarVanDaan.BuurZuidOost;
            }
            else if (richting == "Zuidwest")
            {
                volgendVakje = waarVanDaan.BuurZuidWest;
            }
            else
            {
                volgendVakje = waarVanDaan.BuurOost;
            }

            // loopt door de slaanrichting van de tegenstander en verzet een stuk zodat er niet meer geslagen kan worden
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
                    }
                    else
                    {
                        // Controleert buurnoord
                        if (volgendVakje.BuurNoord != null && volgendVakje.BuurNoord.schaakstuk != null && volgendVakje.BuurNoord.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurNoord.schaakstuk is Pion && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord, volgendVakje);
                            }

                            else if (volgendVakje.BuurNoord.schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord, volgendVakje);
                            }
                            else if (volgendVakje.BuurNoord.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoord, volgendVakje);
                            }
                        }

                        // Controleert buurnoordoost
                        if (volgendVakje.BuurNoordoost != null && volgendVakje.BuurNoordoost.schaakstuk != null && volgendVakje.BuurNoordoost.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurNoordoost.schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordoost, volgendVakje);
                            }
                            else if (volgendVakje.BuurNoordoost.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordoost, volgendVakje);
                            }
                            // slaat de tegenstander met een pion
                            else if (oudVakje.BuurNoordoost != null && oudVakje.BuurNoordoost.schaakstuk is Pion && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(oudVakje.BuurNoordoost, oudVakje);
                            }
                        }

                        // Controleert buurnoordwest
                        if (volgendVakje.BuurNoordWest != null && volgendVakje.BuurNoordWest.schaakstuk != null && volgendVakje.BuurNoordWest.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurNoordWest.schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordWest, volgendVakje);
                            }
                            else if (volgendVakje.BuurNoordWest.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurNoordWest, volgendVakje);
                            }
                            // slaat de tegenstander met een pion
                            else if (oudVakje.BuurNoordWest != null && oudVakje.BuurNoordWest.schaakstuk is Pion && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(oudVakje.BuurNoordWest, oudVakje);
                            }
                        }

                        // Controleert buurwest
                        if (volgendVakje.BuurWest != null && volgendVakje.BuurWest.schaakstuk != null && volgendVakje.BuurWest.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurWest.schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurWest, volgendVakje);
                            }
                            else if (volgendVakje.BuurWest.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurWest, volgendVakje);
                            }
                        }

                        // Controleert buuroost
                        if (volgendVakje.BuurOost != null && volgendVakje.BuurOost.schaakstuk != null && volgendVakje.BuurOost.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurOost.schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurOost, volgendVakje);
                            }
                            else if (volgendVakje.BuurOost.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurOost, volgendVakje);
                            }
                        }

                        // Controleert buurzuid
                        if (volgendVakje.BuurZuid != null && volgendVakje.BuurZuid.schaakstuk != null && volgendVakje.BuurZuid.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurZuid.schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuid, volgendVakje);
                            }
                            else if (volgendVakje.BuurZuid.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuid, volgendVakje);
                            }
                        }

                        // Controleert buurzuidoost
                        if (volgendVakje.BuurZuidOost != null && volgendVakje.BuurZuidOost.schaakstuk != null && volgendVakje.BuurZuidOost.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurZuidOost.schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidOost, volgendVakje);
                            }
                            else if (volgendVakje.BuurZuidOost.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidOost, volgendVakje);
                            }
                        }

                        // Controleert buurzuidwest
                        if (volgendVakje.BuurZuidWest != null && volgendVakje.BuurZuidWest.schaakstuk != null && volgendVakje.BuurZuidWest.schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.BuurZuidWest.schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidWest, volgendVakje);
                            }
                            else if (volgendVakje.BuurZuidWest.schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.BuurZuidWest, volgendVakje);
                            }
                        }

                        // gaat naar het volgende vakje wanneer er niets verplaatst kan worden
                        if (mogelijkloop == false)
                        {
                            // verder in de richting
                            if (richting == "Noord")
                            {
                                volgendVakje = volgendVakje.BuurNoord;
                            }
                            else if (richting == "Noordoost")
                            {
                                volgendVakje = volgendVakje.BuurNoordoost;
                            }
                            else if (richting == "Noordwest")
                            {
                                volgendVakje = volgendVakje.BuurNoordWest;
                            }
                            else if (richting == "West")
                            {
                                volgendVakje = volgendVakje.BuurWest;
                            }
                            else if (richting == "Oost")
                            {
                                volgendVakje = volgendVakje.BuurOost;
                            }
                            else if (richting == "Zuid")
                            {
                                volgendVakje = volgendVakje.BuurZuid;
                            }
                            else if (richting == "Zuidoost")
                            {
                                volgendVakje = volgendVakje.BuurZuidOost;
                            }
                            else if (richting == "Zuidwest")
                            {
                                volgendVakje = volgendVakje.BuurZuidWest;
                            }
                        }
                    }
                }
            }
            _computer.ZojuistSchaak = true; // voorkomt een tweede computer zet
            _computer.KoningVerplaats = true;
        }
    }
}