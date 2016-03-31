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
                if (percentage == 1)
                {
                    verplaatsNieuwStuk();
                }
                else if (percentage > 1 && computer.VerplaatsingsLijst.Count > 0)
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
                    verplaatsVerplaatstStuk();
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
                    verplaatsNieuwStuk();
                }
            }
        }

        public void reageerOpSchaak(Vakje geselecteerd)
        {
            Console.WriteLine("Reageer op schaak");
            Vakje select = geselecteerd;
            bool reactie = false;

            // verplaats schaakstuk naar een leeg vak wanneer mogelijk
            if (reactie == false)
            {
                Console.WriteLine("Reageer op schaak in algoritme");
                if (_koning.Vakje.BuurNoord != null && _koning.Vakje.BuurNoord.schaakstuk == null)
                {
                    Console.WriteLine("noord");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurNoord;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.Vakje.BuurNoordoost != null && _koning.Vakje.BuurNoordoost.schaakstuk == null)
                {
                    Console.WriteLine("noordoost");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurNoordoost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.Vakje.BuurNoordWest != null && _koning.Vakje.BuurNoordWest.schaakstuk == null)
                {
                    Console.WriteLine("noordwest");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurNoordWest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.Vakje.BuurWest != null && _koning.Vakje.BuurWest.schaakstuk == null)
                {
                    Console.WriteLine("west");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurWest;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.Vakje.BuurOost != null && _koning.Vakje.BuurOost.schaakstuk == null)
                {
                    Console.WriteLine("oost");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurOost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.Vakje.BuurZuid != null && _koning.Vakje.BuurZuid.schaakstuk == null)
                {
                    Console.WriteLine("zuid");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurZuid;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.Vakje.BuurZuidOost != null && _koning.Vakje.BuurZuidOost.schaakstuk == null)
                {
                    Console.WriteLine("zuidoost");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurZuidOost;    // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (_koning.Vakje.BuurZuidWest != null && _koning.Vakje.BuurZuidWest.schaakstuk == null)
                {
                    Console.WriteLine("zuidwest");
                    _geselecteerdStuk = _koning.Vakje;             // geselecteerd stuk
                    _geselecteerdVakje = _koning.Vakje.BuurZuidWest;    // geselecteerd vak
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
