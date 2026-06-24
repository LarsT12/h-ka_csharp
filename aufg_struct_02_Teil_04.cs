using System;

class AufgabeStruct02Teil04 {
  static void Main(string[] args) {
    Console.WriteLine("Aufgabe Struct 02 - Teil 04");

    Sitzplatz[,] saal = new Sitzplatz[5, 8];

    InitialisiereSaal(saal);

    saal[0, 3].Reservieren("Mina");
    saal[2, 5].Reservieren("Jonas");
    saal[4, 1].Reservieren("Samira");
    saal[4, 2].Reservieren("Noah");

    GibSaalAus(saal);

    Console.WriteLine();
    Console.WriteLine($"Freie Plätze: {ZaehleFreiePlaetze(saal)}");
    Console.WriteLine($"Reservierte Plätze: {ZaehleReserviertePlaetze(saal)}");
    Console.WriteLine($"Umsatz durch Reservierungen: {BerechneReserviertenUmsatz(saal) / 100.0:C}");

    Console.WriteLine();
    Console.WriteLine("Freie Logenplätze:");
    GibFreiePlaetzeEinerKategorieAus(saal, "Loge");
  }

  static void InitialisiereSaal(Sitzplatz[,] saal) {
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
  }

  static void GibSaalAus(Sitzplatz[,] saal) {
    for (int reihe = 0; reihe < saal.GetLength(0); reihe++) {
      for (int platz = 0; platz < saal.GetLength(1); platz++) {
        Console.WriteLine($"Reihe {reihe + 1}, Platz {platz + 1}: {saal[reihe, platz]}");
      }
    }
  }

  static int ZaehleFreiePlaetze(Sitzplatz[,] saal) {
    int freiePlaetze = 0;

    for (int reihe = 0; reihe < saal.GetLength(0); reihe++) {
      for (int platz = 0; platz < saal.GetLength(1); platz++) {
        if (saal[reihe, platz].IstFrei())
          freiePlaetze++;
      }
    }

    return freiePlaetze;
  }

  static int ZaehleReserviertePlaetze(Sitzplatz[,] saal) {
    int reserviertePlaetze = 0;

    for (int reihe = 0; reihe < saal.GetLength(0); reihe++) {
      for (int platz = 0; platz < saal.GetLength(1); platz++) {
        if (saal[reihe, platz].IstReserviert())
          reserviertePlaetze++;
      }
    }

    return reserviertePlaetze;
  }

  static int BerechneReserviertenUmsatz(Sitzplatz[,] saal) {
    int umsatz = 0;

    for (int reihe = 0; reihe < saal.GetLength(0); reihe++) {
      for (int platz = 0; platz < saal.GetLength(1); platz++) {
        if (saal[reihe, platz].IstReserviert())
          umsatz += saal[reihe, platz].PreisInCent();
      }
    }

    return umsatz;
  }

  static void GibFreiePlaetzeEinerKategorieAus(Sitzplatz[,] saal, string kategorie) {
    for (int reihe = 0; reihe < saal.GetLength(0); reihe++) {
      for (int platz = 0; platz < saal.GetLength(1); platz++) {
        if (saal[reihe, platz].HatKategorie(kategorie) && saal[reihe, platz].IstFrei())
          Console.WriteLine($"Reihe {reihe + 1}, Platz {platz + 1}");
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

    public bool IstReserviert() {
      return _istReserviert;
    }

    public bool IstFrei() {
      return !_istReserviert;
    }

    public int PreisInCent() {
      return _preisInCent;
    }

    public bool HatKategorie(string kategorie) {
      return _kategorie == kategorie;
    }

    public override string ToString()
      => $"{_kategorie}, {_preisInCent / 100.0:C}, {(_hatGetraenkehalter ? "mit" : "ohne")} Getränkehalter, {(_istReserviert ? $"reserviert für {_reserviertFuer}" : "frei")}";
  }
}
