using System;

class Selection {
  
  static void Main() {
    for(int i = 0; i < 7; i++) {
      Console.WriteLine();
      if(i < 5) {
        Console.WriteLine("Wecker klingelt");
        Console.WriteLine("Aufstehen");
      } else {
        Console.WriteLine("Sonne geht auf");
        Console.WriteLine("Erst mal liegen bleibeh");
      }
      Console.WriteLine("Toilette");
      Console.WriteLine("Duschen");
      Console.WriteLine("Frühstück");
      Console.WriteLine("Los");
    }
  }
}