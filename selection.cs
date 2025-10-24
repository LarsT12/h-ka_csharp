using System;

class Selection {
  
  static void Main(string[] args) {
    int weekday = 7;
  
    Console.WriteLine("Schlafen");
    
    // Wenn der Wochentag kleiner als 6 ist, dann... { ... }
    if(weekday < 6) { // boolscher Ausdruck, der Abhängigkeit einer veränderbaren Variable steht
      Console.WriteLine("Wecker klingelt");
      Console.WriteLine("Aufstehen");
    } else if(weekday == 6) {
      Console.WriteLine("Sonne geht auf");
      Console.WriteLine("Erst mal liegen bleiben"); 
    } else {
      Console.WriteLine("Heut ist Sonntag");
      Console.WriteLine("Genieße den Tag");
    }
    
    Console.WriteLine("Toilette");
    Console.WriteLine("Duschen");
    Console.WriteLine("Frühstück");
    Console.WriteLine("Los");
  }
}