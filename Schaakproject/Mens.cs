using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Mens : Speler
    {
        public Mens()
            : base("test", "test")
        {

        }

        public bool heeftGeselecteerd = false;
        private void SelecteerStuk()
        {
            throw new System.NotImplementedException();
        }

        private void DeselecteerStuk()
        {
            throw new System.NotImplementedException();
        }

        private void SelecteerVakje()
        {
            Spel.VeranderSpeler();
            heeftGeselecteerd = true;
        }
    }
}

