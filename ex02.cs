using System;

class Block {
  static int j = 5;

  static void Main() {
    Console.WriteLine("Block");
    int j = 3;
  
    {
      int k = j * 2;
      j *= 3;
      Console.WriteLine(k);
    }
    Console.WriteLine(j);
    
  }

}