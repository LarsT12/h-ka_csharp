using System;
using System.Collections.Generic;

class Klausur2018WiSe {
  public static void Main() {
    Console.WriteLine("Klausur 2018 WiSe");
    // aufg1a(7, 12);
    // aufg1a(8, 3);
    // aufg1b(25);
    // aufg1c("Hallo");
    // aufg1d();
    // aufg1e();
    // aufg2a();
    // aufg2b();
    // aufg2c();
    // aufg2d();
    aufg2e();
  }

  public static void aufg1a(int i1, int i2) {
    Console.WriteLine("Aufgabe 1a");

    if(i1 - i2 <= 2) {
      Console.WriteLine(i1 / 2.0);
    } else {
      i2 *= 2;
      // Console.WriteLine(i2);
    }
  }

  public static void aufg1b(double d1) {
    while(d1 > 5) {
      d1 -= 3;
      if(Math.Pow(d1, 2) < 10) {
        Console.WriteLine(d1 * 3);
      }
    } 
  }

  public static void aufg1c(string text) {
    int anz = 0;
    foreach(char c in text) {
      Console.Write((int)c + " ");
      if((int)c % 2 == 0) {
        anz += 3;
      }
    }
    Console.WriteLine();
    Console.WriteLine(anz);
  }

  public static void aufg1d() {
    List<int> iifeld = new List<int>() {54, 65, 66, 97};

    foreach(int i in iifeld) {
      if(i >= 65 && i <= 91) {
        Console.WriteLine((char)i);
      }
    }
  }

  public static void aufg1e() {
    List<bool> bfeld = new List<bool>() {true, true, true, true, true, true, true, true, true, true, true};

    for(int i = 0; i < bfeld.Count; i += 5) {
      bfeld[i] = i % 2 == 0;
    }

    foreach(bool b in bfeld) {
      Console.WriteLine(b);
    }
  }

  public static void aufg2a() {
    Suchergebnis suche = new Suchergebnis() { Kategorie = "Kat", Bezeichnung = "Bez", Preis = 12.4 };
    Console.WriteLine(suche.Bezeichnung);
  }

  public static void aufg2b() {
    List<Suchergebnis> suche = new List<Suchergebnis>() {
      new Suchergebnis() { Kategorie = "Kat", Bezeichnung = "Bez", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 1", Preis = 2.0 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 2", Preis = 2.6 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 3", Preis = 2.6 },
    };
    double dPreis = DPreis(suche, "Stift");
    Console.WriteLine(dPreis);
  }

  public static double DPreis(List<Suchergebnis> suche, string kat) {
    double dPreis = 0.0;
    int cnt = 0;

    // Finde passende Daten
    foreach(Suchergebnis s in suche) {
      if(s.Kategorie == kat) {
        dPreis += s.Preis;
        cnt++;
      }
    }

    // Durchschnitt bilden
    if(cnt > 0) {
      dPreis /= cnt;
    }
    return dPreis;
    // return cnt == 0 ? 0.0 : dPreis / cnt;
  }

  public static void aufg2c() {
    List<Suchergebnis> suche = new List<Suchergebnis>() {
      new Suchergebnis() { Kategorie = "Kat", Bezeichnung = "Bez", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 1", Preis = 2.0 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 2", Preis = 2.6 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 3", Preis = 2.6 },
      new Suchergebnis() { Kategorie = "Tablet", Bezeichnung = "T 1", Preis = 22.6 }
    };
    int index = IndexVon(suche, "Stift");
    Console.WriteLine(index);
    index = IndexVon(suche, "Sonstwas");
    Console.WriteLine(index);
  }

  public static int IndexVon(List<Suchergebnis> suche, string kat) {
    int index = -1;

    for(int i = 0; i < suche.Count; ++i) {
      if(suche[i].Kategorie == kat) {
        index = i;
      }
    }

    return index;
  }

  public static void aufg2d() {
    List<Suchergebnis> suche = new List<Suchergebnis>() {
      new Suchergebnis() { Kategorie = "Kat", Bezeichnung = "Bez", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 1", Preis = 2.0 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 2", Preis = 2.6 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 3", Preis = 2.6 },
      new Suchergebnis() { Kategorie = "Tisch", Bezeichnung = "T 1", Preis = 22.6 }
    };
    List<Suchergebnis> ergebnis = AlleVon(suche, "Stift");
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

  public static void aufg2e() {
    List<Suchergebnis> suche = new List<Suchergebnis>() {
      new Suchergebnis() { Kategorie = "Kat", Bezeichnung = "Bez", Preis = 12.4 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 1", Preis = 2.0 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 2", Preis = 2.6 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 3", Preis = 2.2 },
      new Suchergebnis() { Kategorie = "Stift", Bezeichnung = "S 4", Preis = 2.6 },
      new Suchergebnis() { Kategorie = "Tisch", Bezeichnung = "T 1", Preis = 22.6 }
    };
    List<int> ergebnis = MaxPreisVon(suche, "Stift");
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

  public struct Suchergebnis {
    public string Kategorie;
    public string Bezeichnung;
    public double Preis;
  }
}