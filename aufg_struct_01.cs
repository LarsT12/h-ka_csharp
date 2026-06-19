using System;

class AufgabeStruct01 {
  static void Main(string[] args) {
    Console.WriteLine("Aufgabe Struct 01");

    Raum[] räume = new Raum[5];
    räume[0] = new Raum("010", 15, true);
    räume[1] = new Raum("011", 20);

    // räume[0].Zugang(5);
    räume[0].Buchen();
    räume[0].Zugang(5);
    räume[0].Zugang(1);
    Console.WriteLine(räume[0]);
    räume[0].Abgang(3);
    // räume[0].Freigeben();
    räume[0].Abgang(3);
    räume[0].Freigeben();
    Console.WriteLine(räume[0]);

    räume[1].Buchen();
    räume[1].Zugang(12);
    räume[1].Abgang(5);
    Console.WriteLine(räume[1]);
    räume[1].Abgang(7);
    räume[1].Freigeben();
    Console.WriteLine(räume[1]);
  }

  struct Raum {
    string nummer;
    int kapazität;
    bool labor;
    bool gebucht;
    int belegung;

    public Raum(string nr, int kapa, bool l = false) {
      this.nummer = nr;
      this.kapazität = kapa;
      this.labor = l;
      gebucht = false;
      belegung = 0;
    }

    public void Buchen() {
      if (gebucht)
        throw new Exception("Raum ist bereits gebucht!");
      
      gebucht = true;
    }

    public void Freigeben() {
      if (!gebucht)
        throw new Exception("Raum ist nicht gebucht!");

      if (belegung > 0)
        throw new Exception("Raum kann nicht freigegeben werden, da sich noch Personen im Raum befinden!");
      
      gebucht = false;
    }

    public void Zugang(int personen) {
      if (!gebucht)
        throw new Exception("Raum ist nicht gebucht!");

      if (personen < 0)
        throw new Exception("Anzahl der Personen muss positiv sein!");
      
      if (belegung + personen > kapazität)
        throw new Exception("Zu viele Personen für diesen Raum!");
      
      belegung += personen;
    }

    public void Abgang(int personen) {
      if (!gebucht)
        throw new Exception("Raum ist nicht gebucht!");
        
      if (personen < 0)
        throw new Exception("Anzahl der Personen muss positiv sein!");
      
      if (belegung - personen < 0)
        throw new Exception("Es befinden sich nicht so viele Personen im Raum!");
      
      belegung -= personen;
    }

    public override string ToString()
      => $"Raum {nummer} (Kapazität: {kapazität}, {(labor ? "Labor" : "Normalraum")}), {(gebucht ? $"belegt mit {belegung} Personen" : "frei")}";
  }
}