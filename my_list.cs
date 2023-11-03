using System;
using System.Collections.Generic;

class MyList {
  static void Main() {
    // myArray();
    myList();
  }
  
  static void myArray() {
    Console.WriteLine("myArray");
    const int SIZE = 10;
    int[] a = new int[SIZE];
    
    for(int i = 0; i < a.Length; i++) {
      a[i] = i;
    }

    for(int i = 0; i < a.Length; i++) {
      int b = a[i];
      Console.WriteLine(b);
    }
    
    foreach(int b in a) {
      Console.WriteLine(b);
    }        
  }
  
  static void myList() {
    Console.WriteLine("myList");
    Random z = new Random();
    List<int> tickets = new List<int>() {32, 53, 23};
    
    tickets.Add(z.Next(0, 100));
    tickets.Add(z.Next(0, 100));
    tickets.Add(z.Next(0, 100));
    
    // für jedes t in tickets mache folgendes:
    foreach(int t in tickets) {
      Console.WriteLine(t);
    }
    
    Console.WriteLine(tickets[2]);
  }

}