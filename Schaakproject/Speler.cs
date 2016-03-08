using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schaakproject
{
    public class Speler
    {
        private string _naam{ get; set; }

        private string _kleur{ get; set; }

        public Speler(string Naam, string Kleur)
        {
            _naam = Naam;
            _kleur = Kleur;
            Console.WriteLine(_naam);
            Console.WriteLine(_kleur);
        }
    }
}

