using System.Drawing;

namespace Schaakproject
{
    public abstract class Schaakstuk
    {
        public string Kleur { get; set; }
        public Image Afbeelding { get; set; }
        public Vakje Vakje { get; set; }
        public Speler Speler { get; set; }
        public bool Geslagen { get; private set; }
        public abstract void Verplaats(Vakje nieuwVakje, Vakje selected, Spel spel);
        public abstract void kanStukSlaan(Algoritme algoritme, Vakje geselecteerdStuk);
        public void Slaan()
        {
            
            if (Speler != null)
            {
                // Het totaal aantal stukken wordt 1 minder zodra er iets is geslagen
                Speler.AantalStukken[5]--;
                if (this is Pion )
                {
                    // 1 pion is geslagen dus 1 pion minder
                    Speler.AantalStukken[0]--;
                    Geslagen = true;
                }
                else if (this is Toren )
                {
                    // 1 Toren is geslagen dus 1 toren minder
                    Speler.AantalStukken[1]--;
                }
                else if (this is Paard )
                {
                    // 1 Paard is geslagen dus 1 Paard minder
                    Speler.AantalStukken[2]--;
                }
                else if (this is Loper )
                {
                    // 1 Loper is geslagen dus 1 loper minder
                    Speler.AantalStukken[3]--;
                }
                else if (this is Dame )
                {
                    // 1 Dame is geslagen dus 1 dame minder
                    Speler.AantalStukken[4]--;
                }
            }
        }
    }
}


