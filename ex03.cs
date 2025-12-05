using System;
using System.Collections.Generic;

class Strukturen {
  static void Main(string[] args) {
    int maxL = Kontakt.MaxVornameLaenge;

    List<Kontakt> Adressbuch = new List<Kontakt>();
    Adressbuch.Add(new Kontakt("Lars", "Larsson", "lars@lars.son"));
    Kontakt a = new Kontakt("Anna", "Andersdotir", "andra@gmx.com");
    a.Telefonnummer = "01234 56789";
    a.Adresse = "Musterstr. 1, 12345 Musterstadt";
    Adressbuch.Add(a);

    string vorname = "Susan Singh-Simonsen";
    if(vorname.Length > Kontakt.MaxVornameLaenge) {
      vorname = vorname.Substring(0, Kontakt.MaxVornameLaenge - 3) + "...";
    }
    Kontakt b = new Kontakt(vorname, "Petersen", "p@p.com", "0989 24545", "Beispielweg 5, 54321 Beispielstadt");
    Adressbuch.Add(b);
    // Console.WriteLine(b.ToString());
    b.Call();

    foreach(Kontakt k in Adressbuch) {
      Console.WriteLine(k.Vorname);
    }

    b.SetNachname("NeuerNachname");
    b.Nachname = "NochEinNeuerNachnameNochEinNeuerNachnameNochEinNeuerNachnameNochEinNeuerNachnameNochEinNeuerNachname";
    Console.WriteLine(b.Nachname);
    // Console.WriteLine($"Vorname: {Kontakt.FindByEmail(Adressbuch, "p@p.com").Vorname}");
  }
}

class Kontakt {
   // Klassenvariablen
  public static int anzahlKontakte = 0;
  public const int MaxVornameLaenge = 10;
  public const int MaxNachnameLaenge = 30;
  
  // Objektvariablen
  public string Vorname { get; private set; }

  private string _nachname;
  public string Nachname {
    get {
      return _nachname;
    }
    set {
      if(value.Length > MaxNachnameLaenge) {
        throw new ArgumentException($"Nachname darf maximal {MaxNachnameLaenge} Zeichen lang sein.");
        //_nachname = value.Substring(0, MaxNachnameLaenge - 3) + "...";
      } else {
        _nachname = value;
      }
    }
  }
  public void SetNachname(string v) {
    _nachname = v;
  }

  public string Emailadresse;
  public string Telefonnummer;
  public string Adresse;

  public static Kontakt FindByEmail(List<Kontakt> adressbuch, string email) {
    foreach(Kontakt k in adressbuch) {
      if(k.Emailadresse == email) {
        return k;
      }
    }
    return null;
  }

  public Kontakt(string Vorname, string n, string m) {
    this.Vorname = Vorname;
    Nachname = n;
    Emailadresse = m;
  }
  
  public Kontakt(string v, string n, string m, string t, string a) {
    Vorname = v;
    Nachname = n;
    Emailadresse = m;
    Telefonnummer = t;
    Adresse = a;
  }

  public static string NormalisiereTelefonnummer(string t) {
    return t.Replace(" ", "").Replace("-", "");
  }



  public void Call() {
    Console.WriteLine($"Rufe {Vorname} {Nachname} unter {Telefonnummer} an...");
  }

  public override string ToString() {
    return $"{Vorname} {Nachname}, E-Mail: {Emailadresse}, Adresse: {Adresse}";
  }
  
}

