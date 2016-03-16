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
        public Vakje[,] schaakarray = new Vakje[8, 8];
        public int aantal1 { get; set; }
        public int aantal2 { get; set; }
        public string kleurstuk { get; set; }
        public string variant { get; set; }
        public Schaakbord(string _Variant)
        {
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

        private void CheckSchaak()
        {
            throw new System.NotImplementedException();
        }

        private void CheckMat()
        {
            throw new System.NotImplementedException();
        }
    }
}

