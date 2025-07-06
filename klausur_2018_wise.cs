using System;
using System.Collections.Generic;
using System.IO;

class Klausur2018WiSe
{
  public static void Main() {
    Console.WriteLine("Klausur 2018 WiSe");
    //aufg1a();
    //aufg1b();
    //aufg1c();
    //aufg1d();
    //aufg1e();
    //aufg2a();
    //aufg2b();
    //aufg2c();
    //aufg2d();
    //aufg2e();
    aufg5a();
  }

  public static void aufg1a() {
    Console.WriteLine("Aufgabe 1a");
    int i1 = 10;
    int i2 = 12;

    if(i1 - i2 <= 2) {
      Console.WriteLine(i1 / 2);
    } else {
      i2 *= 2;
      Console.WriteLine(i2); // Nicht Teil der Lösung!
    }
  }

  public static void aufg1b() {
    Console.WriteLine("Aufgabe 1b");
    double d1 = 23.9;

    while (d1 > 5.0) {
      d1 -= 3.0;
      Console.WriteLine($"d1: {d1}"); // Nicht Teil der Lösung!

      if(d1 * d1 < 10.0) {
        Console.WriteLine(d1 * 3.0);
      }
    }
  }

  public static void aufg1c() {
    Console.WriteLine("Aufgabe 1c");
    string t1 = "Mein Text"; // 77, 101, 105, 110, 32, 84, 101, 120, 116
    int anz;

    anz = 0;
    foreach(char z in t1) {
      // Console.WriteLine(z + 0); // Nicht Teil der Lösung!
      if (z % 2 == 0) {
        anz += 3;
      }
    }

    /*
    // Alternativ:
    anz = 0;
    for(int i = 0; i < t1.Length; ++i) {
      if(t1[i] % 2 == 0) {
        anz += 3;
      }
    }
    */

    Console.WriteLine(anz); // Nicht Teil der Lösung!
  }

  public static void aufg1d() {
    Console.WriteLine("Aufgabe 1d");
    List<int> iifeld = new List<int>() { 77, 101, 105, 110, 32, 84, 101, 120, 116 }; // "Mein Text"

    foreach(char c in iifeld) {
      if(c >= 65 && c <= 91) {
        Console.WriteLine(c);
      }
    }
  }

  public static void aufg1e() {
    Console.WriteLine("Aufgabe 1e");
    bool[] bfeld = new bool[] { true, false, true, true, true, true, false, false, true, false, false, false, false };
    foreach (bool b in bfeld) Console.Write(b ? "1 " : "0 ");
    Console.WriteLine();

    for(int i = 0; i < bfeld.Length; i += 5) {
      bfeld[i] = i % 2 == 0;
    }

    foreach(bool b in bfeld) Console.Write(b ? "1 " : "0 ");
    Console.WriteLine();

  }

  public struct Suchergebnis {
    public string Kategorie;
    public string Bezeichnung;
    public double Preis;
  }

  public static void aufg2a() {
    Console.WriteLine("Aufgabe 2a");
    Suchergebnis suche = new Suchergebnis() {
      Kategorie = "Büromaterial",
      Bezeichnung = "Radiergummi",
      Preis = 1.2
    };
    Console.WriteLine($"{suche.Bezeichnung}: EUR {suche.Preis:F2}");
  }

  public static double DPreis(List<Suchergebnis> suche, string kat) {
    double sum = 0.0;
    int cnt = 0;

    foreach(Suchergebnis s in suche) {
      if(s.Kategorie == kat) {
        sum += s.Preis;
        cnt++;
      }
    }
    return cnt == 0 ? 0.0 : sum / cnt;
  }

  public static void aufg2b() {
    Console.WriteLine("Aufgabe 2b");
    List<Suchergebnis> suche = new List<Suchergebnis> {
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Stifte", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Füller", Preis = 16.2 },
      new Suchergebnis() { Kategorie = "Werkzeug", Bezeichnung = "Hammer", Preis = 8.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Mappe", Preis = 14.1 },
    };
    string kat = "Büromaterial";
    double d = DPreis(suche, kat);
    Console.WriteLine($"Durschnittspreis für {kat}: EUR {d:F2}");
  }

  public static int IndexVon(List<Suchergebnis> suche, string kat) {
    for(int i = suche.Count - 1; i >= 0; --i) {
      if(suche[i].Kategorie == kat) {
        return i;
      }
    }
    return -1;
  }

