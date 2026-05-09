using System;

class BeispieleProzeduren {
  static void Main(string[] args) {
    Console.WriteLine("Prozeduren in C#");
    Console.WriteLine("----");

    MorgenRoutine(DayOfWeek.Monday, true);
    Console.WriteLine("----");
    MorgenRoutine(DayOfWeek.Saturday, false);
  }

  static void MorgenRoutine(DayOfWeek tag, bool fruehstuecken) {
    Console.WriteLine($"Heute ist {tag}.");

    if(IstWochenende(tag)) {
      Aufstehen("09:00");
      FertigMachen(fruehstuecken);
      Console.WriteLine("Heute bleibe ich zu Hause.");
      Console.WriteLine("Der Vormittag ist frei planbar.");
    } else {
      Aufstehen("06:30");
      FertigMachen(fruehstuecken);
      ZurHochschuleGehen();
    }
  }

  static bool IstWochenende(DayOfWeek tag) {
    return tag == DayOfWeek.Saturday || tag == DayOfWeek.Sunday;
  }

  static void Aufstehen(string uhrzeit) {
    Console.WriteLine($"Der Wecker klingelt um {uhrzeit}.");
    Console.WriteLine("Ich stehe auf.");
  }

  static void FertigMachen(bool fruehstuecken) {
    Console.WriteLine("Fertig machen:");
    Console.WriteLine("- duschen");
    Console.WriteLine("- anziehen");
    Console.WriteLine("- Zähne putzen");

    if(fruehstuecken) {
      Console.WriteLine("- frühstücken");
    } else {
      Console.WriteLine("- Frühstück auslassen");
    }
  }

  static void ZurHochschuleGehen() {
    Console.WriteLine("Aufbruch zur Hochschule:");
    Console.WriteLine("- das Haus verlassen");
    Console.WriteLine("- zur Hochschule gehen");
  }
}
