using System;

class AufgabeStruct02Teil01 {
  static void Main(string[] args) {
    Console.WriteLine("Aufgabe Struct 02 - Teil 01");

    Sitzplatz platz = new Sitzplatz("Standard", 900, false);
    Console.WriteLine(platz);
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

    public override string ToString()
      => $"{_kategorie}, {_preisInCent / 100.0:C}, {(_hatGetraenkehalter ? "mit" : "ohne")} Getränkehalter, {(_istReserviert ? $"reserviert für {_reserviertFuer}" : "frei")}";
  }
}
