using System;
using System.Collections.Generic;

class Strukturen {

  static void CW(string s) {
    Console.WriteLine(s);
  }
  static void Main(string[] args) {
    if(args.Length < 3) { }

    /*
    string vorname1 = "Larissa";
    string vorname2 = "Robert";
    string vorname3 = "Simone";
    string vorname4 = "Ben";
    int k = vorname1.Length;
    */

    List<string> vornamen = new List<string>();
    vornamen.Add("Larissa");
    vornamen.Add("Robert");
    vornamen.Add("Simone");
    vornamen.Add("Ben");

    // Für jedes Element von x in N gilt:
    // for each string vorname in vornamen:
    foreach(string vorname in vornamen) {
      // Console.WriteLine(vorname);
    }

    Person p = new Person("Lars");
    p.Groesse = 1.8;
    p.Lieblingszahl = 12;

    List<int> zahlen = new List<int>(){ 1, 3, 5, 7 };
    foreach(int zahl in zahlen) {
      // Console.WriteLine(zahl);
    }

    List<Person> personen = new List<Person>() {
      new Person("Larissa", 1.8, 12),
      new Person("Simone", 1.6, 4),
      new Person("Ben", 1.8, 7),
      new Person("Robert", 1.7, 13)
    };

    foreach(Person person in personen) {
      Console.WriteLine($"{person.Vorname}: {person.Lieblingszahl}");
    }
    /*
    for(int i = 0; i < personen.Count; ++i) {
      CW($"{personen[i].Vorname}: {personen[i].Lieblingszahl}");
    }
    */

  }

  class Person {
    public string Vorname;
    public int Lieblingszahl;
    public double Groesse;

    public Person(string Vorname) {
      this.Vorname = Vorname;
    }

    public Person(string Vorname, double Groesse, int Lieblingszahl) {
      this.Vorname = Vorname;
      this.Lieblingszahl = Lieblingszahl;
      this.Groesse = Groesse;
    }

  }

  struct Nochwas {
    public string Vorname;

    public Nochwas(string Vorname) {
      this.Vorname = Vorname;
    }
  }
}
