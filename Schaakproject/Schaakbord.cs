using System;
using System.Collections.Generic;
using System.Drawing;

namespace Schaakproject
{
    public static class MSSystemExtenstions
    {
        //Dit shuffled de stukken voor Chess960
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
        public Vakje[,] SchaakArray { get; private set; }       //Een array van vakjes zodat het schaakbord kan worden opgezet
        private Schaakstuk _schaakGezet { get; set; }           //Het schaakstuk dat de koning schaak heeft gezet
        private string _richting { get; set; }                  //De richting waar het schaakstuk dat de koning schaak heeft gezet staat
        private bool _pionVoorMat { get; set; }                 //om te kijken of er een pion gezet kan worden tussen de koning en een stuk
        private List<Schaakstuk> _stukVoorKomen { get; set; }   //een lijst om bij te houden welke stukken mogen verplaatsen om geen schaak te hebben voor het bekijken van schaakmat

        public Schaakbord(string _variant, Spel Spel, Speler Speler1, Speler Speler2, Color vakje1, Color vakje2)
        {
            Color ColorVakje1 = vakje1;
            Color ColorVakje2 = vakje2;
            _stukVoorKomen = new List<Schaakstuk>();

            SchaakArray = new Vakje[8, 8];
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
                    SchaakArray[x, y] = new Vakje(kleurvakje, ColorVakje1, ColorVakje2);

                    kleurvakje = !kleurvakje;
                }
                kleurvakje = !kleurvakje;
            }

