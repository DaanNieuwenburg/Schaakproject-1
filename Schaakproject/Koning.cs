using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private bool _staatschaak { get; set; }

        private bool _eersteZet { get; set; }

        public Koning(string kleur, Vakje vakje)
        {
            this.kleur = kleur;
            this.vakje = vakje;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.KoningWit;
            }
            else
            {
                afbeelding = Properties.Resources.KoningZwart;
            }
        }

        public override void Verplaats()
        {
            throw new System.NotImplementedException();
        }

        private void Rokeren()
        {
            throw new System.NotImplementedException();
        }
    }
}

