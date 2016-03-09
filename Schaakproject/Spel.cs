using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Schaakproject
{
    public class Spel
    {
        public Spel()
        {
            Start();
        }
        public string speleraanzet { get; set; }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public static void Herstart()
        {
            Spel spel = new Spel();
        }

        public static void VeranderSpeler()
        {
            /*
            if(heeftGeselecteerd == true)
            {
                speleraanzet = " "/* andere speler ;
                heeftGeselecteerd = false;
            }*/
        }
    }
}

