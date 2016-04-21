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
                // Zodra er een stuk geslagen word gaat er 1 van het totaal aantal stukken af
                Speler.AantalStukken[5]--;
                if (this is Pion )
                {
                    // Zodra er een Pion geslagen word gaat er 1 van het totaal aantal pionnen af
                    Speler.AantalStukken[0]--;
                    Geslagen = true;
                }
                else if (this is Toren )
                {
                    // Zodra er een Toren geslagen word gaat er 1 van het totaal aantal torens af
                    Speler.AantalStukken[1]--;
                }
                else if (this is Paard )
                {
                    // Zodra er een Paard geslagen word gaat er 1 van het totaal aantal paarden af
                    Speler.AantalStukken[2]--;
                }
                else if (this is Loper )
                {
                    // Zodra er een Loper geslagen word gaat er 1 van het totaal aantal lopers af
                    Speler.AantalStukken[3]--;
                }
                else if (this is Dame )
                {
                    // Zodra er een Dame geslagen word gaat er 1 van het totaal aantal dame(s) af
                    Speler.AantalStukken[4]--;
                }
            }
        }
    }
}