            //voeg schaakstukken aan vakjes toe
            if (_variant == "Klassiek")
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
                                SchaakArray[x, y].schaakstuk = new Toren(kleurstuk, SchaakArray[x, y], voorDitStuk);
                                if (kleurstuk == "zwart")
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.ComputerSpeler.NietVerplaatstLijst.Add(SchaakArray[x, y].schaakstuk.Vakje);
                                    }
                                }
                            }

                            else if (y == 1 || y == 6)
                            {
                                SchaakArray[x, y].schaakstuk = new Paard(kleurstuk, SchaakArray[x, y], voorDitStuk);
                                if (kleurstuk == "zwart")
                                {

                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.ComputerSpeler.NietVerplaatstLijst.Add(SchaakArray[x, y].schaakstuk.Vakje);
                                    }
                                }
                            }

                            else if (y == 2 || y == 5)
                            {
                                SchaakArray[x, y].schaakstuk = new Loper(kleurstuk, SchaakArray[x, y], voorDitStuk);
                                if (kleurstuk == "zwart")
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.ComputerSpeler.NietVerplaatstLijst.Add(SchaakArray[x, y].schaakstuk.Vakje);
                                    }
                                }
                            }

                            else if (y == 3)
                            {
                                SchaakArray[x, y].schaakstuk = new Dame(kleurstuk, SchaakArray[x, y], voorDitStuk);
                                if (kleurstuk == "zwart")
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.ComputerSpeler.NietVerplaatstLijst.Add(SchaakArray[x, y].schaakstuk.Vakje);
                                    }
                                }
                            }

                            else if (y == 4)
                            {
                                SchaakArray[x, y].schaakstuk = new Koning(kleurstuk, SchaakArray[x, y], voorDitStuk);

                                if (kleurstuk == "wit")
                                {
                                    Spel.Speler1.koning = SchaakArray[x, y].schaakstuk as Koning;
                                }
                                else
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.ComputerSpeler.koning = SchaakArray[x, y].schaakstuk as Koning;
                                    }
                                    else
                                    {
                                        Spel.Speler2.koning = SchaakArray[x, y].schaakstuk as Koning;
                                    }
                                }
                            }
                        }
                        else if (x == 1 || x == 6)
                        {
                            SchaakArray[x, y].schaakstuk = new Pion(kleurstuk, SchaakArray[x, y], voorDitStuk);
                            if (kleurstuk == "zwart")
                            {
                                //Speler2.pionnen[y] = schaakarray[x, y].schaakstuk as Pion;
                                if (Spel.SpelMode == "Singleplayer")
                                {
                                    Spel.ComputerSpeler.Pionnen[y] = SchaakArray[x, y].schaakstuk as Pion;
                                    Spel.ComputerSpeler.NietVerplaatstLijst.Add(SchaakArray[x, y].schaakstuk.Vakje);
                                }
                                else
                                {
                                    Speler2.Pionnen[y] = SchaakArray[x, y].schaakstuk as Pion;
                                }
                            }
                            else
                            {
                                Speler1.Pionnen[y] = SchaakArray[x, y].schaakstuk as Pion;
                            }
                        }
                    }
                }
            }
            else if (_variant == "Chess960")
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
                                    SchaakArray[x, y].schaakstuk = new Toren(kleurstuk, SchaakArray[x, y], voorDitStuk);
                                }
                            }

                            else if (y == array[2] || y == array[3])
                            {
                                SchaakArray[x, y].schaakstuk = new Paard(kleurstuk, SchaakArray[x, y], voorDitStuk);
                            }

                            else if (y == array[4] || y == array[5])
                            {
                                aantallopers++;
                                SchaakArray[x, y].schaakstuk = new Loper(kleurstuk, SchaakArray[x, y], voorDitStuk);
                            }

                            else if (y == array[6])
                            {
                                SchaakArray[x, y].schaakstuk = new Dame(kleurstuk, SchaakArray[x, y], voorDitStuk);
                            }

                            else if (y == array[7])
                            {
                                SchaakArray[x, y].schaakstuk = new Koning(kleurstuk, SchaakArray[x, y], voorDitStuk);
                                if (kleurstuk == "wit")
                                {
                                    Spel.Speler1.koning = SchaakArray[x, y].schaakstuk as Koning;
                                }
                                else
                                {
                                    if (Spel.SpelMode == "Singleplayer")
                                    {
                                        Spel.ComputerSpeler.koning = SchaakArray[x, y].schaakstuk as Koning;
                                    }
                                    else
                                    {
                                        Spel.Speler2.koning = SchaakArray[x, y].schaakstuk as Koning;
                                    }
                                }

                            }
                        }
                        else if (x == 1 || x == 6)
                        {
                            SchaakArray[x, y].schaakstuk = new Pion(kleurstuk, SchaakArray[x, y], voorDitStuk);
                            if (kleurstuk == "wit")
                            {
                                Speler1.Pionnen[y] = SchaakArray[x, y].schaakstuk as Pion;
                            }
                            else
                            {
                                if (Spel.SpelMode == "Singleplayer")
                                {
                                    Spel.ComputerSpeler.Pionnen[y] = SchaakArray[x, y].schaakstuk as Pion;
                                }
                                else
                                {
                                    Spel.Speler2.Pionnen[y] = SchaakArray[x, y].schaakstuk as Pion;
                                }

                            }
                        }
                    }
                }
            }


            // Geef buren aan de vakjes
            Vakje[] Buren = new Vakje[8];

            /*betekenis getallen voor buren:

            Buren[0] is buurNoord
            Buren[1] is buurOost
            Buren[2] is buurZuid
            Buren[3] is buurWest

            Buren[4] is buurNoordoost
            Buren[5] is buurZuidoost
            Buren[6] is buurZuidwest
            Buren[7] is buurNoordwest

            */

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (x != 0)
                    {
                        Buren[0] = SchaakArray[x - 1, y];
                    }
                    if (x != 7)
                    {
                        Buren[2] = SchaakArray[x + 1, y];
                    }
                    if (y != 7)
                    {
                        Buren[1] = SchaakArray[x, y + 1];
                    }
                    if (y != 0)
                    {
                        Buren[3] = SchaakArray[x, y - 1];
                    }
                    if (x != 0 && y != 0)
                    {
                        Buren[7] = SchaakArray[x - 1, y - 1];
                    }
                    if (x != 7 && y != 7)
                    {
                        Buren[5] = SchaakArray[x + 1, y + 1];
                    }
                    if (x != 7 && y != 0)
                    {
                        Buren[6] = SchaakArray[x + 1, y - 1];
                    }
                    if (x != 0 && y != 7)
                    {
                        Buren[4] = SchaakArray[x - 1, y + 1];
                    }

                    SchaakArray[x, y].Buren = Buren;
                    Buren = new Vakje[8];
                }
            }
        }

        public bool CheckPat(Koning koning)
        {
            Vakje koningVakje = koning.Vakje;
            bool mogelijk = false;
            string kleur = koning.Kleur;
            bool pat = true;
            int blokkeert = 0;  //het aantal schaakstukken die niet mogen bewegen, omdat de koning dan schaak komt te staan
            int stillePion = 0; //hoeveel pionnen er zijn die niet kunnen bewegen

            //bekijk of de koning schaak staat als hij naar noord zou bewegen
            if (koningVakje.Buren[0] != null)
            {
                if (koningVakje.Buren[0].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[0].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }

                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[0], kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar oost zou bewegen
            if (koningVakje.Buren[1] != null)
            {
                if (koningVakje.Buren[1].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[1].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[1], kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuid zou bewegen
            if (koningVakje.Buren[2] != null)
            {
                if (koningVakje.Buren[2].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[2].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[2], kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar west zou bewegen
            if (koningVakje.Buren[3] != null)
            {
                if (koningVakje.Buren[3].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[3].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[3], kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordoost zou bewegen
            if (koningVakje.Buren[4] != null)
            {
                if (koningVakje.Buren[4].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[4].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[4], kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordwest zou bewegen
            if (koningVakje.Buren[7] != null)
            {
                if (koningVakje.Buren[7].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[7].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[7], kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }

                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidoost zou bewegen
            if (koningVakje.Buren[5] != null)
            {
                if (koningVakje.Buren[5].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[5].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[5], kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidwest zou bewegen
            if (koningVakje.Buren[6] != null)
            {
                if (koningVakje.Buren[6].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[6].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[6], kleur);
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
            bool onthouden = false;

            //bekijk of er noord een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[0] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[0].schaakstuk != null)
                    {
                        if (vorige.Buren[0].schaakstuk.Kleur == koning.Kleur)
                        {

                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[0].schaakstuk is Toren || vorige.Buren[0].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }

                                else if (vorige.Buren[0].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[0].schaakstuk is Toren || vorige.Buren[0].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[0];
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //bekijk of er oost een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[1] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[1].schaakstuk != null)
                    {
                        if (vorige.Buren[1].schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[1].schaakstuk is Toren || vorige.Buren[1].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.Buren[1].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[1].schaakstuk is Toren || vorige.Buren[1].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[1];
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //bekijk of er zuid een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[2] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[2].schaakstuk != null)
                    {
                        if (vorige.Buren[2].schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[2].schaakstuk is Toren || vorige.Buren[2].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.Buren[2].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[2].schaakstuk is Toren || vorige.Buren[2].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[2];
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //bekijk of er west een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[3] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[3].schaakstuk != null)
                    {
                        if (vorige.Buren[3].schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[3].schaakstuk is Toren || vorige.Buren[3].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.Buren[3].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[3].schaakstuk is Toren || vorige.Buren[3].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[3];
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //bekijk of er noordoost een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[4] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[4].schaakstuk != null)
                    {
                        if (vorige.Buren[4].schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[4].schaakstuk is Loper || vorige.Buren[4].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.Buren[4].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[4].schaakstuk is Loper || vorige.Buren[4].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[4];
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //bekijk of er noordwest een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[7] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[7].schaakstuk != null)
                    {
                        if (vorige.Buren[7].schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[7].schaakstuk is Loper || vorige.Buren[7].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.Buren[7].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[7].schaakstuk is Loper || vorige.Buren[7].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[7];
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //bekijk of er zuidoost een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[5] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[5].schaakstuk != null)
                    {
                        if (vorige.Buren[5].schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[5].schaakstuk is Loper || vorige.Buren[5].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.Buren[5].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[5].schaakstuk is Loper || vorige.Buren[5].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[5];
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //bekijk of er zuidwest een schaakstuk staat tussen de koning en een schaakstuk dat de koning zou kunnen slaan
            while (loop == false)
            {
                if (vorige.Buren[6] == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.Buren[6].schaakstuk != null)
                    {
                        if (vorige.Buren[6].schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.Buren[6].schaakstuk is Loper || vorige.Buren[6].schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.Buren[6].schaakstuk is Pion)
                                {
                                    loop = true;
                                }
                                else
                                {
                                    juisteKleur = true;
                                }
                            }
                            else
                            {
                                loop = true;
                            }
                        }

                        else {
                            loop = true;

                            if (vorige.Buren[6].schaakstuk is Loper || vorige.Buren[6].schaakstuk is Dame)
                            {
                                if (juisteKleur == true)
                                {
                                    if (onthouden == true)
                                    {
                                        return false;
                                    }
                                    blokkeert++;
                                }
                            }
                        }
                    }
                    vorige = vorige.Buren[6];
                }
            }

            //Kijk of er pionnen zijn die kunnen bewegen, want als dit zo is dan sta je niet pat
            Pion bekijk;
            bool kanVerplaatsen = false;
            for (int i = 0; i < 8; i++)
            {
                bekijk = koning.Speler.Pionnen[i];

                if (bekijk.Geslagen == false)
                {
                    if (bekijk.Kleur == "wit")
                    {
                        if (bekijk.Vakje.Buren[0] != null && bekijk.Vakje.Buren[0].schaakstuk == null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.Buren[0];

                            bekijk.Vakje = andervakje;
                            andervakje.schaakstuk = bekijk;
                            bekijkvakje.schaakstuk = null;

                            bool check = CheckSchaak(koningVakje, bekijk.Kleur);
                            if (check == false)
                            {
                                kanVerplaatsen = true;
                            }
                            bekijk.Vakje = bekijkvakje;
                            bekijkvakje.schaakstuk = bekijk;
                            andervakje.schaakstuk = null;

                        }
                        if (bekijk.Vakje.Buren[4] != null && bekijk.Vakje.Buren[4].schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.Buren[4];
                            Schaakstuk anderstuk = andervakje.schaakstuk;

                            bekijk.Vakje = andervakje;
                            andervakje.schaakstuk = bekijk;
                            bekijkvakje.schaakstuk = null;

                            bool check = CheckSchaak(koningVakje, bekijk.Kleur);
                            if (check == false)
                            {
                                kanVerplaatsen = true;
                            }
                            bekijk.Vakje = bekijkvakje;
                            bekijkvakje.schaakstuk = bekijk;
                            andervakje.schaakstuk = anderstuk;
                        }
                        if (bekijk.Vakje.Buren[7] != null && bekijk.Vakje.Buren[7].schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.Buren[7];
                            Schaakstuk anderstuk = andervakje.schaakstuk;

                            bekijk.Vakje = andervakje;
                            andervakje.schaakstuk = bekijk;
                            bekijkvakje.schaakstuk = null;

                            bool check = CheckSchaak(koningVakje, bekijk.Kleur);
                            if (check == false)
                            {
                                kanVerplaatsen = true;
                            }
                            bekijk.Vakje = bekijkvakje;
                            bekijkvakje.schaakstuk = bekijk;
                            andervakje.schaakstuk = anderstuk;
                        }
                    }
                    else
                    {
                        if (bekijk.Vakje.Buren[2] != null && bekijk.Vakje.Buren[2].schaakstuk == null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.Buren[2];

                            bekijk.Vakje = andervakje;
                            andervakje.schaakstuk = bekijk;
                            bekijkvakje.schaakstuk = null;

                            bool check = CheckSchaak(koningVakje, bekijk.Kleur);
                            if (check == false)
                            {
                                kanVerplaatsen = true;
                            }
                            bekijk.Vakje = bekijkvakje;
                            bekijkvakje.schaakstuk = bekijk;
                            andervakje.schaakstuk = null;
                        }
                        else if (bekijk.Vakje.Buren[5] != null && bekijk.Vakje.Buren[5].schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.Buren[5];
                            Schaakstuk anderstuk = andervakje.schaakstuk;

                            bekijk.Vakje = andervakje;
                            andervakje.schaakstuk = bekijk;
                            bekijkvakje.schaakstuk = null;

                            bool check = CheckSchaak(koningVakje, bekijk.Kleur);
                            if (check == false)
                            {
                                kanVerplaatsen = true;
                            }
                            bekijk.Vakje = bekijkvakje;
                            bekijkvakje.schaakstuk = bekijk;
                            andervakje.schaakstuk = anderstuk;
                        }
                        else if (bekijk.Vakje.Buren[6] != null && bekijk.Vakje.Buren[6].schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.Buren[6];
                            Schaakstuk anderstuk = andervakje.schaakstuk;

                            bekijk.Vakje = andervakje;
                            andervakje.schaakstuk = bekijk;
                            bekijkvakje.schaakstuk = null;

                            bool check = CheckSchaak(koningVakje, bekijk.Kleur);
                            if (check == false)
                            {
                                kanVerplaatsen = true;
                            }
                            bekijk.Vakje = bekijkvakje;
                            bekijkvakje.schaakstuk = bekijk;
                            andervakje.schaakstuk = anderstuk;
                        }
                    }
                    if (kanVerplaatsen == false)
                    {
                        stillePion++;
                    }
                    else
                    {
                        return false;
                    }
                    kanVerplaatsen = false;
                }

            }
            //Als er nog meer stukken zijn dan de koning
            //+ het aantal stukken die niet mogen bewegen omdat de koning dan schaak staat
            //+ het aantal pionnen die niet kunnen bewegen, dan is het niet pat.
            if (koning.Speler.AantalStukken[5] > 1 + blokkeert + stillePion)
            {
                pat = false;
            }

            return pat;
        }

        public bool CheckSchaak(Vakje ditvakje, string kleur)
        {
            _stukVoorKomen.Clear();
            bool mogelijkloop = false;
            bool _staatSchaak = false;
            Schaakstuk zetSchaak = null;
            Vakje vorige = ditvakje;

            //kijk of er noord van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[0] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[0].schaakstuk is Toren || vorige.Buren[0].schaakstuk is Dame)
                {
                    if (vorige.Buren[0].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[0].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "noord";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[0].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[0];
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er zuid van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[2] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[2].schaakstuk is Toren || vorige.Buren[2].schaakstuk is Dame)
                {
                    if (vorige.Buren[2].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[2].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "zuid";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[2].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[2];
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er oost van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[1] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[1].schaakstuk is Toren || vorige.Buren[1].schaakstuk is Dame)
                {
                    if (vorige.Buren[1].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[1].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "oost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[1].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[1];
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er west van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[3] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[3].schaakstuk is Toren || vorige.Buren[3].schaakstuk is Dame)
                {
                    if (vorige.Buren[3].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[3].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "west";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[3].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[3];
            }

            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er noordoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[4] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[4].schaakstuk is Loper || vorige.Buren[4].schaakstuk is Dame)
                {
                    if (vorige.Buren[4].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[4].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "noordoost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[4].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[4];
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er zuidoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[5] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[5].schaakstuk is Loper || vorige.Buren[5].schaakstuk is Dame)
                {
                    if (vorige.Buren[5].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[5].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "zuidoost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[5].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[5];
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er zuidwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[6] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[6].schaakstuk is Loper || vorige.Buren[6].schaakstuk is Dame)
                {
                    if (vorige.Buren[6].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[6].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "zuidwest";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[6].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[6];
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er noordwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.Buren[7] == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.Buren[7].schaakstuk is Loper || vorige.Buren[7].schaakstuk is Dame)
                {
                    if (vorige.Buren[7].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[7].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "noordwest";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.Buren[7].schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.Buren[7];
            }
            vorige = ditvakje;

            //kijk of er noord-noordwest een paard staat
            if (vorige.Buren[0] != null)
            {
                if (vorige.Buren[0].Buren[7] != null)
                {
                    if (vorige.Buren[0].Buren[7].schaakstuk is Paard && vorige.Buren[0].Buren[7].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[0].Buren[7].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er noord-noordoost een paard staat
            if (vorige.Buren[0] != null)
            {
                if (vorige.Buren[0].Buren[4] != null)
                {
                    if (vorige.Buren[0].Buren[4].schaakstuk is Paard && vorige.Buren[0].Buren[4].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[0].Buren[4].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er oost-noordoost een paard staat
            if (vorige.Buren[1] != null)
            {
                if (vorige.Buren[1].Buren[4] != null)
                {
                    if (vorige.Buren[1].Buren[4].schaakstuk is Paard && vorige.Buren[1].Buren[4].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[1].Buren[4].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er oost-zuidoost een paard staat
            if (vorige.Buren[1] != null)
            {
                if (vorige.Buren[1].Buren[5] != null)
                {
                    if (vorige.Buren[1].Buren[5].schaakstuk is Paard && vorige.Buren[1].Buren[5].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[1].Buren[5].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er zuid-zuidoost een paard staat
            if (vorige.Buren[2] != null)
            {
                if (vorige.Buren[2].Buren[5] != null)
                {
                    if (vorige.Buren[2].Buren[5].schaakstuk is Paard && vorige.Buren[2].Buren[5].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[2].Buren[5].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er zuid-zuidwest een paard staat
            if (vorige.Buren[2] != null)
            {
                if (vorige.Buren[2].Buren[6] != null)
                {
                    if (vorige.Buren[2].Buren[6].schaakstuk is Paard && vorige.Buren[2].Buren[6].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[2].Buren[6].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er west-noordwest een paard staat
            if (vorige.Buren[3] != null)
            {
                if (vorige.Buren[3].Buren[7] != null)
                {
                    if (vorige.Buren[3].Buren[7].schaakstuk is Paard && vorige.Buren[3].Buren[7].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[3].Buren[7].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er west-zuidwest een paard staat
            if (vorige.Buren[3] != null)
            {
                if (vorige.Buren[3].Buren[6] != null)
                {
                    if (vorige.Buren[3].Buren[6].schaakstuk is Paard && vorige.Buren[3].Buren[6].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.Buren[3].Buren[6].schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            if (_pionVoorMat == false) //_pionVoorMat is bijna in alle gevallen false
            {
                //kijk of er noord een koning staat
                if (vorige.Buren[0] != null)
                {
                    if (vorige.Buren[0].schaakstuk is Koning && vorige.Buren[0].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[0].schaakstuk);
                    }
                }
                //kijk of er oost een koning staat
                if (vorige.Buren[1] != null)
                {
                    if (vorige.Buren[1].schaakstuk is Koning && vorige.Buren[1].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[1].schaakstuk);
                    }
                }
                //kijk of er zuid een koning staat
                if (vorige.Buren[2] != null)
                {
                    if (vorige.Buren[2].schaakstuk is Koning && vorige.Buren[2].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[2].schaakstuk);
                    }
                }
                //kijk of er west een koning staat
                if (vorige.Buren[3] != null)
                {
                    if (vorige.Buren[3].schaakstuk is Koning && vorige.Buren[3].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[3].schaakstuk);
                    }
                }
                //kijk of er noordoost een koning staat
                if (vorige.Buren[4] != null)
                {
                    if (vorige.Buren[4].schaakstuk is Koning && vorige.Buren[4].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[4].schaakstuk);
                    }
                }
                //kijk of er noordwest een koning staat
                if (vorige.Buren[7] != null)
                {
                    if (vorige.Buren[7].schaakstuk is Koning && vorige.Buren[7].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[7].schaakstuk);
                    }
                }
                //kijk of er zuidoost een koning staat
                if (vorige.Buren[5] != null)
                {
                    if (vorige.Buren[5].schaakstuk is Koning && vorige.Buren[5].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[5].schaakstuk);
                    }
                }
                //kijk of er zuidwest een koning staat
                if (vorige.Buren[6] != null)
                {
                    if (vorige.Buren[6].schaakstuk is Koning && vorige.Buren[6].schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.Buren[6].schaakstuk);
                    }
                }

                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (kleur == "wit")
                {
                    if (vorige.Buren[4] != null)
                    {
                        if (vorige.Buren[4].schaakstuk is Pion && vorige.Buren[4].schaakstuk.Kleur == "zwart")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.Buren[4].schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                    if (vorige.Buren[7] != null)
                    {
                        if (vorige.Buren[7].schaakstuk is Pion && vorige.Buren[7].schaakstuk.Kleur == "zwart")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.Buren[7].schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                }
                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (kleur == "zwart")
                {
                    if (vorige.Buren[5] != null)
                    {
                        if (vorige.Buren[5].schaakstuk is Pion && vorige.Buren[5].schaakstuk.Kleur == "wit")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.Buren[5].schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                    if (vorige.Buren[6] != null)
                    {
                        if (vorige.Buren[6].schaakstuk is Pion && vorige.Buren[6].schaakstuk.Kleur == "wit")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.Buren[6].schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                }
            }
            else //_pionVoorMat is true wanneer er gekeken moet worden of een pion op een leeg vakje gezet kan worden in plaats van schuin slaan
            {
                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (kleur == "wit")
                {
                    if (vorige.Buren[0] != null)
                    {
                        if (vorige.Buren[0].schaakstuk is Pion && vorige.Buren[0].schaakstuk.Kleur == "zwart")
                        {
                            _staatSchaak = true;
                            _stukVoorKomen.Add(vorige.Buren[0].schaakstuk);
                        }

                        if (vorige.Buren[0].Buren[0] != null)
                        {
                            if (vorige.Buren[0].Buren[0].schaakstuk is Pion && vorige.Buren[0].Buren[0].schaakstuk.Kleur == "zwart")
                            {
                                if ((vorige.Buren[0].Buren[0].schaakstuk as Pion).eersteZet == true)
                                {
                                    _staatSchaak = true;
                                    _stukVoorKomen.Add(vorige.Buren[0].Buren[0].schaakstuk);
                                }
                            }
                        }
                    }
                }

                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (kleur == "zwart")
                {
                    if (vorige.Buren[2] != null)
                    {
                        if (vorige.Buren[2].schaakstuk is Pion && vorige.Buren[2].schaakstuk.Kleur == "wit")
                        {
                            _staatSchaak = true;
                            _stukVoorKomen.Add(vorige.Buren[2].schaakstuk);
                        }

                        if (vorige.Buren[2].Buren[2] != null)
                        {
                            if (vorige.Buren[2].Buren[2].schaakstuk is Pion && vorige.Buren[2].Buren[2].schaakstuk.Kleur == "wit")
                            {
                                if ((vorige.Buren[2].Buren[2].schaakstuk as Pion).eersteZet == true)
                                {
                                    _staatSchaak = true;
                                    _stukVoorKomen.Add(vorige.Buren[2].Buren[2].schaakstuk);
                                }
                            }
                        }
                    }
                }

            }
            _schaakGezet = zetSchaak;
            return _staatSchaak;
        }

        public bool CheckMat(Koning koning)
        {
            bool mat = true;
            bool mogelijk = false;

            string kleur = koning.Kleur;
            Vakje koningVakje = koning.Vakje;

            koning.Vakje.schaakstuk = null;

            //bekijk of de koning schaak staat als hij naar noord zou bewegen
            if (koningVakje.Buren[0] != null)
            {
                if (koningVakje.Buren[0].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[0].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }

                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[0], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar oost zou bewegen
            if (koningVakje.Buren[1] != null)
            {
                if (koningVakje.Buren[1].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[1].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[1], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuid zou bewegen
            if (koningVakje.Buren[2] != null)
            {
                if (koningVakje.Buren[2].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[2].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[2], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar west zou bewegen
            if (koningVakje.Buren[3] != null)
            {
                if (koningVakje.Buren[3].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[3].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[3], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordoost zou bewegen
            if (koningVakje.Buren[4] != null)
            {
                if (koningVakje.Buren[4].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[4].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[4], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordwest zou bewegen
            if (koningVakje.Buren[7] != null)
            {
                if (koningVakje.Buren[7].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[7].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[7], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidoost zou bewegen
            if (koningVakje.Buren[5] != null)
            {
                if (koningVakje.Buren[5].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[5].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[5], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidwest zou bewegen
            if (koningVakje.Buren[6] != null)
            {
                if (koningVakje.Buren[6].schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.Buren[6].schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.Buren[6], kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //Bekijk of het stuk dat de koning schaak heeft gezet geslagen kan worden, zonder dat de koning schaak komt te staan
            koning.Vakje.schaakstuk = koning;

            _schaakGezet = null;
            _richting = null;

            CheckSchaak(koning.Vakje, koning.Kleur);
            if (_schaakGezet != null)
            {
                if (kleur == "wit")
                {
                    kleur = "zwart";
                }
                else
                {
                    kleur = "wit";
                }
                Schaakstuk tempgezet = _schaakGezet;
                bool checkschaak = CheckSchaak(_schaakGezet.Vakje, kleur);
                if (checkschaak == true)
                {
                    bool magnietslaan = false;
                    List<Schaakstuk> Lijst = _stukVoorKomen;
                    for (int i = 0; i < Lijst.Count; i++)
                    {
                        Schaakstuk temp = Lijst[i];
                        Vakje tempvakje = temp.Vakje;
                        Vakje tempgezetvakje = tempgezet.Vakje;
                        tempvakje.schaakstuk = null;
                        temp.Vakje = tempgezetvakje;
                        tempgezetvakje.schaakstuk = temp;

                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                        if (check == false)
                        {
                            magnietslaan = true;
                        }
                        tempvakje.schaakstuk = temp;
                        temp.Vakje = tempvakje;
                        tempgezetvakje.schaakstuk = tempgezet;

                    }
                    if (magnietslaan == true)
                    {
                        mat = false;
                    }
                }

                //Bekijk of er een schaakstuk gezet kan worden tussen de koning en het stuk dat de koning schaak heeft gezet
                _stukVoorKomen.Clear();
                Vakje vorige = koningVakje;
                _pionVoorMat = true;

                if (mat == true && _richting != null)
                {
                    if (_richting == "noord")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[0].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[0], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[0];
                                        vorige.Buren[0].schaakstuk = temp;
                                        _pionVoorMat = false;
                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[0].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[0];
                        }
                    }

                    else if (_richting == "oost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[1].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[1], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[1];
                                        vorige.Buren[1].schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[1].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[1];
                        }
                    }

                    else if (_richting == "zuid")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[2].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[2], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[2];
                                        vorige.Buren[2].schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[2].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[2];
                        }
                    }

                    else if (_richting == "west")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[3].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[3], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[3];
                                        vorige.Buren[3].schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[3].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[3];
                        }
                    }

                    else if (_richting == "noordoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[4].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[4], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[4];
                                        vorige.Buren[4].schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[4].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[4];
                        }
                    }

                    else if (_richting == "noordwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[7].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[7], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[7];
                                        vorige.Buren[7].schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[7].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[7];
                        }
                    }

                    else if (_richting == "zuidoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[5].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[5], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[5];
                                        vorige.Buren[5].schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[5].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[5];
                        }
                    }

                    else if (_richting == "zuidwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.Buren[6].schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.Buren[6], kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.Buren[6];
                                        vorige.Buren[6].schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.Buren[6].schaakstuk = null;
                                        temp.Vakje = tempvakje;

                                    }
                                    if (magnietslaan == true)
                                    {
                                        mat = false;
                                        mogelijk = true;
                                    }
                                }
                            }
                            else
                            {
                                mogelijk = true;
                            }
                            vorige = vorige.Buren[6];
                        }
                    }
                }
            }
            _pionVoorMat = false;

            //Als er geen enkele mogelijkheid gevonden is om een zet te doen, waardoor de koning niet meer schaak staat, is mat true.
            return mat;
        }

        public bool CheckWeinigStukken(Speler speler1, Speler speler2)
        {
            // Dit wordt alleen bekeken wanneer beide spelers minder dan 3 stukken hebben

            //  Een van de spelers heeft nog een pion                           Een van de spelers heeft nog een toren                          Een van de spelers heeft nog een dame
            if (speler1.AantalStukken[0] > 0 || speler2.AantalStukken[0] > 0 || speler1.AantalStukken[1] > 0 || speler2.AantalStukken[1] > 0 || speler1.AantalStukken[4] > 0 || speler2.AantalStukken[4] > 0)
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