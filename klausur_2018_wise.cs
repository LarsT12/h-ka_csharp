using System;
using System.Collections.Generic;

class Klausur2018WiSe {
  public static void Main() {
    Console.WriteLine("Klausur 2018 WiSe");
    // aufg2a();
    //aufg2b();
    //aufg2c();
    //aufg2d();
    aufg2e();
  }

  public struct Suchergebnis {
    public string Kategorie;
    public string Bezeichnung;
    public double Preis;
  }

  public static void aufg2a() {
    Console.WriteLine("Aufgabe 2a");
    Suchergebnis suche = new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Radiergummi", Preis = 12.4 };
    Console.WriteLine(suche.Bezeichnung);
  }

  public static void aufg2b() {
    Console.WriteLine("Aufgabe 2b");
    List<Suchergebnis> suche = new List<Suchergebnis> {
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Stifte", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Füller", Preis = 16.2 },
      new Suchergebnis() { Kategorie = "Werkzeug", Bezeichnung = "Hammer", Preis = 8.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Mappe", Preis = 14.1 },
    };
    double d = DPreis(suche, "Büromaterial");
    Console.WriteLine(d);
  }

  public static double DPreis(List<Suchergebnis> suche, string kat) {
    double d = 0.0;
    int cnt = 0;

    foreach(Suchergebnis s in suche) {
      if(s.Kategorie == kat) {
        d += s.Preis;
        ++cnt;
      }
    }
    /*
    if(cnt > 1) {
      d /= cnt;
    }
    */

    //return d;
    return cnt == 0 ? 0.0 : d / cnt;
  }

  public static void aufg2c() {
    Console.WriteLine("Aufgabe 2c");
    List<Suchergebnis> suche = new List<Suchergebnis> {
      new Suchergebnis() { Kategorie = "Sonstiges", Bezeichnung = "Stifte", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Füller", Preis = 16.2 },
      new Suchergebnis() { Kategorie = "Werkzeug", Bezeichnung = "Hammer", Preis = 8.4 },
      new Suchergebnis() { Kategorie = "Büromaterial", Bezeichnung = "Mappe", Preis = 14.1 },
    };
    int i = IndexVon(suche, "Büromaterial");
    Console.WriteLine(i);
  }

  public static int IndexVon(List<Suchergebnis> suche, string kat) {
    for(int i = suche.Count - 1; i > -1; --i) {
      if(suche[i].Kategorie == kat) {
        return i;
      }
    }
    return -1;
  }

  /*
  public static int IndexVon(List<Suchergebnis> suche, string kat) {
    int index = -1;

    for(int i = 0; i < suche.Count; ++i) {
      Suchergebnis s = suche[i];
      if(s.Kategorie == kat) {
        index = i;
      }
    }
    return index;
  }
  */

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

  public static List<Suchergebnis> AlleVon(List<Suchergebnis> suche, string kat) {
    List<Suchergebnis> ergebnis = new List<Suchergebnis>();

    foreach(Suchergebnis s in suche) {
      if(s.Kategorie == kat) {
        ergebnis.Add(s);
      }
    }

    return ergebnis;
  }

  /*
  public static List<Suchergebnis> AlleVon(List<Suchergebnis> suche, string kat) {
    return suche.Where(s => s.Kategorie == kat).ToList();
  }
  */

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
  
  public static List<int> MaxPreisVon(List<Suchergebnis> suche, string kat) {
    List<int> ergebnis = new List<int>();
    double max = -1.0;

    foreach(Suchergebnis s in suche) {
      if(s.Kategorie == kat && s.Preis > max) {
        max = s.Preis;
      }
    }

    for(int i = 0; i < suche.Count; ++i) {
      if(suche[i].Kategorie == kat && suche[i].Preis == max) {
        ergebnis.Add(i);
      }
    }

    return ergebnis;
  }

}
