using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Toren : Schaakstuk
    {
        private bool _eersteZet{get; set; }
        public Toren(string kleur)
        {
            this.kleur = kleur;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.TorenWit;
            }
            else
            {
                afbeelding = Properties.Resources.TorenZwart;
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

