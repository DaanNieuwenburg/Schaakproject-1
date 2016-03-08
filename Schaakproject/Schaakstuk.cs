using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Schaakstuk
{
	private string _kleur{ get; set; }

	public abstract void Verplaats();

	private void Slaan()
	{
		throw new System.NotImplementedException();
	}

}

