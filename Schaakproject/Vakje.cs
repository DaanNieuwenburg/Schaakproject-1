using System.Drawing;

namespace Schaakproject
{
    public class Vakje
    {
        public Color Kleur { get; private set; }
        public Schaakstuk schaakstuk { get; set; }
        public SpecialPB Pbox { get; set; }

        public Vakje[] Buren { get; set; }

        /*betekenis getallen voor buren:

            Buren[0] is buurNoord
            Buren[1] is buurOost
            Buren[2] is buurZuid
            Buren[3] is buurWest

            Buren[4] is buurNoordoost
            Buren[5] is buurZuidoost
            Buren[6] is buurZuidwest
            Buren[7] is buurNoordwest
            
            */

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

