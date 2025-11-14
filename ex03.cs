using System;
using System.Collections.Generic;

class Strukturen {
  static void Main(string[] args) {
    List<Kontakt> Adressbuch = new List<Kontakt>();
    Adressbuch.Add(new Kontakt("Lars", "Larsson", "lars@lars.son"));
    Kontakt a = new Kontakt("Anna", "Andersdotir", "andra@gmx.com");
    a.Telefonnummer = "01234 56789";
    Adressbuch.Add(a);

    foreach(Kontakt k in Adressbuch) {
      Console.WriteLine($"{k.Vorname}, {k.Emailadresse}, {k.Telefonnummer}");
    }
  }
}

class Kontakt {
  public string Vorname;
  public string Nachname;
  public string Emailadresse;
  public string Telefonnummer;

  public Kontakt(string v, string n, string m) {
    Vorname = v;
    Nachname = n;
    Emailadresse = m;
  }

}

