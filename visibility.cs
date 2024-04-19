using System;
class Visibility {
  static int j = 9;

  static void Main() {
    Console.WriteLine("Hi Visibility!");

    int b = 1;
    Console.WriteLine("Wert von b = " + b);
    
    for(int i = 0; i < 4; i++) {
      // int j = 3;
      j = j + 1;
      j += 1 + 5;
      j++;
      ++j;
      Console.WriteLine("j = " + j);

      b = ++j + 5;
      Console.WriteLine("b = " + b);
    }

    Console.WriteLine(j);
    gedöns();
  }

  static void gedöns() {
    Console.WriteLine("noch mal j: " + j);
  }

}