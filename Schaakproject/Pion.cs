using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Pion : Schaakstuk
    {
        private bool _eersteZet{ get; set; }

        public Pion(string kleur, Vakje vakje)
        {
            this.vakje = vakje;
            this.kleur = kleur;
            if (kleur == "wit")
            {
                afbeelding = Properties.Resources.PionWit;
            }
            else
            {
                afbeelding = Properties.Resources.PionZwart;
            }
        }

        public override void Verplaats()
        {
            throw new System.NotImplementedException();
        }

        private void EnPassant()
        {
            throw new System.NotImplementedException();
        }

        private void Promoveert()
        {

        }
    }
}

