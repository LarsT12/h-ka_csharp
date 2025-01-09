using System;
using System.Collections.Generic;
using System.IO;

class Raumplanung {
  static void Main() {
    try {
      Console.WriteLine("Raumplanung H-KA gestaret...");
      Raum r1 = new Raum('E', "010");
      r1.Kapazitaet = 21;

      Raum r2 = new Raum('E', "011", 27);

      Studiengruppe s1 = new Studiengruppe("ES01");
      s1.Groesse = 12;
      Studiengruppe s2 = new Studiengruppe("ABC01");
      s2.Groesse = 20;

      Dozent d1 = new Dozent("UMU");
      Dozent d2 = new Dozent("LTH");

      Vorlesung v1 = new Vorlesung("C#", s1, d2);
      Vorlesung v2 = new Vorlesung("Inf", s2, d1);

      Buchung b1 = new Buchung("Do", 1, r1, v1);
      Buchung b2 = new Buchung("Do", 1, r2, v2);
      Buchung b3 = new Buchung("Fr", 2, r1, v2);

      Kalender k = new Kalender();
      k.AddBuchung(b1);
      k.AddBuchung(b2);
      k.AddBuchung(b3);
      Console.WriteLine(k);
      k.SpeichereKalenderInDatei();
    }
    catch(Exception e) {
      Console.WriteLine("Es ist ein Fehler aufgetreten:");
      Console.WriteLine($"  {e.Message}");
    }
  }
}

class Kalender {
  private readonly string[] Tage = { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };
  private List<Buchung> Buchungen = new List<Buchung>();

  public void AddBuchung(Buchung nb) {
    try {
      foreach(Buchung eb in Buchungen) {
        if(
          eb.Tag == nb.Tag &&
          eb.Block == nb.Block &&
          eb.Raum == nb.Raum
        ) 
        {
          throw new Exception($"Am {nb.Tag}, Block {nb.Block}, ist {nb.Raum} bereits belegt.");
        }
      }
      Buchungen.Add(nb);
    } 
    catch(Exception e) {
      Console.WriteLine(e.Message);
    }
    finally {
      Console.WriteLine($"Anzahl der Buchungen: {Buchungen.Count}");
    }
  }

  public void SpeichereKalenderInDatei() {
    string dateiname = "Raumplanung.txt";
    try {
      File.WriteAllText(dateiname, ToString());
      Console.WriteLine($"Kalender wurde erfolgreich in {dateiname} gespeichert.");
    } catch (Exception ex) {
      Console.WriteLine($"Fehler beim Speichern der Datei: {ex.Message}");
    }
}

  public override string ToString() {
    string ret = "";
    string blocklabel = "Block ";
    const int sp = -12; // Spaltenbreite für die Ausrichtung
    string trennlinie = new string('-', (Tage.Length + 1) * (Math.Abs(sp) + 1)) + "\n";

    // Kopfzeile mit Wochentagen
    ret += $"{"", sp}|"; // Leerfeld für die Block-Beschriftung
    foreach (string t in Tage) {
      ret += $"{t, sp}|";
    }
    ret += "\n";
    ret += trennlinie;

    // Für jeden der 4 Zeitblöcke
    for (int block = 1; block <= 4; block++) {
      // Linke Spalte mit Block-Beschriftung
      ret += $"{blocklabel + block, sp}|";

      // Für jeden Wochentag
      foreach (string tag in Tage) {
        // Finde alle Buchungen für diesen Tag und Block
        List<Buchung> buchungenAnTagUndBlock = Buchungen.FindAll(b => b.Tag == tag && b.Block == block);
        // Sammle die Raumnummern
        List<string> raumNummern = new List<string>();
        foreach (Buchung b in buchungenAnTagUndBlock) {
          raumNummern.Add($"{b.Raum.Gebaeude}{b.Raum.Nummer}");
        }
        // Erstelle eine kommagetrennte Liste der Raumnummern
        string raeume = string.Join(",", raumNummern);
        // Füge die Raumnummern zur Ausgabe hinzu, korrekt formatiert
        ret += $"{raeume, sp}|";
      }
      ret += "\n"; // Zeilenumbruch nach jedem Zeitblock

      // Linie unter dem aktuellen Block
      ret += trennlinie;
    }

    return ret;
  }
}

class Buchung {
  public string Tag { get; }
  public int Block { get; }
  public Raum Raum { get; }
  public Vorlesung Vorlesung { get; }

  public Buchung(string tag, int block, Raum raum, Vorlesung vorlesung) {
    if(raum.Kapazitaet < vorlesung.Studis.Groesse) {
      throw new Exception($"{raum} bietet nicht genügend Platz für {vorlesung.Studis.Groesse} Studierende!");
    }

    Tag = tag;
    Block = block;
    Raum = raum;
    Vorlesung = vorlesung;
  }

  public override string ToString() => $"{Tag}, Block {Block}: {Vorlesung} im {Raum}";
}

class Vorlesung {
  public string Name { get; }
  public Studiengruppe Studis { get; }
  public Dozent Dozent { get; }

  public override string ToString() => $"Vorlesung {Name}: {Studis}, {Dozent}";

  public Vorlesung(string name, Studiengruppe studis, Dozent dozent) {
    Name = name;
    Studis = studis;
    Dozent = dozent;
  }

}

class Raum {
  public char Gebaeude { get; }
  public string Nummer { get; }
  
  private int _Kapazitaet;
  public int Kapazitaet {
    get {
      return _Kapazitaet;
    }
    set {
      if(value < 1) throw new Exception("Kapazität muss > 0 sein!");
      if(value > 499) throw new Exception("Kapazität muss < 500 sein!");

      _Kapazitaet = value;
    }
  }

  public override string ToString() => $"Raum {Gebaeude}{Nummer} ({Kapazitaet})";


  public Raum(char Gebaeude, string Nr) {
    this.Gebaeude = Gebaeude;
    Nummer = Nr;
    Console.WriteLine("Raum " + this.Gebaeude + Nummer + " erzeugt");
  }

  public Raum(char Gebaeude, string Nr, int kapa) {
    this.Gebaeude = Gebaeude;
    Nummer = Nr;
    Kapazitaet = kapa;
    Console.WriteLine("Raum " + this.Gebaeude + Nummer + " erzeugt");
  }
}

class Studiengruppe {
  public string Name { get; }
  public int Groesse;

  public override string ToString() => $"Studiengruppe {Name} ({Groesse})";

  public Studiengruppe(string name) {
    Name = name;
  }
}

class Dozent {
  public string Name { get; }

  public override string ToString() => $"Dozent {Name}";

  public Dozent(string name) {
    Name = name;
  }
}