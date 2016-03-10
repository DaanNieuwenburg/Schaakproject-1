using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class Vakje
{
	private string _kleur{ get; set; }
    public Schaakstuk schaakstuk { get; set; }
    public PictureBox pbox { get; set; }
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
        this.pbox = pbox;
        if (Kleur == false)
        {
            _kleur = "wit";
        }
        else
        {
            _kleur = "zwart";
        }
    }

    public void update()
    {
        if (this.schaakstuk != null)
        {
            pbox.Image = schaakstuk.afbeelding;
        }
    }
}

