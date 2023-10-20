using System;

class Block {
  static int j = 7;
  
  static void Main() {
    Console.WriteLine("Moin");
    
    int j = 3;
    if(j < 5) {
      int k = 5;
      //int j = 4;
      Console.WriteLine(j * k);
    }
    Console.WriteLine("Main: " + j);
    // Console.WriteLine(k); // The name `k' does not exist in the current context
    
    for(int i = 0; i < 3; i++) {
      Console.WriteLine(i);
    }
    
    // Console.WriteLine(i); // The name `i' does not exist in the current context
    
    test();
  }
  
  static void test() {
    Console.WriteLine("test: " + j);
  }
}