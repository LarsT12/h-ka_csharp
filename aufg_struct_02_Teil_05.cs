using System;

class AufgabeStruct02Teil05 {
  static void Main(string[] args) {
    Console.WriteLine("Aufgabe Struct 02 - Teil 05");

    Saal saal1 = new Saal(5, 8);

    saal1.Reservieren(1, 4, "Mina");
    saal1.Reservieren(3, 6, "Jonas");
    saal1.Reservieren(5, 2, "Samira");
    saal1.Reservieren(5, 3, "Noah");

    saal1.GibSaalAus();

    Console.WriteLine();
    Console.WriteLine($"Freie Plätze: {saal1.ZaehleFreiePlaetze()}");
    Console.WriteLine($"Reservierte Plätze: {saal1.ZaehleReserviertePlaetze()}");
    Console.WriteLine($"Umsatz durch Reservierungen: {saal1.BerechneReserviertenUmsatz() / 100.0:C}");

    Console.WriteLine();
    Console.WriteLine("Freie Logenplätze:");
    saal1.GibFreiePlaetzeEinerKategorieAus("Loge");

    Console.WriteLine();
    Console.WriteLine("Mehrere Säle:");

    Saal[] saele = new Saal[2];
    saele[0] = new Saal(5, 8);
    saele[1] = new Saal(4, 6);

    saele[0].Reservieren(2, 1, "Lea");
    saele[1].Reservieren(4, 3, "Ben");

    for (int i = 0; i < saele.Length; i++) {
      Console.WriteLine($"Saal {i + 1}: {saele[i].ZaehleReserviertePlaetze()} reservierte Plätze");
    }
  }

  struct Saal {
    private Sitzplatz[,] _plaetze;

    public Saal(int anzahlReihen, int plaetzeProReihe) {
      if (anzahlReihen <= 0)
        throw new Exception("Anzahl der Reihen muss positiv sein!");

      if (plaetzeProReihe <= 0)
        throw new Exception("Anzahl der Plätze pro Reihe muss positiv sein!");

      _plaetze = new Sitzplatz[anzahlReihen, plaetzeProReihe];
      InitialisiereSaal();
    }

    private void InitialisiereSaal() {
      for (int reihe = 0; reihe < _plaetze.GetLength(0); reihe++) {
        for (int platz = 0; platz < _plaetze.GetLength(1); platz++) {
          if (reihe < 3)
            _plaetze[reihe, platz] = new Sitzplatz("Standard", 900, false);
          else if (reihe == 3)
            _plaetze[reihe, platz] = new Sitzplatz("Komfort", 1200, true);
          else
            _plaetze[reihe, platz] = new Sitzplatz("Loge", 1500, true);
        }
      }
    }

    public void Reservieren(int reihe, int platz, string name) {
      PruefePosition(reihe, platz);
      _plaetze[reihe - 1, platz - 1].Reservieren(name);
    }

    public void Freigeben(int reihe, int platz) {
      PruefePosition(reihe, platz);
      _plaetze[reihe - 1, platz - 1].Freigeben();
    }

    public void GibSaalAus() {
      for (int reihe = 0; reihe < _plaetze.GetLength(0); reihe++) {
        for (int platz = 0; platz < _plaetze.GetLength(1); platz++) {
          Console.WriteLine($"Reihe {reihe + 1}, Platz {platz + 1}: {_plaetze[reihe, platz]}");
        }
      }
    }

    public int ZaehleFreiePlaetze() {
      int freiePlaetze = 0;

      for (int reihe = 0; reihe < _plaetze.GetLength(0); reihe++) {
        for (int platz = 0; platz < _plaetze.GetLength(1); platz++) {
          if (_plaetze[reihe, platz].IstFrei())
            freiePlaetze++;
        }
      }

      return freiePlaetze;
    }

    public int ZaehleReserviertePlaetze() {
      int reserviertePlaetze = 0;

      for (int reihe = 0; reihe < _plaetze.GetLength(0); reihe++) {
        for (int platz = 0; platz < _plaetze.GetLength(1); platz++) {
          if (_plaetze[reihe, platz].IstReserviert())
            reserviertePlaetze++;
        }
      }

      return reserviertePlaetze;
    }

    public int BerechneReserviertenUmsatz() {
      int umsatz = 0;

      for (int reihe = 0; reihe < _plaetze.GetLength(0); reihe++) {
        for (int platz = 0; platz < _plaetze.GetLength(1); platz++) {
          if (_plaetze[reihe, platz].IstReserviert())
            umsatz += _plaetze[reihe, platz].PreisInCent();
        }
      }

      return umsatz;
    }

    public void GibFreiePlaetzeEinerKategorieAus(string kategorie) {
      for (int reihe = 0; reihe < _plaetze.GetLength(0); reihe++) {
        for (int platz = 0; platz < _plaetze.GetLength(1); platz++) {
          if (_plaetze[reihe, platz].HatKategorie(kategorie) && _plaetze[reihe, platz].IstFrei())
            Console.WriteLine($"Reihe {reihe + 1}, Platz {platz + 1}");
        }
      }
    }

    private void PruefePosition(int reihe, int platz) {
      if (reihe < 1 || reihe > _plaetze.GetLength(0))
        throw new Exception("Reihe existiert nicht!");

      if (platz < 1 || platz > _plaetze.GetLength(1))
        throw new Exception("Platz existiert nicht!");
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
