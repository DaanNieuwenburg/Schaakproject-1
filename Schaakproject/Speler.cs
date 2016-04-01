namespace Schaakproject
{
    public abstract class Speler
    {
        public string Naam { get; set; }
        public bool ValideZet { get; set; }
        public string Kleur { get; set; }

        public Spel spel { get; set; }
        public Pion EnPassantPion { get; set; }

        public Koning koning { get; set; }
        public int[] AantalStukken { get; set; }
        public Pion[] Pionnen { get; set; }

        public Speler()
        {
            Pionnen = new Pion[8];
            AantalStukken = new int[6] {8,    2,     2,     2,     1,    16     };
            //                          0Pion 1Toren 2Paard 3Loper 4Dame 5Totaal
        }
    }
}

