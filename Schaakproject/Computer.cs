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
        private Vakje _vorigvakje { get; set; }
        private Schaakstuk _vorigschaakstuk { get; set; }
        private Spel _spel { get; set; }
        private Color _selectedcolor { get; set; }

        private List<Vakje> _nietverplaatstlijst = new List<Vakje>();
        public List<Vakje> nietverplaatstlijst
        {
            get { return _nietverplaatstlijst; }
            set { _nietverplaatstlijst = value; }
        }

        private List<Vakje> _verplaatsingslijst = new List<Vakje>();
        public List<Vakje> verplaatsingsLijst
        {
            get { return _verplaatsingslijst; }
            set { _verplaatsingslijst = value; }
        }
        private int _positieZuid { get; set; }
        private int _positieWest { get; set; }
        public Computer(string naam, string kleur, Color selectcolor)
        {
            _selectedcolor = selectcolor;
            Naam = naam;
            Kleur = kleur;
        }

        public void Zet(Vakje _pictures, Spel spel)
        {
            Console.WriteLine("COMPUTERS BEURT");
            _spel = spel;
            _vorigvakje = _spel.selected;                   // slaat het door de speler geselecteerde vakje op
            _vorigschaakstuk = _spel.selected.schaakstuk;   // slaat het door de speler geselecteerde schaakstuk op     -- dit moet ook vanuit vorigvakje kunnen, scheelt code?
            bepaalMensPositie();
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
                }
                else
                {
                    buurwest = true;
                    _positieWest = westteller;
                }
            }

            // begin met het algoritme
            Algoritme algoritme = new Algoritme(this);
        }

        public void voerZetUit(Vakje geselecteerdStuk, Vakje geselecteerdVakje)
        {
            Console.WriteLine("UITVOEREN VAN ZET");
            verplaatsingsLijst.Add(geselecteerdVakje);       // slaat de positie van de computerszet in lijst op 
            try
            {
                geselecteerdStuk.schaakstuk.Verplaats(geselecteerdVakje, geselecteerdStuk, _spel);
                geselecteerdStuk.pbox.update();                 //update het eerste vakje
                geselecteerdVakje.pbox.update();                 //update het tweede vakje
                geselecteerdStuk = null;                        //niets is meer geselecteerd
                _spel.VeranderSpeler();
            }
            catch
            {
                geselecteerdStuk.pbox.BackColor = System.Drawing.Color.Red;
                geselecteerdVakje.pbox.BackColor = System.Drawing.Color.Blue;
            }
        }
    }
}

