using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

public abstract class Schaakstuk
{
	public string kleur{ get; set; }
    public Image afbeelding { get; set; }
    public Vakje vakje { get; set; }

	public abstract void Verplaats();

	private void Slaan()
	{
		throw new System.NotImplementedException();
	}

}

