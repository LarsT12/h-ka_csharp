using System;

class Loop {
  
  static void Main() {
    Console.WriteLine("Wochenbeginn");
    
    int weekday = 1; 
    while(weekday <= 7;) {
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

      ++weekday;
    }

    Console.WriteLine("Wochenende");
  }
  
}