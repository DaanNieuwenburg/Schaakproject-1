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
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (x != 0)
                    {
                        SchaakArray[x, y].BuurNoord = SchaakArray[x - 1, y];
                    }
                    if (x != 7)
                    {
                        SchaakArray[x, y].BuurZuid = SchaakArray[x + 1, y];
                    }
                    if (y != 7)
                    {
                        SchaakArray[x, y].BuurOost = SchaakArray[x, y + 1];
                    }
                    if (y != 0)
                    {
                        SchaakArray[x, y].BuurWest = SchaakArray[x, y - 1];
                    }
                    if (x != 0 && y != 0)
                    {
                        SchaakArray[x, y].BuurNoordWest = SchaakArray[x - 1, y - 1];
                    }
                    if (x != 7 && y != 7)
                    {
                        SchaakArray[x, y].BuurZuidOost = SchaakArray[x + 1, y + 1];
                    }
                    if (x != 7 && y != 0)
                    {
                        SchaakArray[x, y].BuurZuidWest = SchaakArray[x + 1, y - 1];
                    }
                    if (x != 0 && y != 7)
                    {
                        SchaakArray[x, y].BuurNoordoost = SchaakArray[x - 1, y + 1];
                    }
                }
            }
        }

        public bool CheckPat(Koning koning)
        {
            Vakje koningVakje = koning.Vakje;
            bool mogelijk = false;
            string kleur = koning.Kleur;
            bool pat = true;
            int blokkeert = 0;
            int stillePion = 0;

            //bekijk of de koning schaak staat als hij naar noord zou bewegen
            if (koningVakje.BuurNoord != null)
            {
                if (koningVakje.BuurNoord.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurNoord.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }

                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurNoord, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar oost zou bewegen
            if (koningVakje.BuurOost != null)
            {
                if (koningVakje.BuurOost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurOost.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurOost, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuid zou bewegen
            if (koningVakje.BuurZuid != null)
            {
                if (koningVakje.BuurZuid.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurZuid.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurZuid, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar west zou bewegen
            if (koningVakje.BuurWest != null)
            {
                if (koningVakje.BuurWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurWest.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurWest, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordoost zou bewegen
            if (koningVakje.BuurNoordoost != null)
            {
                if (koningVakje.BuurNoordoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurNoordoost.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurNoordoost, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordwest zou bewegen
            if (koningVakje.BuurNoordWest != null)
            {
                if (koningVakje.BuurNoordWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurNoordWest.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurNoordWest, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }

                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidoost zou bewegen
            if (koningVakje.BuurZuidOost != null)
            {
                if (koningVakje.BuurZuidOost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurZuidOost.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurZuidOost, kleur);
                    if (checkschaak == false)
                    {
                        pat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidwest zou bewegen
            if (koningVakje.BuurZuidWest != null)
            {
                if (koningVakje.BuurZuidWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurZuidWest.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurZuidWest, kleur);
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

            //voor noord
            while (loop == false)
            {
                if (vorige.BuurNoord == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurNoord.schaakstuk != null)
                    {
                        if (vorige.BuurNoord.schaakstuk.Kleur == koning.Kleur)
                        {
                            
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurNoord.schaakstuk is Toren || vorige.BuurNoord.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                
                                else if (vorige.BuurNoord.schaakstuk is Pion)
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

                            if (vorige.BuurNoord.schaakstuk is Toren || vorige.BuurNoord.schaakstuk is Dame)
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
                    vorige = vorige.BuurNoord;
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor oost
            while (loop == false)
            {
                if (vorige.BuurOost == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurOost.schaakstuk != null)
                    {
                        if (vorige.BuurOost.schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurOost.schaakstuk is Toren || vorige.BuurOost.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.BuurOost.schaakstuk is Pion)
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

                            if (vorige.BuurOost.schaakstuk is Toren || vorige.BuurOost.schaakstuk is Dame)
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
                    vorige = vorige.BuurOost;
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor zuid
            while (loop == false)
            {
                if (vorige.BuurZuid == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurZuid.schaakstuk != null)
                    {
                        if (vorige.BuurZuid.schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurZuid.schaakstuk is Toren || vorige.BuurZuid.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.BuurZuid.schaakstuk is Pion)
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

                            if (vorige.BuurZuid.schaakstuk is Toren || vorige.BuurZuid.schaakstuk is Dame)
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
                    vorige = vorige.BuurZuid;
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor west
            while (loop == false)
            {
                if (vorige.BuurWest == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurWest.schaakstuk != null)
                    {
                        if (vorige.BuurWest.schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurWest.schaakstuk is Toren || vorige.BuurWest.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.BuurWest.schaakstuk is Pion)
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

                            if (vorige.BuurWest.schaakstuk is Toren || vorige.BuurWest.schaakstuk is Dame)
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
                    vorige = vorige.BuurWest;
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor noordoost
            while (loop == false)
            {
                if (vorige.BuurNoordoost == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurNoordoost.schaakstuk != null)
                    {
                        if (vorige.BuurNoordoost.schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurNoordoost.schaakstuk is Loper || vorige.BuurNoordoost.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.BuurNoordoost.schaakstuk is Pion)
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

                            if (vorige.BuurNoordoost.schaakstuk is Loper || vorige.BuurNoordoost.schaakstuk is Dame)
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
                    vorige = vorige.BuurNoordoost;
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor noordwest
            while (loop == false)
            {
                if (vorige.BuurNoordWest == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurNoordWest.schaakstuk != null)
                    {
                        if (vorige.BuurNoordWest.schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurNoordWest.schaakstuk is Loper || vorige.BuurNoordWest.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.BuurNoordWest.schaakstuk is Pion)
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

                            if (vorige.BuurNoordWest.schaakstuk is Loper || vorige.BuurNoordWest.schaakstuk is Dame)
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
                    vorige = vorige.BuurNoordWest;
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor zuidoost
            while (loop == false)
            {
                if (vorige.BuurZuidOost == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurZuidOost.schaakstuk != null)
                    {
                        if (vorige.BuurZuidOost.schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurZuidOost.schaakstuk is Loper || vorige.BuurZuidOost.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.BuurZuidOost.schaakstuk is Pion)
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

                            if (vorige.BuurZuidOost.schaakstuk is Loper || vorige.BuurZuidOost.schaakstuk is Dame)
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
                    vorige = vorige.BuurZuidOost;
                }
            }
            onthouden = false;
            loop = false;
            juisteKleur = false;
            vorige = koningVakje;

            //voor zuidwest
            while (loop == false)
            {
                if (vorige.BuurZuidWest == null)
                {
                    loop = true;
                }
                else
                {
                    if (vorige.BuurZuidWest.schaakstuk != null)
                    {
                        if (vorige.BuurZuidWest.schaakstuk.Kleur == koning.Kleur)
                        {
                            if (juisteKleur == false)
                            {
                                if (vorige.BuurZuidWest.schaakstuk is Loper || vorige.BuurZuidWest.schaakstuk is Dame)
                                {
                                    onthouden = true;
                                }
                                else if (vorige.BuurZuidWest.schaakstuk is Pion)
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

                            if (vorige.BuurZuidWest.schaakstuk is Loper || vorige.BuurZuidWest.schaakstuk is Dame)
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
                    vorige = vorige.BuurZuidWest;
                }
            }

            Pion bekijk;
            bool kanVerplaatsen = false;
            for (int i = 0; i < 8; i++)
            {
                bekijk = koning.Speler.Pionnen[i];

                if (bekijk.Geslagen == false)
                {
                    if (bekijk.Kleur == "wit")
                    {
                        if (bekijk.Vakje.BuurNoord != null && bekijk.Vakje.BuurNoord.schaakstuk == null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.BuurNoord;

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
                        if (bekijk.Vakje.BuurNoordoost != null && bekijk.Vakje.BuurNoordoost.schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.BuurNoordoost;
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
                        if (bekijk.Vakje.BuurNoordWest != null && bekijk.Vakje.BuurNoordWest.schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.BuurNoordWest;
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
                        if (bekijk.Vakje.BuurZuid != null && bekijk.Vakje.BuurZuid.schaakstuk == null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.BuurZuid;

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
                        else if (bekijk.Vakje.BuurZuidOost != null && bekijk.Vakje.BuurZuidOost.schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.BuurZuidOost;
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
                        else if (bekijk.Vakje.BuurZuidWest != null && bekijk.Vakje.BuurZuidWest.schaakstuk != null)
                        {
                            Vakje bekijkvakje = bekijk.Vakje;
                            Vakje andervakje = bekijk.Vakje.BuurZuidWest;
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
                if (vorige.BuurNoord == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurNoord.schaakstuk is Toren || vorige.BuurNoord.schaakstuk is Dame)
                {
                    if (vorige.BuurNoord.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurNoord.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "noord";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurNoord.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurNoord;
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er zuid van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.BuurZuid == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurZuid.schaakstuk is Toren || vorige.BuurZuid.schaakstuk is Dame)
                {
                    if (vorige.BuurZuid.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurZuid.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "zuid";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurZuid.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurZuid;
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er oost van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.BuurOost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurOost.schaakstuk is Toren || vorige.BuurOost.schaakstuk is Dame)
                {
                    if (vorige.BuurOost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurOost.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "oost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurOost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurOost;
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er west van de koning een toren of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.BuurWest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurWest.schaakstuk is Toren || vorige.BuurWest.schaakstuk is Dame)
                {
                    if (vorige.BuurWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurWest.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "west";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurWest.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurWest;
            }

            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er noordoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.BuurNoordoost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurNoordoost.schaakstuk is Loper || vorige.BuurNoordoost.schaakstuk is Dame)
                {
                    if (vorige.BuurNoordoost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurNoordoost.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "noordoost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurNoordoost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurNoordoost;
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er zuidoost van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.BuurZuidOost == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurZuidOost.schaakstuk is Loper || vorige.BuurZuidOost.schaakstuk is Dame)
                {
                    if (vorige.BuurZuidOost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurZuidOost.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "zuidoost";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurZuidOost.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurZuidOost;
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er zuidwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.BuurZuidWest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurZuidWest.schaakstuk is Loper || vorige.BuurZuidWest.schaakstuk is Dame)
                {
                    if (vorige.BuurZuidWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurZuidWest.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "zuidwest";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurZuidWest.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurZuidWest;
            }
            mogelijkloop = false;
            vorige = ditvakje;

            //kijk of er noordwest van de koning een loper of dame staat
            while (mogelijkloop == false)
            {
                if (vorige.BuurNoordWest == null)
                {
                    mogelijkloop = true;
                }
                else if (vorige.BuurNoordWest.schaakstuk is Loper || vorige.BuurNoordWest.schaakstuk is Dame)
                {
                    if (vorige.BuurNoordWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurNoordWest.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                        _richting = "noordwest";
                    }
                    mogelijkloop = true;
                }
                else if (vorige.BuurNoordWest.schaakstuk != null)
                {
                    mogelijkloop = true;
                }
                vorige = vorige.BuurNoordWest;
            }
            vorige = ditvakje;

            //kijk of er noord-noordwest een paard staat
            if (vorige.BuurNoord != null)
            {
                if (vorige.BuurNoord.BuurNoordWest != null)
                {
                    if (vorige.BuurNoord.BuurNoordWest.schaakstuk is Paard && vorige.BuurNoord.BuurNoordWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurNoord.BuurNoordWest.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er noord-noordoost een paard staat
            if (vorige.BuurNoord != null)
            {
                if (vorige.BuurNoord.BuurNoordoost != null)
                {
                    if (vorige.BuurNoord.BuurNoordoost.schaakstuk is Paard && vorige.BuurNoord.BuurNoordoost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurNoord.BuurNoordoost.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er oost-noordoost een paard staat
            if (vorige.BuurOost != null)
            {
                if (vorige.BuurOost.BuurNoordoost != null)
                {
                    if (vorige.BuurOost.BuurNoordoost.schaakstuk is Paard && vorige.BuurOost.BuurNoordoost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurOost.BuurNoordoost.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er oost-zuidoost een paard staat
            if (vorige.BuurOost != null)
            {
                if (vorige.BuurOost.BuurZuidOost != null)
                {
                    if (vorige.BuurOost.BuurZuidOost.schaakstuk is Paard && vorige.BuurOost.BuurZuidOost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurOost.BuurZuidOost.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er zuid-zuidoost een paard staat
            if (vorige.BuurZuid != null)
            {
                if (vorige.BuurZuid.BuurZuidOost != null)
                {
                    if (vorige.BuurZuid.BuurZuidOost.schaakstuk is Paard && vorige.BuurZuid.BuurZuidOost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurZuid.BuurZuidOost.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er zuid-zuidwest een paard staat
            if (vorige.BuurZuid != null)
            {
                if (vorige.BuurZuid.BuurZuidWest != null)
                {
                    if (vorige.BuurZuid.BuurZuidWest.schaakstuk is Paard && vorige.BuurZuid.BuurZuidWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurZuid.BuurZuidWest.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er west-noordwest een paard staat
            if (vorige.BuurWest != null)
            {
                if (vorige.BuurWest.BuurNoordWest != null)
                {
                    if (vorige.BuurWest.BuurNoordWest.schaakstuk is Paard && vorige.BuurWest.BuurNoordWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurWest.BuurNoordWest.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            //kijk of er west-zuidwest een paard staat
            if (vorige.BuurWest != null)
            {
                if (vorige.BuurWest.BuurZuidWest != null)
                {
                    if (vorige.BuurWest.BuurZuidWest.schaakstuk is Paard && vorige.BuurWest.BuurZuidWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        zetSchaak = vorige.BuurWest.BuurZuidWest.schaakstuk;
                        _stukVoorKomen.Add(zetSchaak);
                    }
                }
            }
            if (_pionVoorMat == false)
            {
                //kijk of er noord een koning staat
                if (vorige.BuurNoord != null)
                {
                    if (vorige.BuurNoord.schaakstuk is Koning && vorige.BuurNoord.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurNoord.schaakstuk);
                    }
                }
                //kijk of er oost een koning staat
                if (vorige.BuurOost != null)
                {
                    if (vorige.BuurOost.schaakstuk is Koning && vorige.BuurOost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurOost.schaakstuk);
                    }
                }
                //kijk of er zuid een koning staat
                if (vorige.BuurZuid != null)
                {
                    if (vorige.BuurZuid.schaakstuk is Koning && vorige.BuurZuid.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurZuid.schaakstuk);
                    }
                }
                //kijk of er west een koning staat
                if (vorige.BuurWest != null)
                {
                    if (vorige.BuurWest.schaakstuk is Koning && vorige.BuurWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurWest.schaakstuk);
                    }
                }
                //kijk of er noordoost een koning staat
                if (vorige.BuurNoordoost != null)
                {
                    if (vorige.BuurNoordoost.schaakstuk is Koning && vorige.BuurNoordoost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurNoordoost.schaakstuk);
                    }
                }
                //kijk of er noordwest een koning staat
                if (vorige.BuurNoordWest != null)
                {
                    if (vorige.BuurNoordWest.schaakstuk is Koning && vorige.BuurNoordWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurNoordWest.schaakstuk);
                    }
                }
                //kijk of er zuidoost een koning staat
                if (vorige.BuurZuidOost != null)
                {
                    if (vorige.BuurZuidOost.schaakstuk is Koning && vorige.BuurZuidOost.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurZuidOost.schaakstuk);
                    }
                }
                //kijk of er zuidwest een koning staat
                if (vorige.BuurZuidWest != null)
                {
                    if (vorige.BuurZuidWest.schaakstuk is Koning && vorige.BuurZuidWest.schaakstuk.Kleur != kleur)
                    {
                        _staatSchaak = true;
                        _stukVoorKomen.Add(vorige.BuurZuidWest.schaakstuk);
                    }
                }

                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (kleur == "wit")
                {
                    if (vorige.BuurNoordoost != null)
                    {
                        if (vorige.BuurNoordoost.schaakstuk is Pion && vorige.BuurNoordoost.schaakstuk.Kleur == "zwart")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.BuurNoordoost.schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                    if (vorige.BuurNoordWest != null)
                    {
                        if (vorige.BuurNoordWest.schaakstuk is Pion && vorige.BuurNoordWest.schaakstuk.Kleur == "zwart")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.BuurNoordWest.schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                }
                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (kleur == "zwart")
                {
                    if (vorige.BuurZuidOost != null)
                    {
                        if (vorige.BuurZuidOost.schaakstuk is Pion && vorige.BuurZuidOost.schaakstuk.Kleur == "wit")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.BuurZuidOost.schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                    if (vorige.BuurZuidWest != null)
                    {
                        if (vorige.BuurZuidWest.schaakstuk is Pion && vorige.BuurZuidWest.schaakstuk.Kleur == "wit")
                        {
                            _staatSchaak = true;
                            zetSchaak = vorige.BuurZuidWest.schaakstuk;
                            _stukVoorKomen.Add(zetSchaak);
                        }
                    }
                }
            }
            else
            {
                //alleen een witte koning hoeft uit te kijken voor pionnen die noord staan
                if (kleur == "wit")
                {
                    if (vorige.BuurNoord != null)
                    {
                        if (vorige.BuurNoord.schaakstuk is Pion && vorige.BuurNoord.schaakstuk.Kleur == "zwart")
                        {
                            _staatSchaak = true;
                            _stukVoorKomen.Add(vorige.BuurNoord.schaakstuk);
                        }

                        if (vorige.BuurNoord.BuurNoord != null)
                        {
                            if (vorige.BuurNoord.BuurNoord.schaakstuk is Pion && vorige.BuurNoord.BuurNoord.schaakstuk.Kleur == "zwart")
                            {
                                if ((vorige.BuurNoord.BuurNoord.schaakstuk as Pion).eersteZet == true)
                                {
                                    _staatSchaak = true;
                                    _stukVoorKomen.Add(vorige.BuurNoord.BuurNoord.schaakstuk);
                                }
                            }
                        }
                    }
                }

                //alleen een zwarte koning hoeft uit te kijken voor pionnen die zuid staan
                if (kleur == "zwart")
                {
                    if (vorige.BuurZuid != null)
                    {
                        if (vorige.BuurZuid.schaakstuk is Pion && vorige.BuurZuid.schaakstuk.Kleur == "wit")
                        {
                            _staatSchaak = true;
                            _stukVoorKomen.Add(vorige.BuurZuid.schaakstuk);
                        }

                        if (vorige.BuurZuid.BuurZuid != null)
                        {
                            if (vorige.BuurZuid.BuurZuid.schaakstuk is Pion && vorige.BuurZuid.BuurZuid.schaakstuk.Kleur == "wit")
                            {
                                if ((vorige.BuurZuid.BuurZuid.schaakstuk as Pion).eersteZet == true)
                                {
                                    _staatSchaak = true;
                                    _stukVoorKomen.Add(vorige.BuurZuid.BuurZuid.schaakstuk);
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
            Console.WriteLine("VERDERR");
            bool mat = true;
            bool mogelijk = false;

            string kleur = koning.Kleur;
            Vakje koningVakje = koning.Vakje;

            koning.Vakje.schaakstuk = null;

            //bekijk of de koning schaak staat als hij naar noord zou bewegen
            if (koningVakje.BuurNoord != null)
            {
                if (koningVakje.BuurNoord.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurNoord.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }

                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurNoord, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar oost zou bewegen
            if (koningVakje.BuurOost != null)
            {
                if (koningVakje.BuurOost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurOost.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurOost, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuid zou bewegen
            if (koningVakje.BuurZuid != null)
            {
                if (koningVakje.BuurZuid.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurZuid.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurZuid, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar west zou bewegen
            if (koningVakje.BuurWest != null)
            {
                if (koningVakje.BuurWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurWest.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurWest, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordoost zou bewegen
            if (koningVakje.BuurNoordoost != null)
            {
                if (koningVakje.BuurNoordoost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurNoordoost.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurNoordoost, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar noordwest zou bewegen
            if (koningVakje.BuurNoordWest != null)
            {
                if (koningVakje.BuurNoordWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurNoordWest.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurNoordWest, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidoost zou bewegen
            if (koningVakje.BuurZuidOost != null)
            {
                if (koningVakje.BuurZuidOost.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurZuidOost.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurZuidOost, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
            //bekijk of de koning schaak staat als hij naar zuidwest zou bewegen
            if (koningVakje.BuurZuidWest != null)
            {
                if (koningVakje.BuurZuidWest.schaakstuk == null)
                {
                    mogelijk = true;
                }
                else if (koningVakje.BuurZuidWest.schaakstuk.Kleur != kleur)
                {
                    mogelijk = true;
                }
                if (mogelijk == true)
                {
                    bool checkschaak = CheckSchaak(koningVakje.BuurZuidWest, kleur);
                    if (checkschaak == false)
                    {
                        mat = false;
                    }
                }
                mogelijk = false;
            }
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

                _stukVoorKomen.Clear();
                Vakje vorige = koningVakje;
                _pionVoorMat = true;

                if (mat == true && _richting != null)
                {
                    if (_richting == "noord")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurNoord.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurNoord, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurNoord;
                                        vorige.BuurNoord.schaakstuk = temp;
                                        _pionVoorMat = false;
                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurNoord.schaakstuk = null;
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
                            vorige = vorige.BuurNoord;
                        }
                    }

                    else if (_richting == "oost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurOost.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurOost, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurOost;
                                        vorige.BuurOost.schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurOost.schaakstuk = null;
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
                            vorige = vorige.BuurOost;
                        }
                    }

                    else if (_richting == "zuid")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurZuid.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurZuid, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurZuid;
                                        vorige.BuurZuid.schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurZuid.schaakstuk = null;
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
                            vorige = vorige.BuurZuid;
                        }
                    }

                    else if (_richting == "west")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurWest.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurWest, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurWest;
                                        vorige.BuurWest.schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurWest.schaakstuk = null;
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
                            vorige = vorige.BuurWest;
                        }
                    }

                    else if (_richting == "noordoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurNoordoost.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurNoordoost, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurNoordoost;
                                        vorige.BuurNoordoost.schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurNoordoost.schaakstuk = null;
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
                            vorige = vorige.BuurNoordoost;
                        }
                    }

                    else if (_richting == "noordwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurNoordWest.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurNoordWest, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurNoordWest;
                                        vorige.BuurNoordWest.schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurNoordWest.schaakstuk = null;
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
                            vorige = vorige.BuurNoordWest;
                        }
                    }

                    else if (_richting == "zuidoost")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurZuidOost.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurZuidOost, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurZuidOost;
                                        vorige.BuurZuidOost.schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurZuidOost.schaakstuk = null;
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
                            vorige = vorige.BuurZuidOost;
                        }
                    }

                    else if (_richting == "zuidwest")
                    {
                        while (mogelijk == false)
                        {
                            if (vorige.BuurZuidWest.schaakstuk == null)
                            {
                                checkschaak = CheckSchaak(vorige.BuurZuidWest, kleur);
                                if (checkschaak == true)
                                {
                                    bool magnietslaan = false;
                                    List<Schaakstuk> Lijst = _stukVoorKomen;
                                    for (int i = 0; i < Lijst.Count; i++)
                                    {
                                        Schaakstuk temp = Lijst[i];
                                        Vakje tempvakje = temp.Vakje;

                                        tempvakje.schaakstuk = null;
                                        temp.Vakje = vorige.BuurZuidWest;
                                        vorige.BuurZuidWest.schaakstuk = temp;
                                        _pionVoorMat = false;

                                        bool check = CheckSchaak(koning.Vakje, koning.Kleur);
                                        if (check == false)
                                        {
                                            magnietslaan = true;
                                        }

                                        tempvakje.schaakstuk = temp;
                                        vorige.BuurZuidWest.schaakstuk = null;
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
                            vorige = vorige.BuurZuidWest;
                        }
                    }
                }
            }
            _pionVoorMat = false;
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