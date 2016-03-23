﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public static class MSSystemExtenstions
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this T[] array)
        {
            rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n);
                n--;
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
    public class Schaakbord
    {
        public Vakje[,] schaakarray { get; private set; }   //Een array van vakjes zodat het schaakbord kan worden opgezet
        public Color _kleur { get; private set; }
        private int aantal1 { get; set; }                   //Het aantal schaakstukken wordt ingesteld voor wit
        private int aantal2 { get; set; }                   //Het aantal schaakstukken wordt ingesteld voor zwart
        private bool staatschaak { get; set; }              //Staat er iemand schaak?
        private string kleurstuk { get; set; }              //De kleur van het stuk
        private string variant { get; set; }                //Klassiek of Chess960
        private Schaakstuk schaakGezet { get; set; }        //Het schaakstuk dat de koning schaak heeft gezet
        private string richting { get; set; }               //De richting waar het schaakstuk dat de koning schaak heeft gezet staat
        private bool pionvoormat { get; set; }              //om te kijken of er een pion gezet kan worden tussen de koning en een stuk

        public Schaakbord(string _Variant, Spel Spel, Speler Speler1, Speler Speler2)
        {


            bool staatopwit = true;
            schaakarray = new Vakje[8, 8];
            variant = _Variant;
            bool kleurvakje = false; //zwart of wit
            kleurstuk = "zwart";
            Speler voorDitStuk = Speler2;
            int[] array = new int[]
            {
                0,1,2,3,4,5,6,7
            };
            array.Shuffle<int>();
            //vul het array met vakjes
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    schaakarray[x, y] = new Vakje(kleurvakje);

                    kleurvakje = !kleurvakje;
                }
                kleurvakje = !kleurvakje;
            }

            //voeg schaakstukken aan vakjes toe
            if (variant == "Klassiek")
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x == 2)
                    {
                        kleurstuk = "wit";
                        voorDitStuk = Speler1;
                    }
                    for (int y = 0; y < 8; y++)
                    {
                        if (x == 0 || x == 7)
                        {
                            if (y == 0 || y == 7)
                            {
                                schaakarray[x, y].schaakstuk = new Toren(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                    if (Spel._SpelMode == "Singleplayer")
                                    {
                                        Spel._computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 1 || y == 6)
                            {
                                schaakarray[x, y].schaakstuk = new Paard(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                    if (Spel._SpelMode == "Singleplayer")
                                    {
                                        Spel._computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 2 || y == 5)
                            {
                                schaakarray[x, y].schaakstuk = new Loper(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                    if (Spel._SpelMode == "Singleplayer")
                                    {
                                        Spel._computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 3)
                            {
                                schaakarray[x, y].schaakstuk = new Dame(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                    if (Spel._SpelMode == "Singleplayer")
                                    {
                                        Spel._computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 4)
                            {
                                schaakarray[x, y].schaakstuk = new Koning(kleurstuk, schaakarray[x, y], voorDitStuk);

                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                    Spel._Speler1.Koning = schaakarray[x, y].schaakstuk as Koning;

                                }
                                else
                                {
                                    aantal2++;
                                    if (Spel._SpelMode == "Singleplayer")
                                    {
                                        Spel._computerSpeler.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                    else
                                    {
                                        Spel._Speler2.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                }
                            }
                        }
                        else if (x == 1 || x == 6)
                        {
                            schaakarray[x, y].schaakstuk = new Pion(kleurstuk, schaakarray[x, y], voorDitStuk);
                            if (kleurstuk == "wit")
                            {
                                aantal1++;
                            }
                            else
                            {
                                aantal2++;
                                if (Spel._SpelMode == "Singleplayer")
                                {
                                    Spel._computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                }
                            }
                        }
                    }
                }
            }
            else if (variant == "Chess960")
            {
                int aantallopers = 0;
                for (int x = 0; x < 8; x++)
                {
                    if (x == 2)
                    {
                        kleurstuk = "wit";
                        voorDitStuk = Speler1;
                    }
                    for (int y = 0; y < 8; y++)
                    {
                        if (x == 0 || x == 7)
                        {
                            if (y == array[0] || y == array[1])
                            {
                                schaakarray[x, y].schaakstuk = new Toren(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                }
                            }

                            else if (y == array[2] || y == array[3])
                            {
                                schaakarray[x, y].schaakstuk = new Paard(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                }
                            }

                            else if (y == array[4] || y == array[5])
                            {
                                if (array[4] % 2 == 0 && array[5] % 2 == 0)
                                {
                                    int aantalloops = 0;
                                    foreach (int ywaarde in array)
                                    {
                                        aantalloops++;
                                        if (array[aantalloops] % 2 == 1)
                                        {
                                            int temp = array[4];
                                            array[4] = array[aantalloops];
                                            array[aantalloops] = temp;

                                        }
                                        break;
                                    }
                                }
                                else if (array[4] % 2 == 1 && array[5] % 2 == 1)
                                {
                                    int aantalloops = 0;
                                    foreach (int ywaarde in array)
                                    {
                                        aantalloops++;
                                        if (array[aantalloops] % 2 == 0)
                                        {
                                            int temp = array[4];
                                            array[4] = array[aantalloops];
                                            array[aantalloops] = temp;

                                        }
                                        break;
                                    }
                                }
                                else if ((array[4] % 2 == 1 && array[5] % 2 == 0) || (array[4] % 2 == 0 && array[5] % 2 == 1))
                                {
                                    aantallopers++;
                                    schaakarray[x, y].schaakstuk = new Loper(kleurstuk, schaakarray[x, y], voorDitStuk);
                                    if (kleurstuk == "wit")
                                    {
                                        aantal1++;
                                    }
                                    else
                                    {
                                        aantal2++;
                                    }
                                }
                            }

                            else if (y == array[6])
                            {
                                schaakarray[x, y].schaakstuk = new Dame(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {

                                    aantal1++;
                                }
                                else
                                {

                                    aantal2++;
                                }
                            }

                            else if (y == array[7])
                            {
                                schaakarray[x, y].schaakstuk = new Koning(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    Spel._Speler1.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    aantal1++;
                                }
                                else
                                {
                                    if (Spel._SpelMode == "Singleplayer")
                                    {
                                        Spel._computerSpeler.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                    else
                                    {
                                        Spel._Speler2.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                    aantal2++;
                                }
                            }
                        }
                        else if (x == 1 || x == 6)
                        {
                            schaakarray[x, y].schaakstuk = new Pion(kleurstuk, schaakarray[x, y], voorDitStuk);
                            if (kleurstuk == "wit")
                            {
                                aantal1++;
                            }
                            else
                            {
                                aantal2++;
                            }
                        }
                    }
                }
            }

            // Geef buren aan de vakjes
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (x != 0)
                    {
                        schaakarray[x, y].buurNoord = schaakarray[x - 1, y];
                    }
                    if (x != 7)
                    {
                        schaakarray[x, y].buurZuid = schaakarray[x + 1, y];
                    }
                    if (y != 7)
                    {
                        schaakarray[x, y].buurOost = schaakarray[x, y + 1];
                    }
                    if (y != 0)
                    {
                        schaakarray[x, y].buurWest = schaakarray[x, y - 1];
                    }
                    if (x != 0 && y != 0)
                    {
                        schaakarray[x, y].buurNoordwest = schaakarray[x - 1, y - 1];
                    }
                    if (x != 7 && y != 7)
                    {
                        schaakarray[x, y].buurZuidoost = schaakarray[x + 1, y + 1];
                    }
                    if (x != 7 && y != 0)
                    {
                        schaakarray[x, y].buurZuidwest = schaakarray[x + 1, y - 1];
                    }
                    if (x != 0 && y != 7)
                    {
                        schaakarray[x, y].buurNoordoost = schaakarray[x - 1, y + 1];
                    }
                }
            }
        }

        private void CheckRemise()
        {
            throw new System.NotImplementedException();
        }

        public bool CheckSchaak(Koning koning)
        {
            bool mogelijkloop = false;
            staatschaak = false;
            Schaakstuk zetSchaak = null;
            Vakje vorige = koning.vakje;

            //kijk of er noord van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurNoord == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurNoord.schaakstuk is Toren || vorige.buurNoord.schaakstuk is Dame)
                {
                    if (vorige.buurNoord.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoord.schaakstuk;
                        richting = "noord";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurNoord.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoord;
            }
            mogelijkloop = false;
            vorige = koning.vakje;

            //kijk of er zuid van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurZuid == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurZuid.schaakstuk is Toren || vorige.buurZuid.schaakstuk is Dame)
                {
                    if (vorige.buurZuid.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuid.schaakstuk;
                        richting = "zuid";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurZuid.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurZuid;
            }
            mogelijkloop = false;
            vorige = koning.vakje;

            //kijk of er oost van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurOost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurOost.schaakstuk is Toren || vorige.buurOost.schaakstuk is Dame)
                {
                    if (vorige.buurOost.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurOost.schaakstuk;
                        richting = "oost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurOost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurOost;
            }
            mogelijkloop = false;
            vorige = koning.vakje;

            //kijk of er west van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurWest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurWest.schaakstuk is Toren || vorige.buurWest.schaakstuk is Dame)
                {
                    if (vorige.buurWest.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurWest.schaakstuk;
                        richting = "west";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurWest.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurWest;
            }

            mogelijkloop = false;
            vorige = koning.vakje;

            //kijk of er noordoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordoost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurNoordoost.schaakstuk is Loper || vorige.buurNoordoost.schaakstuk is Dame)
                {
                    if (vorige.buurNoordoost.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoordoost.schaakstuk;
                        richting = "noordoost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurNoordoost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoordoost;
            }
            mogelijkloop = false;
            vorige = koning.vakje;

            //kijk of er zuidoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurZuidoost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurZuidoost.schaakstuk is Loper || vorige.buurZuidoost.schaakstuk is Dame)
                {
                    if (vorige.buurZuidoost.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuidoost.schaakstuk;
                        richting = "zuidoost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurZuidoost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurZuidoost;
            }
            mogelijkloop = false;
            vorige = koning.vakje;

            //kijk of er zuidwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurZuidwest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurZuidwest.schaakstuk is Loper || vorige.buurZuidwest.schaakstuk is Dame)
                {
                    if (vorige.buurZuidwest.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuidwest.schaakstuk;
                        richting = "zuidwest";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurZuidwest.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurZuidwest;
            }
            mogelijkloop = false;
            vorige = koning.vakje;

            //kijk of er noordwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordwest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurNoordwest.schaakstuk is Loper || vorige.buurNoordwest.schaakstuk is Dame)
                {
                    if (vorige.buurNoordwest.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoordwest.schaakstuk;
                        richting = "noordwest";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.buurNoordwest.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoordwest;
            }
            vorige = koning.vakje;

            //kijk of er noord-noordwest een paard staat
            if (vorige.buurNoord != null)
            {
                if (vorige.buurNoord.buurNoordwest != null)
                {
                    if (vorige.buurNoord.buurNoordwest.schaakstuk is Paard && vorige.buurNoord.buurNoordwest.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoord.buurNoordwest.schaakstuk;
                    }
                }
            }
            //kijk of er noord-noordoost een paard staat
            if (vorige.buurNoord != null)
            {
                if (vorige.buurNoord.buurNoordoost != null)
                {
                    if (vorige.buurNoord.buurNoordoost.schaakstuk is Paard && vorige.buurNoord.buurNoordoost.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoord.buurNoordoost.schaakstuk;
                    }
                }
            }
            //kijk of er oost-noordoost een paard staat
            if (vorige.buurOost != null)
            {
                if (vorige.buurOost.buurNoordoost != null)
                {
                    if (vorige.buurOost.buurNoordoost.schaakstuk is Paard && vorige.buurOost.buurNoordoost.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurOost.buurNoordoost.schaakstuk;
                    }
                }
            }
            //kijk of er oost-zuidoost een paard staat
            if (vorige.buurOost != null)
            {
                if (vorige.buurOost.buurZuidoost != null)
                {
                    if (vorige.buurOost.buurZuidoost.schaakstuk is Paard && vorige.buurOost.buurZuidoost.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurOost.buurZuidoost.schaakstuk;
                    }
                }
            }
            //kijk of er zuid-zuidoost een paard staat
            if (vorige.buurZuid != null)
            {
                if (vorige.buurZuid.buurZuidoost != null)
                {
                    if (vorige.buurZuid.buurZuidoost.schaakstuk is Paard && vorige.buurZuid.buurZuidoost.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuid.buurZuidoost.schaakstuk;
                    }
                }
            }
            //kijk of er zuid-zuidwest een paard staat
            if (vorige.buurZuid != null)
            {
                if (vorige.buurZuid.buurZuidwest != null)
                {
                    if (vorige.buurZuid.buurZuidwest.schaakstuk is Paard && vorige.buurZuid.buurZuidwest.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuid.buurZuidwest.schaakstuk;
                    }
                }
            }
            //kijk of er west-noordwest een paard staat
            if (vorige.buurWest != null)
            {
                if (vorige.buurWest.buurNoordwest != null)
                {
                    if (vorige.buurWest.buurNoordwest.schaakstuk is Paard && vorige.buurWest.buurNoordwest.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurWest.buurNoordwest.schaakstuk;
                    }
                }
            }
            //kijk of er west-zuidwest een paard staat
            if (vorige.buurWest != null)
            {
                if (vorige.buurWest.buurZuidwest != null)
                {
                    if (vorige.buurWest.buurZuidwest.schaakstuk is Paard && vorige.buurWest.buurZuidwest.schaakstuk.kleur != koning.kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurWest.buurZuidwest.schaakstuk;
                    }
                }
            }
            //kijk of er noord een koning staat
            if (vorige.buurNoord != null)
            {
                if (vorige.buurNoord.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            //kijk of er oost een koning staat
            if (vorige.buurOost != null)
            {
                if (vorige.buurOost.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            //kijk of er zuid een koning staat
            if (vorige.buurZuid != null)
            {
                if (vorige.buurZuid.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            //kijk of er west een koning staat
            if (vorige.buurWest != null)
            {
                if (vorige.buurWest.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            //kijk of er noordoost een koning staat
            if (vorige.buurNoordoost != null)
            {
                if (vorige.buurNoordoost.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            //kijk of er noordwest een koning staat
            if (vorige.buurNoordwest != null)
            {
                if (vorige.buurNoordwest.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            //kijk of er zuidoost een koning staat
            if (vorige.buurZuidoost != null)
            {
                if (vorige.buurZuidoost.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            //kijk of er zuidwest een koning staat
            if (vorige.buurZuidwest != null)
            {
                if (vorige.buurZuidwest.schaakstuk is Koning)
                {
                    staatschaak = true;
                }
            }
            if (pionvoormat == false)
            {
                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (koning.kleur == "wit")
                {
                    if (vorige.buurNoordoost != null)
                    {
                        if (vorige.buurNoordoost.schaakstuk is Pion && vorige.buurNoordoost.schaakstuk.kleur == "zwart")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurNoordoost.schaakstuk;
                        }
                    }
                    if (vorige.buurNoordwest != null)
                    {
                        if (vorige.buurNoordwest.schaakstuk is Pion && vorige.buurNoordwest.schaakstuk.kleur == "zwart")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurNoordwest.schaakstuk;
                        }
                    }
                }
                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (koning.kleur == "zwart")
                {
                    if (vorige.buurZuidoost != null)
                    {
                        if (vorige.buurZuidoost.schaakstuk is Pion && vorige.buurZuidoost.schaakstuk.kleur == "wit")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurZuidoost.schaakstuk;
                        }
                    }
                    if (vorige.buurZuidwest != null)
                    {
                        if (vorige.buurZuidwest.schaakstuk is Pion && vorige.buurZuidwest.schaakstuk.kleur == "wit")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurZuidwest.schaakstuk;
                        }
                    }
                }
            }
            else
            {
                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (koning.kleur == "wit")
                {
                    if (vorige.buurNoord != null)
                    {
                        if (vorige.buurNoord.schaakstuk is Pion && vorige.buurNoord.schaakstuk.kleur == "zwart")
                        {
                            staatschaak = true;                            
                        }

                        if (vorige.buurNoord.buurNoord != null)
                        {
                            if (vorige.buurNoord.buurNoord.schaakstuk is Pion && vorige.buurNoord.buurNoord.schaakstuk.kleur == "zwart" )
                            {
                                if ((vorige.buurNoord.buurNoord.schaakstuk as Pion)._eersteZet == true)
                                {
                                    staatschaak = true;
                                }                                
                            }
                        }
                    }                    
                }
                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (koning.kleur == "zwart")
                {
                    if (vorige.buurZuid != null)
                    {
                        if (vorige.buurZuid.schaakstuk is Pion && vorige.buurZuid.schaakstuk.kleur == "wit")
                        {
                            staatschaak = true;
                        }

                        if (vorige.buurZuid.buurZuid != null)
                        {
                            if (vorige.buurZuid.buurZuid.schaakstuk is Pion && vorige.buurZuid.buurZuid.schaakstuk.kleur == "wit")
                            {
                                if ((vorige.buurZuid.buurZuid.schaakstuk as Pion)._eersteZet == true)
                                {
                                    staatschaak = true;
                                }
                            }
                        }
                    }
                }
            }
            schaakGezet = zetSchaak;
            return staatschaak;
        }

        public bool CheckMat(Koning koning)
        {
            bool mat = true;
            bool mogelijk = false;

            Schaakstuk bewaar = null;
            Vakje beginvakje = koning.vakje;

            //bekijk of de koning schaak staat als hij naar noord zou bewegen
            if (beginvakje.buurNoord != null)
            {
                if (beginvakje.buurNoord.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurNoord.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }

                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurNoord.schaakstuk;
                    koning.vakje = beginvakje.buurNoord;
                    beginvakje.buurNoord.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurNoord.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar oost zou bewegen
            if (beginvakje.buurOost != null)
            {
                if (beginvakje.buurOost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurOost.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurOost.schaakstuk;
                    koning.vakje = beginvakje.buurOost;
                    beginvakje.buurOost.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurOost.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuid zou bewegen
            if (beginvakje.buurZuid != null)
            {
                if (beginvakje.buurZuid.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurZuid.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurZuid.schaakstuk;
                    koning.vakje = beginvakje.buurZuid;
                    beginvakje.buurZuid.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurZuid.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar west zou bewegen
            if (beginvakje.buurWest != null)
            {
                if (beginvakje.buurWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurWest.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurWest.schaakstuk;
                    koning.vakje = beginvakje.buurWest;
                    beginvakje.buurWest.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurWest.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
            }
            //bekijk of de koning schaak staat als hij naar noordoost zou bewegen
            if (beginvakje.buurNoordoost != null)
            {
                if (beginvakje.buurNoordoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurNoordoost.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurNoordoost.schaakstuk;
                    koning.vakje = beginvakje.buurNoordoost;
                    beginvakje.buurNoordoost.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurNoordoost.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordwest zou bewegen
            if (beginvakje.buurNoordwest != null)
            {
                if (beginvakje.buurNoordwest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurNoordwest.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurNoordwest.schaakstuk;
                    koning.vakje = beginvakje.buurNoordwest;
                    beginvakje.buurNoordwest.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurNoordwest.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidoost zou bewegen
            if (beginvakje.buurZuidoost != null)
            {
                if (beginvakje.buurZuidoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurZuidoost.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurZuidoost.schaakstuk;
                    koning.vakje = beginvakje.buurZuidoost;
                    beginvakje.buurZuidoost.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurZuidoost.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidwest zou bewegen
            if (beginvakje.buurZuidwest != null)
            {
                if (beginvakje.buurZuidwest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (beginvakje.buurZuidwest.schaakstuk.kleur != koning.kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bewaar = beginvakje.buurZuidwest.schaakstuk;
                    koning.vakje = beginvakje.buurZuidwest;
                    beginvakje.buurZuidwest.schaakstuk = koning;
                    beginvakje.schaakstuk = null;

                    bool checkschaak = CheckSchaak(koning);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                    koning.vakje = beginvakje;
                    beginvakje.buurZuidwest.schaakstuk = bewaar;
                    beginvakje.schaakstuk = koning;
                }
                mogelijk = false;
            }
            schaakGezet = null;
            richting = null;
            CheckSchaak(koning);
            if (schaakGezet != null)
            {
                Schaakstuk bewaarstuk = schaakGezet;
                Vakje bewaarvakje = schaakGezet.vakje;

                koning.vakje = bewaarvakje;
                bewaarvakje.schaakstuk = koning;
                beginvakje.schaakstuk = null;
                if (koning.kleur == "wit")
                {
                    koning.kleur = "zwart";
                }
                else
                {
                    koning.kleur = "wit";
                }

                bool checkschaak = CheckSchaak(koning);
                if (checkschaak == true)
                {
                    mat = false;
                }
                koning.vakje = beginvakje;
                bewaarvakje.schaakstuk = bewaarstuk;
                bewaarstuk.vakje = bewaarvakje;
                beginvakje.schaakstuk = koning;
                Vakje vorige = beginvakje;
                pionvoormat = true;
                if (mat == true && richting != null)
                {
                    if (richting == "noord")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurNoord.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurNoord;
                                vorige.buurNoord.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurNoord;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    else if (richting == "oost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurOost.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurOost;
                                vorige.buurOost.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurOost;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    else if (richting == "zuid")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurZuid.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurZuid;
                                vorige.buurZuid.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurZuid;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    else if (richting == "west")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurWest.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurWest;
                                vorige.buurWest.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurWest;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    else if (richting == "noordoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurNoordoost.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurNoordoost;
                                vorige.buurNoordoost.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurNoordoost;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    else if (richting == "noordwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurNoordwest.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurNoordwest;
                                vorige.buurNoordwest.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurNoordwest;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    else if (richting == "zuidoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurZuidoost.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurZuidoost;
                                vorige.buurZuidoost.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurZuidoost;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    else if (richting == "zuidwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurZuidwest.schaakstuk == null)
                            {
                                koning.vakje = vorige.buurZuidwest;
                                vorige.buurZuidwest.schaakstuk = koning;
                                vorige.schaakstuk = null;
                                checkschaak = CheckSchaak(koning);
                                vorige = vorige.buurZuidwest;
                                if (checkschaak == true)
                                {
                                    mat = false;
                                    mogelijk = true;
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                        }
                    }
                    koning.vakje = beginvakje;
                    beginvakje.schaakstuk = koning;
                    vorige.schaakstuk = null;
                    
                }
                if (koning.kleur == "wit")
                {
                    koning.kleur = "zwart";
                }
                else
                {
                    koning.kleur = "wit";
                }

            }
            pionvoormat = false;
            return mat;
        }
        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}

