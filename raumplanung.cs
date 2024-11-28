using System;

class Raumplanung {
  static void Main() {
    Console.WriteLine("Raumplanung H-KA gestaret...");
    Raum r1 = new Raum('E', "010");
    r1.Kapazitaet = 21;

    Raum r2 = new Raum('E', "011", 17);

    Console.WriteLine(r1.Gebaeude + r1.Nummer + ": " + r1.Kapazitaet);
    Console.WriteLine(r2.Gebaeude + r2.Nummer + ": " + r2.Kapazitaet);

    Studiengruppe s1 = new Studiengruppe("ES01");
    s1.Groesse = 12;

    Dozent d1 = new Dozent("UMU");
    Dozent d2 = new Dozent("LTH");

    Vorlesung v1 = new Vorlesung("C#", r1, s1, d2);
    Console.WriteLine(v1.Name + ": Raum " + v1.Raum.Gebaeude + v1.Raum.Nummer + " (" + v1.Raum.Kapazitaet + ")" + ", Studiengruppe " + v1.Studis.Name + ", Dozent " + v1.Dozent.Name);
    
  }
}

class Kalender {
  
}

class Vorlesung {
  public string Name { get; }
  public Raum Raum { get; }
  public Studiengruppe Studis { get; }
  public Dozent Dozent { get; }

  public Vorlesung(string name, Raum raum, Studiengruppe studis, Dozent dozent) {
    Name = name;
    Raum = raum;
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

  public Studiengruppe(string name) {
    Name = name;
  }
}

class Dozent {
  public string Name { get; }

  public Dozent(string name) {
    Name = name;
  }
}