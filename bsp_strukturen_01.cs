using System;

class BeispieleStrukturen {
  static void Main(string[] args) {
    Console.WriteLine("Strukturen in C#");
    Console.WriteLine("----");

    // Beispiel 0: Standardtpyen
    int k = 5;
    double d = 3.14;
    string s = "Hallo";
    Console.WriteLine($"k: {k}, d: {d}, s: {s}");

    // Beispiel 1: Ein Raum, Werte einzeln setzen
    Raum raumEins;
    raumEins.nummer = "A101";
    raumEins.plaetze = 30;
    raumEins.hatBeamer = true;
    Console.WriteLine($"Raum: {raumEins.nummer}, Plaetze: {raumEins.plaetze}, Beamer: {raumEins.hatBeamer}");

    Console.WriteLine("----");

    // Beispiel 2: Ein Raum mit Konstruktor und Stellungsparametern
    Raum raumZwei = new Raum("B201", 50, false);
    Console.WriteLine($"Raum: {raumZwei.nummer}, Plaetze: {raumZwei.plaetze}, Beamer: {raumZwei.hatBeamer}");

    Console.WriteLine("----");

    // Beispiel 3: Ein Raum mit Konstruktor und benannten Parametern
    Raum raumDrei = new Raum(plaetze: 20, nummer: "C305", hatBeamer: true);
    Console.WriteLine($"Raum: {raumDrei.nummer}, Plaetze: {raumDrei.plaetze}, Beamer: {raumDrei.hatBeamer}");

    Console.WriteLine("----");

    // Beispiel 4: Ein Raum mit Objekt-Initialisierer
    Raum raumVier = new Raum { nummer = "D110", plaetze = 15, hatBeamer = false };
    Console.WriteLine($"Raum: {raumVier.nummer}, Plaetze: {raumVier.plaetze}, Beamer: {raumVier.hatBeamer}");

    Console.WriteLine("----");

    // Beispiel 5a: Ein Array von int
    int[] zahlen = new int[5];
    zahlen[0] = 10;
    zahlen[1] = 20;
    zahlen[2] = 30;
    zahlen[3] = 40;
    zahlen[4] = 50;
    Console.WriteLine($"Zahlen: {string.Join(", ", zahlen)}");

    // Beispiel 5b: Ein Array von Raeumen
    Raum[] raeume = new Raum[4];
    raeume[0] = raumEins;
    raeume[1] = raumZwei;
    raeume[2] = raumDrei;
    raeume[3] = raumVier;

    int platzSumme = 0;
    for(int i = 0; i < raeume.Length; ++i) {
      platzSumme += raeume[i].plaetze;
      Console.WriteLine($"Raum {i}: {raeume[i].nummer}, Plaetze: {raeume[i].plaetze}");
    }
    Console.WriteLine($"Gesamtzahl der Plaetze: {platzSumme}");

    Console.WriteLine("----");

    // Beispiel 6: Ein Gebaeude
    Gebaeude gebaeudeA;
    gebaeudeA.name = "A";
    gebaeudeA.stockwerke = 4;
    Console.WriteLine($"Gebaeude: {gebaeudeA.name}, Stockwerke: {gebaeudeA.stockwerke}");

    Console.WriteLine("----");

    // Beispiel 7: Ein Labor
    Labor laborInfo1;
    laborInfo1.name = "Informatik-Labor";
    laborInfo1.computer = 25;
    Console.WriteLine($"Labor: {laborInfo1.name}, Computer: {laborInfo1.computer}");

    Console.WriteLine("----");

    // Beispiel 8: Ein Seminar
    Seminar prog1;
    prog1.titel = "Programmieren 1";
    prog1.raumNummer = "E003";
    Console.WriteLine($"Seminar: {prog1.titel}, Raum: {prog1.raumNummer}");

    Console.WriteLine("----");

    // Beispiel 9: Eine einfache Nutzung mit Kopie
    Dozent dozent1;
    dozent1.name = new Name { anrede = "Frau", vorname = "Claudia", nachname = "Klein" };
    dozent1.fach = "Mathematik";

    Dozent dozent2 = dozent1;
    dozent2.name = new Name { anrede = "Herr", vorname = "Karsten", nachname = "Braun" };

    Console.WriteLine($"Dozent 1: {dozent1.name.anrede} {dozent1.name.nachname}, Fach: {dozent1.fach}");
    Console.WriteLine($"Dozent 2: {dozent2.name.anrede} {dozent2.name.nachname}, Fach: {dozent2.fach}");
  }
}

struct Raum {
  public string nummer;
  public int plaetze;
  public bool hatBeamer;

  public Raum(string nummer, int plaetze, bool hatBeamer) {
    this.nummer = nummer;
    this.plaetze = plaetze;
    this.hatBeamer = hatBeamer;
  }
}

struct Gebaeude {
  public string name;
  public int stockwerke;
}

struct Labor {
  public string name;
  public int computer;
}

struct Seminar {
  public string titel;
  public string raumNummer;
}

struct Dozent {
  public Name name;
  public string fach;
}

struct Name {
  public string anrede;
  public string vorname;
  public string nachname;
}
