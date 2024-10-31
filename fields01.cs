using System;

class Loop {
  
  static void Main() {
    string[] wochentag = new string[] { "Mo", "Di", "Mi", "Do", "Fr" };
    string[] wochenendtag = new string[] { "Sa", "So" };

    Console.WriteLine("Wochenbeginn");

    for(int i = 0; i < 5; i++) {
      Console.WriteLine();
      Console.WriteLine("--- " + wochentag[i] + " ---");
      Console.WriteLine("Wecker klingelt");
      Console.WriteLine("Aufstehen");
      Console.WriteLine("Toilette");
      Console.WriteLine("Duschen");
      Console.WriteLine("Frühstück");
      Console.WriteLine("Los");
    }
    
    Console.WriteLine("\nWochenende");
    for(int i = 0; i < 2; i++) {
      Console.WriteLine();
      Console.WriteLine("--- " + wochenendtag[i] + " ---");
      Console.WriteLine("Ausschlafen");
      Console.WriteLine("Joggen");
      Console.WriteLine("Duschen");
    }
  }
  
}