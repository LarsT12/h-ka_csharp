using System;

class Selection {
  
  static void Main(string[] args) {
    int weekday = 3;
  
    Console.WriteLine("Schlafen");
    
    // Wenn der Wochentag kleiner als 6 ist, dann... { ... }
    if(weekday < 6) { // boolscher Ausdruck, der Abhängigkeit einer veränderbaren Variable steht
      Console.WriteLine("Wecker klingelt");
      Console.WriteLine("Aufstehen");
    } else { // ansonsten ...
      Console.WriteLine("Sonne geht auf");
      Console.WriteLine("Erst mal liegen bleiben");
    }
    
    Console.WriteLine("Toilette");
    Console.WriteLine("Duschen");
    Console.WriteLine("Frühstück");
    Console.WriteLine("Los");
  }
}