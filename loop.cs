using System;

class Loop {
  
  static void Main() {
    Console.WriteLine("Wochenbeginn");
    
    for(int weekday = 1; weekday <= 7; ++weekday) {
      Console.WriteLine(weekday);

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

    Console.WriteLine("Wochenende");
  }
  
}