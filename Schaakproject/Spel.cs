using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Schaakproject
{
    public class Spel
    {
        private string _SpelMode { get; set;}
        private string _Speler1 { get; set; }
        private string _Speler2 { get; set; }

        public Spel(string Mode, string Speler1, string Speler2)
        {
            _SpelMode = Mode;
            _Speler1 = Speler1;
            _Speler2 = Speler2;
            Start();
            
        }
        public string speleraanzet { get; set; }

        public void Start()
        {
            SpeelBord speelbord = new SpeelBord(_SpelMode, _Speler1, _Speler2);
            speelbord.Show();
        }

        public static void Herstart()
        {
            //Spel spel = new Spel();
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

