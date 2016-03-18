﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schaakproject
{
    public class SpecialPB : PictureBox
    {
        public Vakje vakje { get; set; }

        public void update()
        {
            if (vakje.schaakstuk != null)
            {
                Image = vakje.schaakstuk.afbeelding;
                BackColor = vakje._kleur;
            }
            else
            {
                Image = null;
                BackColor = vakje._kleur;
            }
        }
    }

}
