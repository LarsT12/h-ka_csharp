using System;

class Block {
  static int j = 5;

  static void Main(string[] args) {
    Console.WriteLine("Blöcke und Variablen");

    //int j = 3;

    {
      int k = 2 * j;
      Console.WriteLine(k);
    }

  }
}