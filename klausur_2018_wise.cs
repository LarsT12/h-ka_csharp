using System;
using System.Collections.Generic;

class Klausur2018WiSe {
  public static void Main() {
    Console.WriteLine("Klausur 2018 WiSe");
    // aufg2a();
    aufg2b();
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
  }

  public static double DPreis(List<Suchergebnis> suche, string kat) {
    return 0.0;
  }

}
