using System;

class BeispieleZinseszin {
  static void Main(string[] args) {
    int indent = 4;
    printWertHeader();
    printWert(indent, 25);
    printWert(indent, 32);
    printWert(indent, 40);
  
    int x = 5;
    printErgebnis(x);
  }

  static void printWertHeader() {
    Console.WriteLine("---------");
    Console.WriteLine("Werte:");
  }

  static void printWert(int indent, int wert) {
    Console.Write(new string(' ', indent));
    //for(int i = 0; i < indent; ++i) {
    //  Console.Write(" ");
    //}
    Console.WriteLine(wert);
  }

  static void printErgebnis(int ergebnis) {
    Console.WriteLine("---------");
    Console.WriteLine("Ergebnis:");
    Console.WriteLine($"--> {ergebnis}");
  }

}

