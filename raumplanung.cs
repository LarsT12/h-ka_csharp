using System;
using System.Collections.Generic;

class Raumplanung {
  static void Main() {
    try {
      Console.WriteLine("Raumplanung H-KA gestaret...");
      Raum r1 = new Raum('E', "010");
      r1.Kapazitaet = 21;

      Raum r2 = new Raum('E', "011", 17);

      Studiengruppe s1 = new Studiengruppe("ES01");
      s1.Groesse = 12;
      Studiengruppe s2 = new Studiengruppe("ABC01");
      s2.Groesse = 20;

      Dozent d1 = new Dozent("UMU");
      Dozent d2 = new Dozent("LTH");

      Vorlesung v1 = new Vorlesung("C#", s1, d2);
      Vorlesung v2 = new Vorlesung("Inf", s2, d1);

      Buchung b1 = new Buchung("Do", 1, r1, v1);
      Buchung b2 = new Buchung("Do", 1, r1, v2);
      Buchung b3 = new Buchung("Fr", 2, r1, v2);

      Kalender k = new Kalender();
      k.AddBuchung(b1);
      k.AddBuchung(b2);
      k.AddBuchung(b3);
      Console.WriteLine(k);
    }
    catch(Exception e) {
      Console.WriteLine("Es ist ein Fehler aufgetreten:");
      Console.WriteLine($"  {e.Message}");
    }
  }
}

class Kalender {
  //private readonly string[] Tage = { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };
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

  public override string ToString() {
    string ret = "";

    foreach(Buchung b in Buchungen) {
      ret += b + "\n";
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