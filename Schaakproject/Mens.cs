﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Schaakproject
{
    public class Mens : Speler
    {
        private SpecialPB selected { get; set; }

        public Mens()
            : base("test", "test")
        {

        }

        public bool heeftGeselecteerd = false;

        public void SelecteerStuk(SpecialPB pictures)
        {
            if (pictures == selected)
            {
                DeselecteerStuk();
            }
            else
            {
                if(selected != null)
                {
                    DeselecteerStuk();
                }

                this.selected = pictures;
                pictures.BackColor = Color.HotPink;
            }
        }

        private void DeselecteerStuk()
        {
            selected.vakje.update();
            selected = null;
        }

        public void SelecteerVakje(SpecialPB pictures)
        {
            if(selected != null)
            {
                SpecialPB clicked = pictures;
                pictures.BackColor = Color.AliceBlue;
                selected.vakje.schaakstuk.Verplaats(pictures, selected);
                selected.vakje.update();
                pictures.vakje.update();
                selected = null;
            }
    
        }

    }
}

