using System;

class Kontrollstrukturen {
  static void Main(string[] args) {

    Console.WriteLine("Kontrollstrukturen in C#");

    // Sequence
    Console.WriteLine("Sequence");
    Console.WriteLine("Schritt 1");
    Console.WriteLine("Schritt 2");
    Console.WriteLine("Schritt 3");
    Console.WriteLine("----");

    // Selection
    Console.WriteLine("Selection");
    int a = int.Parse(args[0]);
    if(a > 0) {
      Console.WriteLine("Schritt 1p");
      Console.WriteLine("Schritt 2p: a ist positiv");
      Console.WriteLine("Schritt 3p");
    } else if(a < 0) {
      Console.WriteLine("Schritt 1n");
      Console.WriteLine("Schritt 2n: a ist negativ");
      Console.WriteLine("Schritt 3n");
    } else {
      Console.WriteLine("Schritt 1z");
      Console.WriteLine("Schritt 2z: a ist null");
      Console.WriteLine("Schritt 3z");
    }

    Console.WriteLine("----");

    if(a > 10) {
      Console.WriteLine("a ist zweistellig positiv");
    }

    Console.WriteLine("----");
    // case switch
    Console.WriteLine("case switch");
    switch(a) {
      case 0:
        Console.WriteLine("a ist null");
        break;
      case 1:
        Console.WriteLine("a ist eins");
        break;
      case 2:
        Console.WriteLine("a ist zwei");
        break;
      default:
        Console.WriteLine("a ist weder null, eins noch zwei");
        break;
    }

    // Loop
    //  init        abbruch  inkrement
    for(int g = 0;  g < 10;  ++g) {
      Console.WriteLine($"g: {g}");
      for(int i = 0; i < 3; ++i) {
        Console.WriteLine($" i: {i}");
      }
    }
    Console.WriteLine("----");

    int h = 0; // init
    while(h < 10) { // abbruch
      Console.WriteLine($"h: {h}");
      int j = 0; // init
      while(j < 3) {
        Console.WriteLine($"  j: {j}");
        j++;
      }
      h++; // inkrement
    }

    Console.WriteLine("----");
  }
}