using System;

class AufgabeStruct02Teil02 {
  static void Main(string[] args) {
    Console.WriteLine("Aufgabe Struct 02 - Teil 02");

    Sitzplatz platz1 = new Sitzplatz("Standard", 900, false);
    Sitzplatz platz2 = new Sitzplatz("Komfort", 1200, true);

    platz1.Reservieren("Mina");
    Console.WriteLine(platz1);

    platz1.Freigeben();
    Console.WriteLine(platz1);

    platz2.Reservieren("Jonas");
    Console.WriteLine(platz2);
  }

  struct Sitzplatz {
    private string _kategorie;
    private int _preisInCent;
    private bool _hatGetraenkehalter;
    private bool _istReserviert;
    private string _reserviertFuer;

    public Sitzplatz(string kategorie, int preisInCent, bool hatGetraenkehalter) {
      if (kategorie == "")
        throw new Exception("Kategorie darf nicht leer sein!");

      if (preisInCent < 0)
        throw new Exception("Preis muss positiv sein!");

      _kategorie = kategorie;
      _preisInCent = preisInCent;
      _hatGetraenkehalter = hatGetraenkehalter;
      _istReserviert = false;
      _reserviertFuer = "";
    }

    public void Reservieren(string name) {
      if (_istReserviert)
        throw new Exception("Sitzplatz ist bereits reserviert!");

      if (name == "")
        throw new Exception("Name darf nicht leer sein!");

      _istReserviert = true;
      _reserviertFuer = name;
    }

    public void Freigeben() {
      if (!_istReserviert)
        throw new Exception("Sitzplatz ist nicht reserviert!");

      _istReserviert = false;
      _reserviertFuer = "";
    }

    public override string ToString()
      => $"{_kategorie}, {_preisInCent / 100.0:C}, {(_hatGetraenkehalter ? "mit" : "ohne")} Getränkehalter, {(_istReserviert ? $"reserviert für {_reserviertFuer}" : "frei")}";
  }
}
