using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Koning : Schaakstuk
    {
        private bool Staatschaak { get; set; }

        private bool Eerstezet { get; set; }

        public Koning(string kleur)
        {
            this.kleur = kleur;
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

