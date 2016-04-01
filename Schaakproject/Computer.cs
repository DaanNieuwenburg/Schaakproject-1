// COMPUTER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; // voor testen
using System.Drawing;

namespace Schaakproject
{
    public class Computer : Speler
    {
        private Vakje _vorigVakje { get; set; }
        private Schaakstuk _vorigSchaakstuk { get; set; }
        public Algoritme algoritme { get; set; }
        private Color _selectedColor { get; set; }
        private List<Vakje> _nietVerplaatstLijst = new List<Vakje>();
        public List<Vakje> NietVerplaatstLijst
        {
            get { return _nietVerplaatstLijst; }
            set { _nietVerplaatstLijst = value; }
        }

        private List<Vakje> _verplaatsingsLijst = new List<Vakje>();
        public List<Vakje> VerplaatsingsLijst
        {
            get { return _verplaatsingsLijst; }
            set { _verplaatsingsLijst = value; }
        }
        private int _positieZuid { get; set; }
        private int _positieWest { get; set; }
        public Computer(string naam, string kleur, Color selectcolor, Spel _spel)
        {
            _selectedColor = selectcolor;
            Naam = naam;
            Kleur = kleur;
            spel = _spel;
        }

        public void Zet(Vakje _pictures)
        {
            _vorigVakje = spel.Selected;                   // slaat het door de speler geselecteerde vakje op
            _vorigSchaakstuk = spel.Selected.schaakstuk;   // slaat het door de speler geselecteerde schaakstuk op     -- dit moet ook vanuit vorigvakje kunnen, scheelt code?
            bepaalMensPositie();
        }

        private void bepaalMensPositie()
        {
            // kijk naar welke positie de mens zijn schaakstuk heeft verplaats
            bool buurzuid = false;
            int zuidteller = 0;
            _vorigVakje = spel.Selected;
            while (buurzuid == false)
            {
                if (buurzuid == false && _vorigVakje != null)
                {
                    _vorigVakje = _vorigVakje.BuurZuid;
                    zuidteller++;
                }
                else
                {
                    _positieZuid = zuidteller;
                    buurzuid = true;
                }
            }

            bool buurwest = false;
            int westteller = 0;
            _vorigVakje = spel.Selected; // reset vakje
            while (buurwest == false)
            {
                if (buurwest == false && _vorigVakje != null)
                {
                    _vorigVakje = _vorigVakje.BuurWest;
                    westteller++;
                }
                else
                {
                    buurwest = true;
                    _positieWest = westteller;
                }
            }

            // begin met het algoritme
            Algoritme Calgoritme = new Algoritme(this);
            algoritme = Calgoritme;
        }

        public void voerZetUit(Vakje geselecteerdStuk, Vakje geselecteerdVakje)
        {
            Console.WriteLine("Voer zet uit");
            VerplaatsingsLijst.Add(geselecteerdVakje);       // slaat de positie van de computerszet in lijst op 

            geselecteerdStuk.schaakstuk.Verplaats(geselecteerdVakje, geselecteerdStuk, spel);
            geselecteerdStuk.Pbox.update();                 //update het eerste vakje
            geselecteerdVakje.Pbox.update();                 //update het tweede vakje
            geselecteerdStuk = null;                        //niets is meer geselecteerd
        }
    }
}

