using System;

class Raumplanung {
  static void Main() {
    Console.WriteLine("Raumplanung H-KA gestaret...");
    Raum r1 = new Raum('E', "010");
    r1.Kapazitaet = 21;

    Raum r2 = new Raum('E', "011", 17);

    Console.WriteLine(r1.Gebaeude + r1.Nummer + ": " + r1.Kapazitaet);
    Console.WriteLine(r2.Gebaeude + r2.Nummer + ": " + r2.Kapazitaet);
  }
}

class Kalender {

}

class Vorlesung {
  public string Name;

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
  public string Name;
  public int Groesse;
}

class Dozent {
  public string Name;
}