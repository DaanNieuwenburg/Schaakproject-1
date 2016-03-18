using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public abstract class Speler
    {
        public string Naam{ get; set; }

        public string Kleur{ get; set; }

        public Pion mijnPassantPion { get; set; }
        public Pion tegenstanderPion{ get; set; }
        public Pion mijnPassantPion2 { get; set; }
    }
}

