using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public abstract class Speler
    {
        public string Naam { get; set; }
        public string Kleur { get; set; }
        public Spel spel { get; set; }
        public Pion enPassantPion { get; set; }
        public Koning Koning { get; set; }
        public int[] aantalstukken { get; set; }
        public Pion[] pionnen { get; set;}

        public Speler()
        {
            pionnen = new Pion[8];
            aantalstukken = new int[6] { 8, 2, 2, 2, 1, 16 };
            //0Pion      1Toren     2Paard     3Loper     4Dame      5Totaal
        }

    }
}

