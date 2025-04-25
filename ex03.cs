using System;

class Wochenablauf {

  static void Main(string[] args) {
    string[] wochentag = new string[] { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };

    Console.WriteLine("Wochenablauf\n");

    for(int i = 0; i < wochentag.Length; ++i) {
      Console.WriteLine("### " + wochentag[i] + " ###");

      if(i < 5) { // boolscher Ausdruck, der Abhängigkeit einer veränderbaren Variable steht
        Console.WriteLine("Wecker klingelt");
        Console.WriteLine("Aufstehen");
      } else { // ansonsten ...
        Console.WriteLine("Sonne geht auf");
        Console.WriteLine("Erst mal liegen bleiben");
      }
      
      Console.WriteLine("Toilette");
      Console.WriteLine("Duschen");
      Console.WriteLine("Erwartete Temp.: " + args[i] + "°C");
      Console.WriteLine("Frühstück");
      Console.WriteLine("Los");
      Console.WriteLine("");
    }

    Console.WriteLine("Wochenende");   

  }
}