using System;

class Loop {
  
  static void Main() {
    Console.WriteLine("Wochenbeginn");
    /*
    int k = 0;
    while(k < 5) {
      Console.WriteLine("Wochentag " + k);
      Console.WriteLine("Wecker klingelt");
      Console.WriteLine("Aufstehen");
      Console.WriteLine("Toilette");
      Console.WriteLine("Duschen");
      Console.WriteLine("Frühstück");
      Console.WriteLine("Los");
      k++;
    }
    */

    for(int i = 0; i < 5; i++) {
      Console.WriteLine("Wochentag " + i);
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