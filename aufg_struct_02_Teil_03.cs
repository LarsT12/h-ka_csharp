using System;

class AufgabeStruct02Teil03 {
  static void Main(string[] args) {
    Console.WriteLine("Aufgabe Struct 02 - Teil 03");

    Sitzplatz[,] saal = new Sitzplatz[5, 8];

    for (int reihe = 0; reihe < saal.GetLength(0); reihe++) {
      for (int platz = 0; platz < saal.GetLength(1); platz++) {
        if (reihe < 3)
          saal[reihe, platz] = new Sitzplatz("Standard", 900, false);
        else if (reihe == 3)
          saal[reihe, platz] = new Sitzplatz("Komfort", 1200, true);
        else
          saal[reihe, platz] = new Sitzplatz("Loge", 1500, true);
      }
    }

    saal[0, 3].Reservieren("Mina");
    saal[2, 5].Reservieren("Jonas");
    saal[4, 1].Reservieren("Samira");

    for (int reihe = 0; reihe < saal.GetLength(0); reihe++) {
      for (int platz = 0; platz < saal.GetLength(1); platz++) {
        Console.WriteLine($"Reihe {reihe + 1}, Platz {platz + 1}: {saal[reihe, platz]}");
      }
    }
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