  public static void aufg2c() {
    Console.WriteLine("Aufgabe 2c");
    List<Suchergebnis> suche = new List<Suchergebnis> {
      new Suchergebnis() { Kategorie = "Sonstiges", Bezeichnung = "Stifte", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Füller", Preis = 16.2 },
      new Suchergebnis() { Kategorie = "Werkzeug", Bezeichnung = "Hammer", Preis = 8.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Mappe", Preis = 14.1 },
    };
    int i = IndexVon(suche, "Werkzeug");
    Console.WriteLine(i);
  }

  public static List<Suchergebnis> AlleVon(List<Suchergebnis> suche, string kat) {
    List<Suchergebnis> ergebnis = new List<Suchergebnis>();

    foreach(Suchergebnis s in suche) {
      if(s.Kategorie == kat) {
        ergebnis.Add(s);
      }
    }

    return ergebnis;
  }

  public static void aufg2d() {
    Console.WriteLine("Aufgabe 2d");
    List<Suchergebnis> suche = new List<Suchergebnis> {
      new Suchergebnis() { Kategorie = "Sonstiges", Bezeichnung = "Stifte", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Füller", Preis = 16.2 },
      new Suchergebnis() { Kategorie = "Werkzeug", Bezeichnung = "Hammer", Preis = 8.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Mappe", Preis = 14.1 },
    };
    List<Suchergebnis> ergebnis = AlleVon(suche, "Büromaterial");
    foreach(Suchergebnis e in ergebnis) {
      Console.WriteLine(e.Bezeichnung);
    }
  }

  public static List<int> MaxPreisVon(List<Suchergebnis> suche, string kat) {
    List<int> ergebnis = new List<int>();
    double max = -1.0;

    for(int i = 0; i < suche.Count; ++i) {
      Suchergebnis s = suche[i];

      if(s.Kategorie != kat) continue; // Unpassende Kategorien werden übergangen

      if(s.Preis > max) {
        max = s.Preis;
        ergebnis.Clear(); // Durch Finden eines neuen Max-Preises werden alle bisherigen Ergebnisse ungültig
        ergebnis.Add(i); // Stattdessen neu gefundenes Element als Index hinzufügen
      } else if(s.Preis == max) {
        ergebnis.Add(i); // Weitere Treffer mit dem selben Max-Preis als Index hinzufügen
      }
    }

    return ergebnis;
  }

  public static void aufg2e() {
    Console.WriteLine("Aufgabe 2e");
    List<Suchergebnis> suche = new List<Suchergebnis> {
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Stifte", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Füller", Preis = 16.2 },
      new Suchergebnis() { Kategorie = "Werkzeug", Bezeichnung = "Hammer", Preis = 8.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Mappe", Preis = 16.2 },
    };
    List<int> ergebnis = MaxPreisVon(suche, "Büromaterial");
    foreach(int e in ergebnis) {
      Console.WriteLine(e);
    }
  }

  public static void aufg5a() {
    Kochbuch Lieblingsgerichte = new Kochbuch();
    Lieblingsgerichte.Add("Eintopf", 70);
    Lieblingsgerichte.Add("Pizza", 45);

    Console.WriteLine("Anzahl: " + Lieblingsgerichte.Count);
    Console.WriteLine(Lieblingsgerichte);
  }
  
}

public class Rezept {
  public string Name;

  public int Kochdauer {
    get { return _kochdauer; }
    set {
      if(value > 0) {
        _kochdauer = value;
      }
    }
  }
  private int _kochdauer;

  public bool DauertLang() {
    return _kochdauer > 60;
  }

  public Rezept(string nm) {
    Name = nm;
    _kochdauer = 0;
  }

  public Rezept(string nm, int kd) {
    Name = nm;
    Kochdauer = kd;
  }

  public override string ToString() {
    return "[Rezept Name = ]" +
      Name + " Kochdauer = " +
      _kochdauer + "]";
  }
}

public class Kochbuch {
  public List<Rezept> Rezepte;

  public List<Rezept> LangeRezepte() {
    List<Rezept> lrz = new List<Rezept>();

    foreach(Rezept r in Rezepte) {
      if(r.DauertLang()) {
        lrz.Add(r);
      }
    }

    return lrz;
  }

  public List<int> Finde(string nm) {
    List<int> gefunden = new List<int>();

    for(int i = 0; i < Rezepte.Count; ++i) {
      if(Rezepte[i].Name == nm) {
        gefunden.Add(i);
      }
    }

    return gefunden;
  }

  public double DurchschnittsDauer() {
    double s = 0.0;

    foreach(Rezept r in Rezepte) {
      s += r.Kochdauer;
    }

    return Count > 0 ? s / Count : 0.0;
  }

  public List<Rezept> MaxDauerRezepte() {
    // siehe Aufgabe 2e, MaxPreisVon()
    return null;
  }

  public override string ToString() {
    string ret = "Rezepte:";

    foreach(Rezept r in Rezepte) {
      ret += "\n  " + r;
    }

    return ret;
  }

  public Kochbuch() {
    Rezepte = new List<Rezept>();
  }

  public int Count {
    get {
      return Rezepte.Count;
    }
  }

  public void Add(string nm, int dauer) {
    var rz = new Rezept(nm, dauer);
    Rezepte.Add(rz);
  }

}
