using System;

class MyList {
  static void Main() {
    myArray();
    myList();
  }
  
  static void myArray() {
    Console.WriteLine("myArray");
    const int SIZE = 10;
    int[] a = new int[SIZE];
    
    for(int i = 0; i < a.Length; i++) {
      a[i] = i;
    }

    for(int i = 0; i < a.Length) {
      Console.WriteLine(a[i]);
    }
    
    foreach(int b in a) {
      Console.WriteLine(b);
    }        
  }
  
  static void myList() {
    Console.WriteLine("myList");
  }

}