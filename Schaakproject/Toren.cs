using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Toren : Schaakstuk
    {
        public bool _eersteZet { get; private set; } // Is de toren al eens verzet

        public Toren(string kleur, Vakje vakje)
        {
            this.kleur = kleur;
            this.vakje = vakje;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.TorenWit;
            }
            else
            {
                afbeelding = Properties.Resources.TorenZwart;
            }
        }

        public override void kanStukSlaan(Computer computer, Vakje geselecteerdStuk)
        {
            bool mogelijkloop = false;
            Vakje geselecteerdVak = geselecteerdStuk;
            Vakje vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    computer.computerkanslaan = true;
                }
                else if(vorigVakje == null)
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = false;
                    computer.computerkanslaan = false;

                }
                vorigVakje = vorigVakje.buurNoord;
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    computer.computerkanslaan = true;
                }
                else if (vorigVakje == null)
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = false;
                    computer.computerkanslaan = false;
                }
                vorigVakje = vorigVakje.buurOost;
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    computer.computerkanslaan = true;
                }
                else if (vorigVakje == null)
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = false;
                    computer.computerkanslaan = false;
                }
                vorigVakje = vorigVakje.buurZuid;
            }

            geselecteerdVak = geselecteerdStuk;
            vorigVakje = geselecteerdStuk;
            while (mogelijkloop == false)
            {
                if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "wit")
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = true;
                }
                else if (vorigVakje.schaakstuk != null && vorigVakje.schaakstuk.kleur == "zwart")
                {
                    mogelijkloop = true;
                    computer.computerkanslaan = true;
                }
                else if (vorigVakje == null)
                {
                    mogelijkloop = true;
                    computer.spelerkanslaan = false;
                    computer.computerkanslaan = false;
                }
                vorigVakje = vorigVakje.buurWest;
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler)
        {
            bool mogelijk = false;
            bool mogelijkloop = false;
            Vakje vorige = selected;
            while (mogelijkloop == false)
            {
                if (vorige.buurNoord == nieuwVakje)
                {
                    mogelijk = true;
                    mogelijkloop = true;
                }
                else if (vorige.buurNoord == null || vorige.buurNoord.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoord;
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurOost == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.buurOost == null || vorige.buurOost.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurOost;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurZuid == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                        
                    }
                    else if (vorige.buurZuid == null || vorige.buurZuid.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurZuid;
                }
            }
            mogelijkloop = false;
            vorige = selected;
            if (mogelijk == false)
            {
                while (mogelijkloop == false)
                {
                    if (vorige.buurWest == nieuwVakje)
                    {
                        mogelijk = true;
                        mogelijkloop = true;
                    }
                    else if (vorige.buurWest == null || vorige.buurWest.schaakstuk != null)
                    {
                        mogelijkloop = true;
                    }
                    vorige = vorige.buurWest;
                }
            }
            if (mogelijk == true)
            {
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                speler.validezet = true;
                _eersteZet = true;
                
            }
        }
    }
}

