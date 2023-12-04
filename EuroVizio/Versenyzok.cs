using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Versenyzo
{
    public int Ev { get; }
    public string Orszag { get; }
    public string Elodo { get; }
    public string Cim { get; }
    public int Helyezes { get; }
    public int Pontszam { get; }

    public Versenyzo(string sor)
    {
        var adatok = sor.Split(';');
        Ev = int.Parse(adatok[0]);
        Orszag = adatok[1];
        Elodo = adatok[2];
        Cim = adatok[3];
        Helyezes = int.Parse(adatok[4]);
        Pontszam = int.Parse(adatok[5]);
    }

    public bool TopLista()
    {
        if (Ev < 2000)
        {
            return Pontszam >= 150;
        }
        else
        {
            return Pontszam > 200;
        }
    }
}