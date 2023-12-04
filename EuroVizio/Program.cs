using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 3. feladat: Adatok beolvasása és tárolása
        List<Versenyzo> versenyzok = Beolvas("eurovizio.csv");

        // 4. feladat: Versenyzők száma
        Console.WriteLine($"4. feladat: Versenyzők száma: {versenyzok.Count}");

        // 5. feladat: Nem magyarországi versenyzők
        Console.WriteLine("5. feladat: Nem magyarországi versenyzők:");
        foreach (var versenyzo in versenyzok.Where(v => v.Orszag != "Magyarország"))
        {
            Console.WriteLine(versenyzo.Cim);
        }

        // 6. feladat: Toplista ellenőrzése
        Console.WriteLine($"6. feladat: Toplista ellenőrzése (2000 előtti versenyzők: 150 pont felett, 2000 utániak: 200 pont felett)");
        foreach (var versenyzo in versenyzok)
        {
            Console.WriteLine($"{versenyzo.Cim} - Toplista: {versenyzo.TopLista()}");
        }

        // 7. feladat: Átlagos pontszám
        Console.Write("7. feladat: Kérem az országot: ");
        string keresettOrszag = Console.ReadLine();
        var atlagPontszam = AtlagosPontszam(versenyzok, keresettOrszag);
        if (atlagPontszam.HasValue)
        {
            Console.WriteLine($"Az ország átlagos pontszáma: {atlagPontszam}");
        }
        else
        {
            Console.WriteLine("Nem található ilyen nevű ország.");
        }
    }

    static List<Versenyzo> Beolvas(string fajlnev)
    {
        List<Versenyzo> versenyzok = new List<Versenyzo>();

        try
        {
            string[] sorok = System.IO.File.ReadAllLines(fajlnev);

            foreach (var sor in sorok.Skip(1)) 
            {
                Versenyzo versenyzo = new Versenyzo(sor);
                versenyzok.Add(versenyzo);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Hiba történt az állomány olvasása során: {e.Message}");
        }

        return versenyzok;
    }
    static double? AtlagosPontszam(List<Versenyzo> versenyzok, string orszag)
    {
        var atlagPontszam = versenyzok
            .Where(v => v.Orszag.Equals(orszag, StringComparison.OrdinalIgnoreCase))
            .Select(v => (double?)v.Pontszam) 
            .Average();

        return atlagPontszam;
    }

    
}

