using System;
using System.Collections.Generic;
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
        private int aantal1 { get; set; }                   //Het aantal schaakstukken wordt ingesteld voor wit
        private int aantal2 { get; set; }                   //Het aantal schaakstukken wordt ingesteld voor zwart
        private bool staatschaak { get; set; }              //Staat er iemand schaak?
        private string kleurstuk { get; set; }              //De kleur van het stuk
        private string variant { get; set; }                //Klassiek of Chess960

        public Schaakbord(string _Variant)                  
        {
            schaakarray = new Vakje[8, 8];
            variant = _Variant;
            bool kleurvakje = false; //zwart of wit
            kleurstuk = "zwart";
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
            if(variant == "Klassiek")
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x == 2)
                    {
                        kleurstuk = "wit";
                    }
                    for (int y = 0; y < 8; y++)
                    {
                        if (x == 0 || x == 7)
                        {
                            if (y == 0 || y == 7)
                            {
                                schaakarray[x, y].schaakstuk = new Toren(kleurstuk, schaakarray[x, y]);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                }
                            }

                            else if (y == 1 || y == 6)
                            {
                                schaakarray[x, y].schaakstuk = new Paard(kleurstuk, schaakarray[x, y]);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                }
                            }

                            else if (y == 2 || y == 5)
                            {
                                schaakarray[x, y].schaakstuk = new Loper(kleurstuk, schaakarray[x, y]);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                }
                            }

                            else if (y == 3)
                            {
                                schaakarray[x, y].schaakstuk = new Dame(kleurstuk, schaakarray[x, y]);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                }
                            }

                            else if (y == 4)
                            {
                                schaakarray[x, y].schaakstuk = new Koning(kleurstuk, schaakarray[x, y]);
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
                        else if (x == 1 || x == 6)
                        {
                            schaakarray[x, y].schaakstuk = new Pion(kleurstuk, schaakarray[x, y]);
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
            else if (variant == "Chess960")
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x == 2)
                    {
                        kleurstuk = "wit";
                    }
                    for (int y = 0; y < 8; y++)
                    {
                        if (x == 0 || x == 7)
                        {
                            if (y == array[0] || y == array[1])
                            {
                                schaakarray[x, y].schaakstuk = new Toren(kleurstuk, schaakarray[x, y]);
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
                                schaakarray[x, y].schaakstuk = new Paard(kleurstuk, schaakarray[x, y]);
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
                                schaakarray[x, y].schaakstuk = new Loper(kleurstuk, schaakarray[x, y]);
                                if (kleurstuk == "wit")
                                {
                                    aantal1++;
                                }
                                else
                                {
                                    aantal2++;
                                }
                            }

                            else if (y == array[6])
                            {
                                schaakarray[x, y].schaakstuk = new Dame(kleurstuk, schaakarray[x, y]);
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
                                schaakarray[x, y].schaakstuk = new Koning(kleurstuk, schaakarray[x, y]);
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
                        else if (x == 1 || x == 6)
                        {
                            schaakarray[x, y].schaakstuk = new Pion(kleurstuk, schaakarray[x, y]);
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

        private void CheckSchaak(Koning koning)
        {
            bool mogelijkloop = false;
            staatschaak = false;
            Vakje vorige = koning.vakje;

            //kijk of er noord van de koning een toren of dame staat
            while(mogelijkloop == false)
            {
                if (vorige.buurNoord.schaakstuk is Toren || vorige.buurNoord.schaakstuk is Dame)
                {
                    staatschaak = true;
                    mogelijkloop = true;
                }
                else if(vorige.buurNoord == null || vorige.buurNoord.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoord;
            }
            mogelijkloop = false;

            //kijk of er zuid van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurZuid.schaakstuk is Toren || vorige.buurZuid.schaakstuk is Dame)
                {
                    staatschaak = true;
                    mogelijkloop = true;
                }
                else if (vorige.buurZuid == null || vorige.buurZuid.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoord;
            }
            mogelijkloop = false;

            //kijk of er oost van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurOost.schaakstuk is Toren || vorige.buurOost.schaakstuk is Dame)
                {
                    staatschaak = true;
                    mogelijkloop = true;
                }
                else if (vorige.buurOost == null || vorige.buurOost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoord;
            }
            mogelijkloop = false;

            //kijk of er west van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurWest.schaakstuk is Toren || vorige.buurWest.schaakstuk is Dame)
                {
                    staatschaak = true;
                    mogelijkloop = true;
                }
                else if (vorige.buurWest == null || vorige.buurWest.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.buurNoord;
            }

            
        }

        private void CheckMat()
        {
            throw new System.NotImplementedException();
        }
    }
}

