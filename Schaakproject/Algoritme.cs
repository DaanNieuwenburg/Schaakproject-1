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

        public Algoritme(Computer computer)
        {
            _computer = computer;
            _koning = computer.Koning;
            // kijk of er geslagen kan worden
            controleerOpSlaan();
            if (slaanmogelijkheden.Count > 0)
            {
                Console.WriteLine("SLA EEN STUK");
                slaEenStuk();
            }
            else
            {
                Random rnd = new Random();
                int percentage = 1;
                //int percentage = rnd.Next(1, 4);
                if (percentage == 1)
                {
                    verplaatsNieuwStuk();
                }
                else if (percentage > 1)
                {
                    //verplaatsVerplaatstStuk();
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
            Console.WriteLine("SLA");
            for (int i = 0; i < slaanmogelijkheden.Count; i++)
            {
                Schaakstuk schaakstuk = slaanmogelijkheden[i].schaakstuk;
                if (schaakstuk is Koning && schaakstuk.kleur == "wit")
                {
                    Console.WriteLine("KONING GESLAGEN");
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Pion && schaakstuk.kleur == "wit")
                {
                    Console.WriteLine("PION GESLAGEN");
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }

                else if (schaakstuk is Toren || schaakstuk is Paard || schaakstuk is Loper && schaakstuk.kleur == "wit")
                {
                    Console.WriteLine("LOPER GESLAGEN");
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
                else if (schaakstuk is Dame && schaakstuk.kleur == "wit")
                {
                    Console.WriteLine("DAME GESLAGEN");
                    _geselecteerdStuk = slaanmogelijkhedenVanaf[i];  // geselecteerd stuk
                    _geselecteerdVakje = slaanmogelijkheden[i];       // geselecteerd vak
                    _computer.voerZetUit(_geselecteerdStuk, _geselecteerdVakje);
                }
            }
        }

        private void verplaatsNieuwStuk()
        {
            Console.WriteLine("VERPLAATS NIEUW STUK");
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
                }
            }

            // Rechtsmiddenbord
            else if (randomgetal == 4)
            {
                int randomstuk = rnd.Next(1, 3);
                if (randomstuk == 1 && _koning.vakje.buurOost.buurZuid.buurZuid.schaakstuk == null && _koning.vakje.buurOost.schaakstuk != null)
                {
                    _geselecteerdStuk = _koning.vakje.buurOost;                   // geselecteerd stuk
                    _geselecteerdVakje = _koning.vakje.buurOost.buurZuid.buurZuid; // geselecteerd vak
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
                }
            }
        }
        private void verplaatsVerplaatstStuk()
        {
            Console.WriteLine("VERPLAATS VERPLAATST STUK");
        }
    }
}
