using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Schaakproject
{
    public class Vakje
    {
        public Color _kleur { get; private set; }
        public Schaakstuk schaakstuk { get; set; }
        public SpecialPB pbox { get; set; }
        public Vakje buurNoord { get; set; }
        public Vakje buurZuid { get; set; }
        public Vakje buurOost { get; set; }
        public Vakje buurWest { get; set; }
        public Vakje buurNoordoost { get; set; }
        public Vakje buurZuidoost { get; set; }
        public Vakje buurNoordwest { get; set; }
        public Vakje buurZuidwest { get; set; }

        public Vakje(bool Kleur)
        {
            if (Kleur == false)
            {
                _kleur = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            }
            else
            {
                _kleur = Color.SaddleBrown;
            }
        }

        

    }
}

