using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Schaakbord
    {
        public Vakje[,] schaakarray = new Vakje[8, 8];
        public Schaakbord()
        {
            bool kleurvakje = false;            //zwart of wit
            string kleurstuk = "zwart";

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
                            schaakarray[x, y].schaakstuk = new Toren(kleurstuk);
                        }

                        else if (y == 1 || y == 6)
                        {
                            schaakarray[x, y].schaakstuk = new Paard(kleurstuk);
                        }

                        else if (y == 2 || y == 5)
                        {
                            schaakarray[x, y].schaakstuk = new Loper(kleurstuk);
                        }

                        else if (y == 3)
                        {
                            schaakarray[x, y].schaakstuk = new Dame(kleurstuk);
                        }

                        else if (y == 4)
                        {
                            schaakarray[x, y].schaakstuk = new Koning(kleurstuk);
                        }
                    }

                    else if (x == 1 || x == 6)
                    {
                        schaakarray[x, y].schaakstuk = new Pion(kleurstuk);
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

