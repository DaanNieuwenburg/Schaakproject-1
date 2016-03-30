using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public static class MSSystemExtenstions
    {
        static bool shuffle = true;
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
        private static Random rng = new Random();
        public static void Shuffle<T>(this T[] array)
        {
            while (shuffle == true)
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
                if (Convert.ToInt32(array[4]) % 2 == 0 && Convert.ToInt32(array[5]) % 2 == 0)
                {
                    shuffle = true;
                }
                else if (Convert.ToInt32(array[4]) % 2 == 1 && Convert.ToInt32(array[5]) % 2 == 1)
                {
                    shuffle = true;
                }
                else if (Convert.ToInt32(array[0]) < Convert.ToInt32(array[7]) && Convert.ToInt32(array[1]) < Convert.ToInt32(array[7]))
                {
                    shuffle = true;
                }
                else if (Convert.ToInt32(array[0]) > Convert.ToInt32(array[7]) && Convert.ToInt32(array[1]) > Convert.ToInt32(array[7]))
                {
                    shuffle = true;
                }
                else if (Convert.ToInt32(array[7]) == 0 || Convert.ToInt32(array[7]) == 7)
                {
                    shuffle = true;
                }
                else
                {
                    shuffle = false;
                }
            }
            shuffle = true;
        }
    }

    public class Schaakbord
    {
        public Vakje[,] schaakarray { get; private set; }   //Een array van vakjes zodat het schaakbord kan worden opgezet
        public Color _kleur { get; private set; }
        private int aantal1 { get; set; }                   //Het aantal schaakstukken wordt ingesteld voor wit
        private int aantal2 { get; set; }                   //Het aantal schaakstukken wordt ingesteld voor zwart
        private bool staatschaak { get; set; }              //Staat er iemand schaak?
        private string variant { get; set; }                //Klassiek of Chess960
        private Schaakstuk schaakGezet { get; set; }        //Het schaakstuk dat de koning schaak heeft gezet
        private string richting { get; set; }               //De richting waar het schaakstuk dat de koning schaak heeft gezet staat
        private bool pionvoormat { get; set; }              //om te kijken of er een pion gezet kan worden tussen de koning en een stuk
        private List<Schaakstuk> Stukvoorkomen { get; set; }


        public Schaakbord(string _Variant, Spel Spel, Speler Speler1, Speler Speler2)
        {
            Stukvoorkomen = new List<Schaakstuk>();
            aantal1 = 16;
            aantal2 = 16;
            schaakarray = new Vakje[8, 8];
            variant = _Variant;
            string kleurstuk;
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
                                if (kleurstuk == "zwart")
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 1 || y == 6)
                            {
                                schaakarray[x, y].schaakstuk = new Paard(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "zwart")
                                {

                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 2 || y == 5)
                            {
                                schaakarray[x, y].schaakstuk = new Loper(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "zwart")
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 3)
                            {
                                schaakarray[x, y].schaakstuk = new Dame(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "zwart")
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                    }
                                }
                            }

                            else if (y == 4)
                            {
                                schaakarray[x, y].schaakstuk = new Koning(kleurstuk, schaakarray[x, y], voorDitStuk);

                                if (kleurstuk == "wit")
                                {
                                    Spel.Speler1.Koning = schaakarray[x, y].schaakstuk as Koning;
                                }
                                else
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.computerSpeler.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                    else
                                    {
                                        Spel.Speler2.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                }
                            }
                        }
                        else if (x == 1 || x == 6)
                        {
                            schaakarray[x, y].schaakstuk = new Pion(kleurstuk, schaakarray[x, y], voorDitStuk);
                            if (kleurstuk == "zwart")
                            {
                                //Speler2.pionnen[y] = schaakarray[x, y].schaakstuk as Pion;
                                if (Spel.SpelMode == "Singleplayer")
                                {
                                    Spel.computerSpeler.nietverplaatstlijst.Add(schaakarray[x, y].schaakstuk.vakje);
                                }
                                else
                                {
                                    Speler2.pionnen[y] = schaakarray[x, y].schaakstuk as Pion;
                                }
                            }
                            else
                            {
                                Speler1.pionnen[y] = schaakarray[x, y].schaakstuk as Pion;
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
                                if (array[0] < array[7] && array[1] < array[7])
                                {

                                }
                                else if (array[0] > array[7] && array[1] > array[7])
                                {
                                    int aantalloops = 0;
                                    foreach (int ywaarde in array)
                                    {
                                        aantalloops++;
                                        if (array[aantalloops] < array[7])
                                        {
                                            int temp = array[0];
                                            array[0] = array[aantalloops];
                                            array[aantalloops] = temp;
                                        }
                                        break;
                                    }
                                }
                                else if ((array[0] < array[7] && array[1] > array[7]) || (array[0] > array[7] && array[1] < array[7]))
                                {
                                    schaakarray[x, y].schaakstuk = new Toren(kleurstuk, schaakarray[x, y], voorDitStuk);
                                }
                            }

                            else if (y == array[2] || y == array[3])
                            {
                                schaakarray[x, y].schaakstuk = new Paard(kleurstuk, schaakarray[x, y], voorDitStuk);
                            }

                            else if (y == array[4] || y == array[5])
                            {
                                aantallopers++;
                                schaakarray[x, y].schaakstuk = new Loper(kleurstuk, schaakarray[x, y], voorDitStuk);
                            }

                            else if (y == array[6])
                            {
                                schaakarray[x, y].schaakstuk = new Dame(kleurstuk, schaakarray[x, y], voorDitStuk);
                            }

                            else if (y == array[7])
                            {
                                schaakarray[x, y].schaakstuk = new Koning(kleurstuk, schaakarray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    Spel.Speler1.Koning = schaakarray[x, y].schaakstuk as Koning;
                                }
                                else
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.computerSpeler.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                    else
                                    {
                                        Spel.Speler2.Koning = schaakarray[x, y].schaakstuk as Koning;
                                    }
                                }

                            }
                        }
                        else if (x == 1 || x == 6)
                        {
                            schaakarray[x, y].schaakstuk = new Pion(kleurstuk, schaakarray[x, y], voorDitStuk);
                            if (kleurstuk == "wit")
                            {
                                Speler1.pionnen[y] = schaakarray[x, y].schaakstuk as Pion;
                            }
                            else
                            {
                                if (Spel.SpelMode == "Singleplayer")
                                {
                                    Spel.computerSpeler.pionnen[y] = schaakarray[x, y].schaakstuk as Pion;
                                }
                                else
                                {
                                    Spel.Speler2.pionnen[y] = schaakarray[x, y].schaakstuk as Pion;
                                }
                                
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

        public bool CheckPat(Koning koning)
        {
            Vakje koningVakje = koning.vakje;
            bool mogelijk = false;
            string kleur = koning.kleur;
            bool pat = true;
            int blokkeert = 0;
            int stillePion = 0;

            //bekijk of de koning schaak staat als hij naar noord zou bewegen
            if (koningVakje.buurNoord != null)
            {
                if (koningVakje.buurNoord.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurNoord.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }

                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurNoord, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar oost zou bewegen
            if (koningVakje.buurOost != null)
            {
                if (koningVakje.buurOost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurOost.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurOost, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuid zou bewegen
            if (koningVakje.buurZuid != null)
            {
                if (koningVakje.buurZuid.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurZuid.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurZuid, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar west zou bewegen
            if (koningVakje.buurWest != null)
            {
                if (koningVakje.buurWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurWest.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurWest, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordoost zou bewegen
            if (koningVakje.buurNoordoost != null)
            {
                if (koningVakje.buurNoordoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurNoordoost.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurNoordoost, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordwest zou bewegen
            if (koningVakje.buurNoordwest != null)
            {
                if (koningVakje.buurNoordwest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurNoordwest.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurNoordwest, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }

                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidoost zou bewegen
            if (koningVakje.buurZuidoost != null)
            {
                if (koningVakje.buurZuidoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurZuidoost.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurZuidoost, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidwest zou bewegen
            if (koningVakje.buurZuidwest != null)
            {
                if (koningVakje.buurZuidwest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurZuidwest.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurZuidwest, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }

            bool loop = false;
            bool juisteKleur = false;
            Vakje vorige = koningVakje;

            //voor noord
            while (loop == false)
            {
                if (vorige.buurNoord == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurNoord.schaakstuk != null)
                    {
                        if (vorige.buurNoord.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurNoord.schaakstuk is Toren || vorige.buurNoord.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurNoord;
                }
            }
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor oost
            while (loop == false)
            {
                if (vorige.buurOost == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurOost.schaakstuk != null)
                    {
                        if (vorige.buurOost.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurOost.schaakstuk is Toren || vorige.buurOost.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurOost;
                }
            }
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor zuid
            while (loop == false)
            {
                if (vorige.buurZuid == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurZuid.schaakstuk != null)
                    {
                        if (vorige.buurZuid.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurZuid.schaakstuk is Toren || vorige.buurZuid.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurZuid;
                }
            }
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor west
            while (loop == false)
            {
                if (vorige.buurWest == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurWest.schaakstuk != null)
                    {
                        if (vorige.buurWest.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurWest.schaakstuk is Toren || vorige.buurWest.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurWest;
                }
            }
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor noordoost
            while (loop == false)
            {
                if (vorige.buurNoordoost == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurNoordoost.schaakstuk != null)
                    {
                        if (vorige.buurNoordoost.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurNoordoost.schaakstuk is Loper || vorige.buurNoordoost.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurNoordoost;
                }
            }
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor noordwest
            while (loop == false)
            {
                if (vorige.buurNoordwest == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurNoordwest.schaakstuk != null)
                    {
                        if (vorige.buurNoordwest.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurNoordwest.schaakstuk is Loper || vorige.buurNoordwest.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurNoordwest;
                }
            }
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor zuidoost
            while (loop == false)
            {
                if (vorige.buurZuidoost == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurZuidoost.schaakstuk != null)
                    {
                        if (vorige.buurZuidoost.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurZuidoost.schaakstuk is Loper || vorige.buurZuidoost.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurZuidoost;
                }
            }
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor zuidwest
            while (loop == false)
            {
                if (vorige.buurZuidwest == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.buurZuidwest.schaakstuk != null)
                    {
                        if (vorige.buurZuidwest.schaakstuk.kleur == koning.kleur)
                        {
                            if (juisteKleur == false)
                            {
                                juisteKleur = true;
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.buurZuidwest.schaakstuk is Loper || vorige.buurZuidwest.schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.buurZuidwest;
                }
            }
            Pion bekijk;
            bool kanVerplaatsen = false;
            for (int i = 0; i < 8; i++)
            {
                bekijk = koning.speler.pionnen[i];
                if (bekijk.geslagen == false)
                {
                    if (bekijk.kleur == "wit")
                    {
                        if (bekijk.vakje.buurNoord != null && bekijk.vakje.buurNoord.schaakstuk == null)
                        {
                            kanVerplaatsen = true;
                        }
                        else if (bekijk.vakje.buurNoordoost != null && bekijk.vakje.buurNoordoost.schaakstuk != null)
                        {
                            kanVerplaatsen = true;
                        }
                        else if (bekijk.vakje.buurNoordwest != null && bekijk.vakje.buurNoordwest.schaakstuk != null)
                        {
                            kanVerplaatsen = true;
                        }
                    }
                    else
                    {
                        if (bekijk.vakje.buurZuid != null && bekijk.vakje.buurZuid.schaakstuk == null)
                        {
                            kanVerplaatsen = true;
                        }
                        else if (bekijk.vakje.buurZuidoost != null && bekijk.vakje.buurZuidoost.schaakstuk != null)
                        {
                            kanVerplaatsen = true;
                        }
                        else if (bekijk.vakje.buurZuidwest != null && bekijk.vakje.buurZuidwest.schaakstuk != null)
                        {
                            kanVerplaatsen = true;
                        }
                    }
                    if (kanVerplaatsen == false)
                    {
                        stillePion++;
                    }
                    kanVerplaatsen = false;
                }

            }
            if (koning.speler.aantalstukken[5] > 1 + blokkeert + stillePion)
            {
                pat = false;
            }

            return pat;
        }

        public bool CheckSchaak(Vakje ditvakje, string kleur)
        {
            Stukvoorkomen.Clear();
            bool mogelijkloop = false;
            staatschaak = false;
            Schaakstuk zetSchaak = null;
            Vakje vorige = ditvakje;

            //kijk of er noord van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurNoord == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurNoord.schaakstuk is Toren || vorige.buurNoord.schaakstuk is Dame)
                {
                    if (vorige.buurNoord.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoord.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er zuid van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurZuid == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurZuid.schaakstuk is Toren || vorige.buurZuid.schaakstuk is Dame)
                {
                    if (vorige.buurZuid.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuid.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er oost van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurOost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurOost.schaakstuk is Toren || vorige.buurOost.schaakstuk is Dame)
                {
                    if (vorige.buurOost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurOost.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er west van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurWest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurWest.schaakstuk is Toren || vorige.buurWest.schaakstuk is Dame)
                {
                    if (vorige.buurWest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurWest.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er noordoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordoost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurNoordoost.schaakstuk is Loper || vorige.buurNoordoost.schaakstuk is Dame)
                {
                    if (vorige.buurNoordoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoordoost.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er zuidoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurZuidoost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurZuidoost.schaakstuk is Loper || vorige.buurZuidoost.schaakstuk is Dame)
                {
                    if (vorige.buurZuidoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuidoost.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er zuidwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurZuidwest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurZuidwest.schaakstuk is Loper || vorige.buurZuidwest.schaakstuk is Dame)
                {
                    if (vorige.buurZuidwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuidwest.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er noordwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.buurNoordwest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.buurNoordwest.schaakstuk is Loper || vorige.buurNoordwest.schaakstuk is Dame)
                {
                    if (vorige.buurNoordwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoordwest.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
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
            vorige = ditvakje;

            //kijk of er noord-noordwest een paard staat
            if (vorige.buurNoord != null)
            {
                if (vorige.buurNoord.buurNoordwest != null)
                {
                    if (vorige.buurNoord.buurNoordwest.schaakstuk is Paard && vorige.buurNoord.buurNoordwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoord.buurNoordwest.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er noord-noordoost een paard staat
            if (vorige.buurNoord != null)
            {
                if (vorige.buurNoord.buurNoordoost != null)
                {
                    if (vorige.buurNoord.buurNoordoost.schaakstuk is Paard && vorige.buurNoord.buurNoordoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurNoord.buurNoordoost.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er oost-noordoost een paard staat
            if (vorige.buurOost != null)
            {
                if (vorige.buurOost.buurNoordoost != null)
                {
                    if (vorige.buurOost.buurNoordoost.schaakstuk is Paard && vorige.buurOost.buurNoordoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurOost.buurNoordoost.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er oost-zuidoost een paard staat
            if (vorige.buurOost != null)
            {
                if (vorige.buurOost.buurZuidoost != null)
                {
                    if (vorige.buurOost.buurZuidoost.schaakstuk is Paard && vorige.buurOost.buurZuidoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurOost.buurZuidoost.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er zuid-zuidoost een paard staat
            if (vorige.buurZuid != null)
            {
                if (vorige.buurZuid.buurZuidoost != null)
                {
                    if (vorige.buurZuid.buurZuidoost.schaakstuk is Paard && vorige.buurZuid.buurZuidoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuid.buurZuidoost.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er zuid-zuidwest een paard staat
            if (vorige.buurZuid != null)
            {
                if (vorige.buurZuid.buurZuidwest != null)
                {
                    if (vorige.buurZuid.buurZuidwest.schaakstuk is Paard && vorige.buurZuid.buurZuidwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurZuid.buurZuidwest.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er west-noordwest een paard staat
            if (vorige.buurWest != null)
            {
                if (vorige.buurWest.buurNoordwest != null)
                {
                    if (vorige.buurWest.buurNoordwest.schaakstuk is Paard && vorige.buurWest.buurNoordwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurWest.buurNoordwest.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er west-zuidwest een paard staat
            if (vorige.buurWest != null)
            {
                if (vorige.buurWest.buurZuidwest != null)
                {
                    if (vorige.buurWest.buurZuidwest.schaakstuk is Paard && vorige.buurWest.buurZuidwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        zetSchaak = vorige.buurWest.buurZuidwest.schaakstuk;
                        Stukvoorkomen.Add(zetSchaak);
                    }
                }
            }
            if (pionvoormat == false)
            {
                //kijk of er noord een koning staat
                if (vorige.buurNoord != null)
                {
                    if (vorige.buurNoord.schaakstuk is Koning && vorige.buurNoord.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurNoord.schaakstuk);
                    }
                }
                //kijk of er oost een koning staat
                if (vorige.buurOost != null)
                {
                    if (vorige.buurOost.schaakstuk is Koning && vorige.buurOost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurOost.schaakstuk);
                    }
                }
                //kijk of er zuid een koning staat
                if (vorige.buurZuid != null)
                {
                    if (vorige.buurZuid.schaakstuk is Koning && vorige.buurZuid.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurZuid.schaakstuk);
                    }
                }
                //kijk of er west een koning staat
                if (vorige.buurWest != null)
                {
                    if (vorige.buurWest.schaakstuk is Koning && vorige.buurWest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurWest.schaakstuk);
                    }
                }
                //kijk of er noordoost een koning staat
                if (vorige.buurNoordoost != null)
                {
                    if (vorige.buurNoordoost.schaakstuk is Koning && vorige.buurNoordoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurNoordoost.schaakstuk);
                    }
                }
                //kijk of er noordwest een koning staat
                if (vorige.buurNoordwest != null)
                {
                    if (vorige.buurNoordwest.schaakstuk is Koning && vorige.buurNoordwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurNoordwest.schaakstuk);
                    }
                }
                //kijk of er zuidoost een koning staat
                if (vorige.buurZuidoost != null)
                {
                    if (vorige.buurZuidoost.schaakstuk is Koning && vorige.buurZuidoost.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurZuidoost.schaakstuk);
                    }
                }
                //kijk of er zuidwest een koning staat
                if (vorige.buurZuidwest != null)
                {
                    if (vorige.buurZuidwest.schaakstuk is Koning && vorige.buurZuidwest.schaakstuk.kleur != kleur)
                    {
                        staatschaak = true;
                        Stukvoorkomen.Add(vorige.buurZuidwest.schaakstuk);
                    }
                }

                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (kleur == "wit")
                {
                    if (vorige.buurNoordoost != null)
                    {
                        if (vorige.buurNoordoost.schaakstuk is Pion && vorige.buurNoordoost.schaakstuk.kleur == "zwart")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurNoordoost.schaakstuk;
                            Stukvoorkomen.Add(zetSchaak);
                        }
                    }
                    if (vorige.buurNoordwest != null)
                    {
                        if (vorige.buurNoordwest.schaakstuk is Pion && vorige.buurNoordwest.schaakstuk.kleur == "zwart")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurNoordwest.schaakstuk;
                            Stukvoorkomen.Add(zetSchaak);
                        }
                    }
                }
                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (kleur == "zwart")
                {
                    if (vorige.buurZuidoost != null)
                    {
                        if (vorige.buurZuidoost.schaakstuk is Pion && vorige.buurZuidoost.schaakstuk.kleur == "wit")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurZuidoost.schaakstuk;
                            Stukvoorkomen.Add(zetSchaak);
                        }
                    }
                    if (vorige.buurZuidwest != null)
                    {
                        if (vorige.buurZuidwest.schaakstuk is Pion && vorige.buurZuidwest.schaakstuk.kleur == "wit")
                        {
                            staatschaak = true;
                            zetSchaak = vorige.buurZuidwest.schaakstuk;
                            Stukvoorkomen.Add(zetSchaak);
                        }
                    }
                }
            }
            else
            {
                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (kleur == "wit")
                {
                    if (vorige.buurNoord != null)
                    {
                        if (vorige.buurNoord.schaakstuk is Pion && vorige.buurNoord.schaakstuk.kleur == "zwart")
                        {
                            staatschaak = true;
                            Stukvoorkomen.Add(vorige.buurNoord.schaakstuk);
                        }

                        if (vorige.buurNoord.buurNoord != null)
                        {
                            if (vorige.buurNoord.buurNoord.schaakstuk is Pion && vorige.buurNoord.buurNoord.schaakstuk.kleur == "zwart")
                            {
                                if ((vorige.buurNoord.buurNoord.schaakstuk as Pion).eersteZet == true)
                                {
                                    staatschaak = true;
                                    Stukvoorkomen.Add(vorige.buurNoord.buurNoord.schaakstuk);
                                }
                            }
                        }
                    }
                }

                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (kleur == "zwart")
                {
                    if (vorige.buurZuid != null)
                    {
                        if (vorige.buurZuid.schaakstuk is Pion && vorige.buurZuid.schaakstuk.kleur == "wit")
                        {
                            staatschaak = true;
                            Stukvoorkomen.Add(vorige.buurZuid.schaakstuk);
                        }

                        if (vorige.buurZuid.buurZuid != null)
                        {
                            if (vorige.buurZuid.buurZuid.schaakstuk is Pion && vorige.buurZuid.buurZuid.schaakstuk.kleur == "wit")
                            {
                                if ((vorige.buurZuid.buurZuid.schaakstuk as Pion).eersteZet == true)
                                {
                                    staatschaak = true;
                                    Stukvoorkomen.Add(vorige.buurZuid.buurZuid.schaakstuk);
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

            string kleur = koning.kleur;
            Vakje koningVakje = koning.vakje;

            //bekijk of de koning schaak staat als hij naar noord zou bewegen
            if (koningVakje.buurNoord != null)
            {
                if (koningVakje.buurNoord.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurNoord.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }

                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurNoord, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar oost zou bewegen
            if (koningVakje.buurOost != null)
            {
                if (koningVakje.buurOost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurOost.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurOost, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuid zou bewegen
            if (koningVakje.buurZuid != null)
            {
                if (koningVakje.buurZuid.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurZuid.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurZuid, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar west zou bewegen
            if (koningVakje.buurWest != null)
            {
                if (koningVakje.buurWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurWest.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurWest, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordoost zou bewegen
            if (koningVakje.buurNoordoost != null)
            {
                if (koningVakje.buurNoordoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurNoordoost.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurNoordoost, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordwest zou bewegen
            if (koningVakje.buurNoordwest != null)
            {
                if (koningVakje.buurNoordwest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurNoordwest.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurNoordwest, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidoost zou bewegen
            if (koningVakje.buurZuidoost != null)
            {
                if (koningVakje.buurZuidoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurZuidoost.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurZuidoost, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidwest zou bewegen
            if (koningVakje.buurZuidwest != null)
            {
                if (koningVakje.buurZuidwest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.buurZuidwest.schaakstuk.kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.buurZuidwest, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }

            schaakGezet = null;
            richting = null;

            CheckSchaak(koning.vakje, koning.kleur);
            if (schaakGezet != null)
            {
                if (kleur == "wit")
                {
                    kleur = "zwart";
                }
                else
                {
                    kleur = "wit";
                }

                bool checkschaak = CheckSchaak(schaakGezet.vakje, kleur);
                if (checkschaak == true)
                {
                    bool magnietslaan = false;
                    List<Schaakstuk> Lijst = Stukvoorkomen;
                    for (int i = 0; i < Lijst.Count; i++)
                    {

                        Schaakstuk temp = Lijst[i];
                        temp.vakje.schaakstuk = null;
                        bool check = CheckSchaak(koning.vakje, koning.kleur);
                        if (check == false)
                        {
                            magnietslaan = true;
                        }
                        temp.vakje.schaakstuk = temp;

                    }
                    if (magnietslaan == true)
                    {
                        mat = false;
                    }
                }

                Vakje vorige = koningVakje;
                pionvoormat = true;

                if (mat == true && richting != null)
                {
                    if (richting == "noord")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurNoord.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurNoord, kleur);
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
                            vorige = vorige.buurNoord;
                        }
                    }

                    else if (richting == "oost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurOost.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurOost, kleur);
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
                            vorige = vorige.buurOost;
                        }
                    }

                    else if (richting == "zuid")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurZuid.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurZuid, kleur);
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
                            vorige = vorige.buurZuid;
                        }
                    }

                    else if (richting == "west")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurWest.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurWest, kleur);
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
                            vorige = vorige.buurWest;
                        }
                    }

                    else if (richting == "noordoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurNoordoost.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurNoordoost, kleur);
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
                            vorige = vorige.buurNoordoost;
                        }
                    }

                    else if (richting == "noordwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurNoordwest.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurNoordwest, kleur);
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
                            vorige = vorige.buurNoordwest;
                        }
                    }

                    else if (richting == "zuidoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurZuidoost.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurZuidoost, kleur);
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
                            vorige = vorige.buurZuidoost;
                        }
                    }

                    else if (richting == "zuidwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.buurZuidwest.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.buurZuidwest, kleur);
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
                            vorige = vorige.buurZuidwest;
                        }
                    }
                }
            }
            pionvoormat = false;
            return mat;
        }

        public bool CheckWeinigStukken(Speler speler1, Speler speler2)
        {
            // Dit wordt alleen bekeken wanneer beide spelers minder dan 3 stukken hebben

            //  Een van de spelers heeft nog een pion                           Een van de spelers heeft nog een toren                          Een van de spelers heeft nog een dame
            if (speler1.aantalstukken[0] > 0 || speler2.aantalstukken[0] > 0 || speler1.aantalstukken[1] > 0 || speler2.aantalstukken[1] > 0 || speler1.aantalstukken[4] > 0 || speler2.aantalstukken[4] > 0)
            {
                return false;
            }
            
            // Als beide spelers niet meer hebben dan een koning en 1 loper/paard is het remise
            else
            {
                return true;
            }
        }
    }
}