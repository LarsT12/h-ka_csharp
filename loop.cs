using System;

class Loop {
  
  static void Main() {
    Console.WriteLine("Wochenbeginn");
    for(int i = 0; i < 5; i++) {
      Console.WriteLine("Wecker klingelt");
      Console.WriteLine("Aufstehen");
      Console.WriteLine("Toilette");
      Console.WriteLine("Duschen");
      Console.WriteLine("Frühstück");
      Console.WriteLine("Los");
    }
    Console.WriteLine("Wochenende");
    for(int i = 0; i < 2; i++) {
      Console.WriteLine("Ausschlafen");
      Console.WriteLine("Joggen");
      Console.WriteLine("Duschen");
    }
  }
  
}