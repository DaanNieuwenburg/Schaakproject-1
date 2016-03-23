﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Paard : Schaakstuk
    {
        public Paard(string kleur, Vakje vakje, Speler speler)
        {
            this.vakje = vakje;
            this.kleur = kleur;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.PaardWit;
            }
            else
            {
                afbeelding = Properties.Resources.PaardZwart;
            }
        }
        public override void kanStukSlaan(Computer computer, Vakje geselecteerdStuk)
        {
            Vakje geselecteerdVak = geselecteerdStuk;
            if (geselecteerdStuk.schaakstuk.kleur == "zwart")
            {
                if (geselecteerdVak.buurNoord != null)
                {
                    if (geselecteerdVak.buurNoord.buurNoordoost.schaakstuk != null && geselecteerdVak.buurNoord.buurNoordoost.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurNoord.buurNoordoost.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurNoord.buurNoordoost);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.buurNoord.buurNoordwest != null && geselecteerdVak.buurNoord.buurNoordwest.schaakstuk != null && geselecteerdVak.buurNoord.buurNoordwest.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurNoord.buurNoordwest.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurNoord.buurNoordwest);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }

                if (geselecteerdVak.buurZuid != null)
                {
                    if (geselecteerdVak.buurZuid.buurZuidwest != null && geselecteerdVak.buurZuid.buurZuidwest.schaakstuk != null && geselecteerdVak.buurZuid.buurZuidwest.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurZuid.buurZuidwest.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurZuid.buurZuidwest);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.buurZuid.buurZuidoost != null && geselecteerdVak.buurZuid.buurZuidoost.schaakstuk != null && geselecteerdVak.buurZuid.buurZuidoost.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurZuid.buurZuidoost.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurZuid.buurZuidoost);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }

                if (geselecteerdVak.buurWest != null)
                {
                    if (geselecteerdVak.buurWest.buurNoordwest != null && geselecteerdVak.buurWest.buurNoordwest.schaakstuk != null && geselecteerdVak.buurWest.buurNoordwest.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurWest.buurNoordwest.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurWest.buurNoordwest);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.buurWest.buurZuidwest != null && geselecteerdVak.buurWest.buurZuidwest.schaakstuk != null && geselecteerdVak.buurWest.buurZuidwest.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurWest.buurZuidwest.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurWest.buurZuidwest);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }
                if (geselecteerdVak.buurOost != null)
                {
                    if (geselecteerdVak.buurOost.buurNoordwest != null && geselecteerdVak.buurOost.buurNoordwest.schaakstuk != null && geselecteerdVak.buurOost.buurNoordwest.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurOost.buurNoordwest.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurOost.buurNoordwest);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                    else if (geselecteerdVak.buurOost.buurZuidwest != null && geselecteerdVak.buurOost.buurZuidwest.schaakstuk != null && geselecteerdVak.buurOost.buurZuidwest.schaakstuk.kleur == "wit")
                    {
                        geselecteerdVak.buurOost.buurZuidwest.pbox.BackColor = System.Drawing.Color.Red;
                        computer.slaanmogelijkheden.Add(geselecteerdVak.buurOost.buurZuidwest);
                        computer.slaanmogelijkhedenVanaf.Add(geselecteerdStuk);
                    }
                }
                else
                {
                    computer.spelerkanslaan = false;
                    computer.computerkanslaan = false;
                }
            }
        }

        public override void Verplaats(Vakje nieuwVakje, Vakje selected, Mens speler, Spel spel)
        {
            bool gevonden = false;
            if (selected.buurNoord != null)
            {
                if (selected.buurNoord.buurNoordoost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurNoord.buurNoordwest == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurOost != null)
            {
                if (selected.buurOost.buurNoordoost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurOost.buurZuidoost == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurZuid != null)
            {
                if (selected.buurZuid.buurZuidoost == nieuwVakje)
                {
                    gevonden = true;
                }
                else if (selected.buurZuid.buurZuidwest == nieuwVakje)
                {
                    gevonden = true;
                }
            }
            if (selected.buurWest != null)
            {
                if (selected.buurWest.buurZuidwest == nieuwVakje)
                {
                    gevonden = true;
                }

                else if (selected.buurWest.buurNoordwest == nieuwVakje)
                {
                    gevonden = true;
                }
            }

            if (gevonden == true)
            {
                Schaakstuk temp = nieuwVakje.schaakstuk;
                nieuwVakje.schaakstuk = this;
                selected.schaakstuk = null;
                this.vakje = nieuwVakje;
                bool checkSchaak = spel.schaakbord.CheckSchaak(speler.Koning);
                if (checkSchaak == true)
                {
                    selected.schaakstuk = this;
                    nieuwVakje.schaakstuk = temp;
                    this.vakje = selected;
                }
                else
                {
                    speler.validezet = true;
                }
            }
        }
    }
}

