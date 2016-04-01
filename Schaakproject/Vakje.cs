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
        public Color Kleur { get; private set; }
        public Schaakstuk schaakstuk { get; set; }
        public SpecialPB Pbox { get; set; }

        public Vakje BuurNoord { get; set; }
        public Vakje BuurZuid { get; set; }
        public Vakje BuurOost { get; set; }
        public Vakje BuurWest { get; set; }
        public Vakje BuurNoordoost { get; set; }
        public Vakje BuurZuidOost { get; set; }
        public Vakje BuurNoordWest { get; set; }
        public Vakje BuurZuidWest { get; set; }

        public Vakje(bool Kleur, Color _color1, Color _color2)
        {
            if (Kleur == false)
            {
                this.Kleur = _color1;
            }
            else
            {
                this.Kleur = _color2;
            }
        }
    }
}

