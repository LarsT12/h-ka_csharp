using System;
using System.Collections.Generic;

class Klausur2018WiSe {
  public static void Main() {
    Console.WriteLine("Klausur 2018 WiSe");
    // aufg1a(7, 12);
    // aufg1a(8, 3);
    // aufg1b(25);
    // aufg1c("Hallo");
    // aufg1d();
    aufg1e();

  }

  public static void aufg1a(int i1, int i2) {
    Console.WriteLine("Aufgabe 1a");

    if(i1 - i2 <= 2) {
      Console.WriteLine(i1 / 2.0);
    } else {
      i2 *= 2;
      // Console.WriteLine(i2);
    }
  }

  public static void aufg1b(double d1) {
    while(d1 > 5) {
      d1 -= 3;
      if(Math.Pow(d1, 2) < 10) {
        Console.WriteLine(d1 * 3);
      }
    } 
  }

  public static void aufg1c(string text) {
    int anz = 0;
    foreach(char c in text) {
      Console.Write((int)c + " ");
      if((int)c % 2 == 0) {
        anz += 3;
      }
    }
    Console.WriteLine();
    Console.WriteLine(anz);
  }

  public static void aufg1d() {
    List<int> iifeld = new List<int>() {54, 65, 66, 97};

    foreach(int i in iifeld) {
      if(i >= 65 && i <= 91) {
        Console.WriteLine((char)i);
      }
    }
  }

  public static void aufg1e() {
    List<bool> bfeld = new List<bool>() {true, true, true, true, true, true, true, true, true, true, true};

    for(int i = 0; i < bfeld.Count; i += 5) {
      bfeld[i] = i % 2 == 0;
    }

    foreach(bool b in bfeld) {
      Console.WriteLine(b);
    }
  }
}