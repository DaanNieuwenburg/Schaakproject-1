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
        private Computer _computer;
        private Schaakstuk _koning;
        private Vakje _geselecteerdStuk;
        private Vakje _geselecteerdVakje;
        public bool StaatSchaak;
        public Algoritme(Computer computer)
        {
            _computer = computer;
            _koning = computer.Koning;
            // kijk of er geslagen kan worden
            controleerOpSlaan();
            Console.WriteLine("-------------------------------------");
            if (slaanmogelijkheden.Count > 0 && StaatSchaak == false)
            {
                slaEenStuk();
            }
            else
            {
                Random rnd = new Random();
                //int percentage = 1337;
                int percentage = rnd.Next(1, 4);
                Console.WriteLine("PERCENTAGE = " + percentage);
                if (percentage == 1 && StaatSchaak == false)
                {
                    Console.WriteLine("6 NIEUW STUK");
                    verplaatsNieuwStuk();
                }
                else if (percentage > 1 && computer.verplaatsingsLijst.Count > 0)
                {
                    Console.WriteLine("6 VERPLAATS STUK");
                    verplaatsVerplaatstStuk();
                }
                else
                {
                    Console.WriteLine("6 VERPLAATS NIEUW STUK");
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
            foreach (Vakje nietverplaatststuk in _computer.nietverplaatstlijst)
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
            foreach (Vakje verplaatststuk in _computer.verplaatsingsLijst)
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
            bool alGeslagen = false;
            for (int i = 0; i < slaanmogelijkheden.Count; i++)
            {
                Schaakstuk schaakstuk = slaanmogelijkheden[i].schaakstuk;
                if (schaakstuk is Koning && schaakstuk.kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Pion && schaakstuk.kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Toren && schaakstuk.kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Paard && schaakstuk.kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Loper && schaakstuk.kleur == "wit" && alGeslagen == false)
                {
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    alGeslagen = true;
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (schaakstuk is Dame && schaakstuk.kleur == "wit" && alGeslagen == false)
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
                if (randomstuk == 1 && _koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.vakje.buurWest.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurWest.buurWest.buurWest.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurWest.buurWest.buurWest.buurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurWest.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurWest.buurWest.buurWest.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurWest.buurWest.buurWest;                                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurWest.buurWest.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
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
                if (randomstuk == 1 && _koning.vakje.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurWest.buurWest.buurWest.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurWest.buurWest.buurWest;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.vakje.buurWest.buurWest.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurWest.buurWest.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurWest.buurWest.buurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurWest.buurWest.buurZuid.buurZuid;      // geselecteerd vak
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
                if (randomstuk == 1 && _koning.vakje.buurWest.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurWest.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurWest.buurZuid;          // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurWest.buurZuid.buurZuid; // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.vakje.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurZuid;           // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurZuid.buurZuid;  // geselecteerd vak
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
                if (randomstuk == 1 && _koning.vakje.buurOost.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurOost.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurOost.buurZuid;                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost.buurZuid.buurZuid;          // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.vakje.buurOost.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurOost.buurOost.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurOost.buurOost;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost.buurZuid.buurZuid;      // geselecteerd vak
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
                if (randomstuk == 1 && _koning.vakje.buurOost.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurOost.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurOost.buurZuid;                // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost.buurZuid.buurZuid;      // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 2 && _koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurOost.buurOost.buurOost.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurOost.buurOost.buurOost.buurZuid;            // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid;   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 3 && _koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurOost.buurOost.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurOost.buurOost;                              // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost.buurOost.buurOost.buurZuid.buurZuid;   // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (randomstuk == 4 && _koning.vakje.buurOost.buurOost.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurOost.buurOost.buurZuid.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurOost.buurOost.buurZuid;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost.buurOost.buurZuid.buurZuid;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else
                {
                    verplaatsVerplaatstStuk();
                }
            }
        }
        private void verplaatsVerplaatstStuk()
        {
            // Kijk nu per verplaatst stuk of er geslagen kan worden
            bool alVerplaatst = false;
            for (int i = 0; i < _computer.verplaatsingsLijst.Count; i++)
            {
                _geselecteerdStuk = _computer.verplaatsingsLijst[i];  // geselecteerd stuk
                Schaakstuk schaakstuk = _computer.verplaatsingsLijst[i].schaakstuk;
                if (schaakstuk is Pion && alVerplaatst == false)
                {
                    if (_geselecteerdStuk.buurZuid != null && _geselecteerdStuk.buurZuid.schaakstuk == null)
                    {
                        if (_geselecteerdStuk.buurZuid.buurZuidoost != null && _geselecteerdStuk.buurZuid.buurZuidoost.schaakstuk == null)
                        {
                            alVerplaatst = true;
                            _geselecteerdVakje = _computer.verplaatsingsLijst[i].buurZuid;       // geselecteerd vak
                            _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                        }
                        else if (_geselecteerdStuk.buurZuid.buurZuidwest != null && _geselecteerdStuk.buurZuid.buurZuidwest.schaakstuk == null)
                        {
                            alVerplaatst = true;
                            _geselecteerdVakje = _computer.verplaatsingsLijst[i].buurZuid;       // geselecteerd vak
                            _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
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
                if (i + 1 == _computer.verplaatsingsLijst.Count && alVerplaatst == false)
                {
                    Console.WriteLine("Er zijn geen verplaatsingen meer en verplaats nieuw stuk");
                    alVerplaatst = true;
                    verplaatsNieuwStuk();
                }
            }
        }

        public void reageerOpSchaak(Vakje geselecteerd)
        {
            Vakje select = geselecteerd;
            bool reactie = false;

            // verplaats schaakstuk naar een leeg vak wanneer mogelijk
            if (reactie == false)
            {
                Console.WriteLine("Reageer op schaak in algoritme");
                if (_koning.vakje.buurNoord != null && _koning.vakje.buurNoord.schaakstuk == null)
                {
                    Console.WriteLine("noord");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurNoord;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.vakje.buurNoordoost != null && _koning.vakje.buurNoordoost.schaakstuk == null)
                {
                    Console.WriteLine("noordoost");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurNoordoost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.vakje.buurNoordwest != null && _koning.vakje.buurNoordwest.schaakstuk == null)
                {
                    Console.WriteLine("noordwest");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurNoordwest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.vakje.buurWest != null && _koning.vakje.buurWest.schaakstuk == null)
                {
                    Console.WriteLine("west");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurWest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.vakje.buurOost != null && _koning.vakje.buurOost.schaakstuk == null)
                {
                    Console.WriteLine("oost");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.vakje.buurZuid != null && _koning.vakje.buurZuid.schaakstuk == null)
                {
                    Console.WriteLine("zuid");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurZuid;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.vakje.buurZuidoost != null && _koning.vakje.buurZuidoost.schaakstuk == null)
                {
                    Console.WriteLine("zuidoost");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurZuidoost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.vakje.buurZuidwest != null && _koning.vakje.buurZuidwest.schaakstuk == null)
                {
                    Console.WriteLine("zuidwest");
                    _geselecteerdStuk = _koning.vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurZuidwest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
            }

            // verplaats een nieuw stuk
            if (reactie == false)
            {

            }
        }
    }
}
