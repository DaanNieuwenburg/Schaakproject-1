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
                if (randomstuk == 1 && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3] != null && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3].Buren[2] != null && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3].Buren[2];                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3].Buren[2].Buren[2];      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.Buren[3].Buren[3].Buren[3] != null && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[2] != null && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[2];                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[2].Buren[2];      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3] != null && _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[3].Buren[3].Buren[3] != null && _koning.Vakje.Buren[3].Buren[3].Buren[3].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[3].Buren[3].Buren[3];                                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[3].Buren[3].Buren[3].Buren[3].Buren[2].Buren[2];      // geselecteerd vak
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
                if (randomstuk == 1 && _koning.Vakje.Buren[3].Buren[3] != null && _koning.Vakje.Buren[3].Buren[3].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[3].Buren[3].Buren[3] != null && _koning.Vakje.Buren[3].Buren[3].Buren[3].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[3].Buren[3].Buren[3];                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[3].Buren[3].Buren[2].Buren[2];      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.Buren[3].Buren[3] != null && _koning.Vakje.Buren[3].Buren[3].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[3].Buren[3].Buren[2] != null && _koning.Vakje.Buren[3].Buren[3].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[3].Buren[3].Buren[2];                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[3].Buren[3].Buren[2].Buren[2];      // geselecteerd vak
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
                if (randomstuk == 1 && _koning.Vakje.Buren[3].Buren[2].Buren[2] != null && _koning.Vakje.Buren[3].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[3].Buren[2] != null && _koning.Vakje.Buren[3].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[3].Buren[2];          // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[3].Buren[2].Buren[2]; // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.Buren[2].Buren[2] != null && _koning.Vakje.Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[2] != null && _koning.Vakje.Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[2];           // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[2].Buren[2];  // geselecteerd vak
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
                if (randomstuk == 1 && _koning.Vakje.Buren[1] != null && _koning.Vakje.Buren[1].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[1].Buren[2] != null && _koning.Vakje.Buren[1].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[1].Buren[2];                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[1].Buren[2].Buren[2];          // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.Buren[1] != null && _koning.Vakje.Buren[1].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[1].Buren[1] != null && _koning.Vakje.Buren[1].Buren[1].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[1].Buren[1];                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[1].Buren[2].Buren[2];      // geselecteerd vak
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
                if (randomstuk == 1 && _koning.Vakje.Buren[1].Buren[2].Buren[2] != null && _koning.Vakje.Buren[1].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[1].Buren[2] != null && _koning.Vakje.Buren[1].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[1].Buren[2];                // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[1].Buren[2].Buren[2];      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.Vakje.Buren[1].Buren[1].Buren[1] != null && _koning.Vakje.Buren[1].Buren[1].Buren[1].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[1].Buren[1].Buren[1].Buren[2] != null && _koning.Vakje.Buren[1].Buren[1].Buren[1].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[1].Buren[1].Buren[1].Buren[2];            // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[1].Buren[1].Buren[1].Buren[2].Buren[2];   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.Vakje.Buren[1].Buren[1].Buren[1] != null && _koning.Vakje.Buren[1].Buren[1].Buren[1].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[1].Buren[1] != null && _koning.Vakje.Buren[1].Buren[1].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[1].Buren[1];                              // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[1].Buren[1].Buren[1].Buren[2].Buren[2];   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 4 && _koning.Vakje.Buren[1].Buren[1] != null && _koning.Vakje.Buren[1].Buren[1].Buren[2].Buren[2].schaakstuk == null && _koning.Vakje.Buren[1].Buren[1].Buren[2] != null && _koning.Vakje.Buren[1].Buren[1].Buren[2].schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.Vakje.Buren[1].Buren[1].Buren[2];             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.Buren[1].Buren[1].Buren[2].Buren[2];    // geselecteerd vak
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
                        if (_geselecteerdStuk.Buren[2] != null && _geselecteerdStuk.Buren[2].schaakstuk == null)
                        {
                            if (_geselecteerdStuk.Buren[2].Buren[5] != null && _geselecteerdStuk.Buren[2].Buren[5].schaakstuk == null && _geselecteerdStuk.Buren[2].Buren[6] != null && _geselecteerdStuk.Buren[2].Buren[6].schaakstuk == null)
                            {
                                alVerplaatst = true;
                                _geselecteerdVakje = _computer.VerplaatsingsLijst[i].Buren[2];       // geselecteerd vak
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
                if (schaakstuk is Pion && vakje.Buren[2] != null && vakje.Buren[2].schaakstuk == null)
                {
                    _computer.voerZetUit(vakje, vakje.Buren[2]);
                    verplaatst = true;
                }
                else if (schaakstuk is Paard)
                {
                    if (vakje.Buren[4] != null && vakje.Buren[4].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[4]);
                        verplaatst = true;
                    }
                    else if (vakje.Buren[7] != null && vakje.Buren[7].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[7]);
                        verplaatst = true;
                    }
                    else if (vakje.Buren[5] != null && vakje.Buren[5].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[5]);
                        verplaatst = true;
                    }
                    else if (vakje.Buren[6] != null && vakje.Buren[6].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[6]);
                        verplaatst = true;
                    }
                    else if (vakje.Buren[3].Buren[0] != null && vakje.Buren[3].Buren[0].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[3].Buren[0]);
                        verplaatst = true;
                    }
                    else if (vakje.Buren[3].Buren[2] != null && vakje.Buren[3].Buren[2].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[3].Buren[2]);
                        verplaatst = true;
                    }
                    else if (vakje.Buren[1].Buren[0] != null && vakje.Buren[1].Buren[0].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[1].Buren[0]);
                        verplaatst = true;
                    }
                    else if (vakje.Buren[1].Buren[2] != null && vakje.Buren[1].Buren[2].schaakstuk == null)
                    {
                        _computer.voerZetUit(vakje, vakje.Buren[1].Buren[2]);
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
            volgendVakje = geselecteerd.Buren[0];
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
                    volgendVakje = volgendVakje.Buren[0];
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.Buren[4];
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
                    volgendVakje = volgendVakje.Buren[4];
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.Buren[7];
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
                    volgendVakje = volgendVakje.Buren[7];
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.Buren[1];
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
                    volgendVakje = volgendVakje.Buren[1];
                }
            }


            mogelijkloop = false;
            volgendVakje = geselecteerd.Buren[2];
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
                    volgendVakje = volgendVakje.Buren[2];
                }
            }


            mogelijkloop = false;
            volgendVakje = geselecteerd.Buren[5];
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
                    volgendVakje = volgendVakje.Buren[5];
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.Buren[6];
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
                    volgendVakje = volgendVakje.Buren[6];
                }
            }

            mogelijkloop = false;
            volgendVakje = geselecteerd.Buren[3];
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
                    volgendVakje = volgendVakje.Buren[3];
                }
            }
            // Reageert op het schaak zetten van de computer
            if (reactie == false)
            {
                // sla waar mogelijk
                if (_koning.Vakje.Buren[0] != null && _koning.Vakje.Buren[0].schaakstuk != null && _koning.Vakje.Buren[0].schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[0]);
                    reactie = true;
                }
                else if (_koning.Vakje.Buren[4] != null && _koning.Vakje.Buren[4].schaakstuk != null && _koning.Vakje.Buren[4].schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[4]);
                    reactie = true;
                }
                else if (_koning.Vakje.Buren[7] != null && _koning.Vakje.Buren[7].schaakstuk != null && _koning.Vakje.Buren[7].schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[7]);
                    reactie = true;
                }
                else if (_koning.Vakje.Buren[3] != null && _koning.Vakje.Buren[3].schaakstuk != null && _koning.Vakje.Buren[3].schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[3]);
                    reactie = true;
                }
                else if (_koning.Vakje.Buren[2] != null && _koning.Vakje.Buren[2].schaakstuk != null && _koning.Vakje.Buren[2].schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[2]);
                    reactie = true;
                }
                else if (_koning.Vakje.Buren[5] != null && _koning.Vakje.Buren[5].schaakstuk != null && _koning.Vakje.Buren[5].schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[5]);
                    reactie = true;
                }
                else if (_koning.Vakje.Buren[1] != null && _koning.Vakje.Buren[1].schaakstuk != null && _koning.Vakje.Buren[1].schaakstuk.Kleur == "wit" && reactie == false)
                {
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[1]);
                    reactie = true;
                }

                // verplaats naar een vakje waar koning niet schaak gezet kan worden
                if (_koning.Vakje.Buren[0] != null && _koning.Vakje.Buren[0].schaakstuk == null && _slaanRichting != "Noord" && _slaanRichting != "Zuid" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[0]);
                }
                else if (_koning.Vakje.Buren[4] != null && _koning.Vakje.Buren[4].schaakstuk == null && _slaanRichting != "Noordoost" && _slaanRichting != "Zuidwest" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[4]);
                }
                else if (_koning.Vakje.Buren[7] != null && _koning.Vakje.Buren[7].schaakstuk == null && _slaanRichting != "Noordwest" && _slaanRichting != "Zuidoost" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[7]);
                }
                else if (_koning.Vakje.Buren[3] != null && _koning.Vakje.Buren[3].schaakstuk == null && _slaanRichting != "West" && _slaanRichting != "Oost" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[3]);
                }
                else if (_koning.Vakje.Buren[1] != null && _koning.Vakje.Buren[1].schaakstuk == null && _slaanRichting != "Oost" && _slaanRichting != "West" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[1]);
                }
                else if (_koning.Vakje.Buren[2] != null && _koning.Vakje.Buren[2].schaakstuk == null && _slaanRichting != "Zuid" && _slaanRichting != "Noord" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[2]);
                }
                else if (_koning.Vakje.Buren[5] != null && _koning.Vakje.Buren[5].schaakstuk == null && _slaanRichting != "Zuidoost" && _slaanRichting != "Noordwest" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[5]);
                }
                else if (_koning.Vakje.Buren[6] != null && _koning.Vakje.Buren[6].schaakstuk == null && _slaanRichting != "Zuidwest" && _slaanRichting != "Noordoost" && reactie == false)
                {
                    _computer.KoningVerplaats = true;
                    reactie = true;
                    _computer.voerZetUit(_koning.Vakje, _koning.Vakje.Buren[6]);
                }

                if (reactie == true)
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
                volgendVakje = waarVanDaan.Buren[0];
            }
            else if (richting == "Noordoost")
            {
                volgendVakje = waarVanDaan.Buren[4];
            }
            else if (richting == "Noordwest")
            {
                volgendVakje = waarVanDaan.Buren[7];
            }
            else if (richting == "West")
            {
                volgendVakje = waarVanDaan.Buren[3];
            }
            else if (richting == "Zuid")
            {
                volgendVakje = waarVanDaan.Buren[2];
            }
            else if (richting == "Zuidoost")
            {
                volgendVakje = waarVanDaan.Buren[5];
            }
            else if (richting == "Zuidwest")
            {
                volgendVakje = waarVanDaan.Buren[6];
            }
            else
            {
                volgendVakje = waarVanDaan.Buren[1];
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
                        if (volgendVakje.Buren[0] != null && volgendVakje.Buren[0].schaakstuk != null && volgendVakje.Buren[0].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[0].schaakstuk is Pion && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[0], volgendVakje);
                            }

                            else if (volgendVakje.Buren[0].schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[0], volgendVakje);
                            }
                            else if (volgendVakje.Buren[0].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[0], volgendVakje);
                            }
                        }

                        // Controleert buurnoordoost
                        if (volgendVakje.Buren[4] != null && volgendVakje.Buren[4].schaakstuk != null && volgendVakje.Buren[4].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[4].schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[4], volgendVakje);
                            }
                            else if (volgendVakje.Buren[4].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[4], volgendVakje);
                            }
                            // slaat de tegenstander met een pion
                            else if (oudVakje.Buren[4] != null && oudVakje.Buren[4].schaakstuk is Pion && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(oudVakje.Buren[4], oudVakje);
                            }
                        }

                        // Controleert buurnoordwest
                        if (volgendVakje.Buren[7] != null && volgendVakje.Buren[7].schaakstuk != null && volgendVakje.Buren[7].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[7].schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[7], volgendVakje);
                            }
                            else if (volgendVakje.Buren[7].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[7], volgendVakje);
                            }
                            // slaat de tegenstander met een pion
                            else if (oudVakje.Buren[7] != null && oudVakje.Buren[7].schaakstuk is Pion && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(oudVakje.Buren[7], oudVakje);
                            }
                        }

                        // Controleert buurwest
                        if (volgendVakje.Buren[3] != null && volgendVakje.Buren[3].schaakstuk != null && volgendVakje.Buren[3].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[3].schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[3], volgendVakje);
                            }
                            else if (volgendVakje.Buren[3].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[3], volgendVakje);
                            }
                        }

                        // Controleert buuroost
                        if (volgendVakje.Buren[1] != null && volgendVakje.Buren[1].schaakstuk != null && volgendVakje.Buren[1].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[1].schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[1], volgendVakje);
                            }
                            else if (volgendVakje.Buren[1].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[1], volgendVakje);
                            }
                        }

                        // Controleert buurzuid
                        if (volgendVakje.Buren[2] != null && volgendVakje.Buren[2].schaakstuk != null && volgendVakje.Buren[2].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[2].schaakstuk is Toren && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[2], volgendVakje);
                            }
                            else if (volgendVakje.Buren[2].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[2], volgendVakje);
                            }
                        }

                        // Controleert buurzuidoost
                        if (volgendVakje.Buren[5] != null && volgendVakje.Buren[5].schaakstuk != null && volgendVakje.Buren[5].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[5].schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[5], volgendVakje);
                            }
                            else if (volgendVakje.Buren[5].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[5], volgendVakje);
                            }
                        }

                        // Controleert buurzuidwest
                        if (volgendVakje.Buren[6] != null && volgendVakje.Buren[6].schaakstuk != null && volgendVakje.Buren[6].schaakstuk.Kleur == "zwart")
                        {
                            // kijkt of er een schaakstuk staat die schaak kan en blokkeren en verplaats dat schaakstuk
                            if (volgendVakje.Buren[6].schaakstuk is Loper && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[6], volgendVakje);
                            }
                            else if (volgendVakje.Buren[6].schaakstuk is Dame && reactie == false)
                            {
                                reactie = true;
                                mogelijkloop = true;
                                _computer.voerZetUit(volgendVakje.Buren[6], volgendVakje);
                            }
                        }

                        // gaat naar het volgende vakje wanneer er niets verplaatst kan worden
                        if (mogelijkloop == false)
                        {
                            // verder in de richting
                            if (richting == "Noord")
                            {
                                volgendVakje = volgendVakje.Buren[0];
                            }
                            else if (richting == "Noordoost")
                            {
                                volgendVakje = volgendVakje.Buren[4];
                            }
                            else if (richting == "Noordwest")
                            {
                                volgendVakje = volgendVakje.Buren[7];
                            }
                            else if (richting == "West")
                            {
                                volgendVakje = volgendVakje.Buren[3];
                            }
                            else if (richting == "Oost")
                            {
                                volgendVakje = volgendVakje.Buren[1];
                            }
                            else if (richting == "Zuid")
                            {
                                volgendVakje = volgendVakje.Buren[2];
                            }
                            else if (richting == "Zuidoost")
                            {
                                volgendVakje = volgendVakje.Buren[5];
                            }
                            else if (richting == "Zuidwest")
                            {
                                volgendVakje = volgendVakje.Buren[6];
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