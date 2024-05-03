using System;
using System.Collections.Generic;

class FieldsBeginners {
  public static void Main() {
    Console.WriteLine("FieldsBeginners...");
    //arraySample();
    listSample();
  }

  private static void arraySample() {
    int[] r = new int[] { 33, 20, 30, 45 };

    Console.WriteLine("Werte:");
    for(int i = 0; i < r.Length; i++) {
      Console.WriteLine(r[i]);
    }

    Console.WriteLine("\nSumme:");
    int s = 0;
    foreach(int k in r) {
      s += k; 
    }
    Console.WriteLine(s);

    s = 0;
    for(int i = 0; i < r.Length; i++) {
      int k = r[i];
      s += k;
    }
    Console.WriteLine(s);
  }

  private static void listSample() {
    List<int> r = new List<int>();
    r.Add(33);
    r.Add(23);
    //r.Remove(33);

    Console.WriteLine(r[0]);

    Console.WriteLine("Werte:");
    int s = 0;
    foreach(int k in r) {
      Console.WriteLine(k);
      s += k;
    }
    Console.WriteLine("\nSumme:");
    Console.WriteLine(s);

    s = 0;
    for(int i = 0; i < r.Count; i++) {
      int k = r[i];
      s += k;
    }
    Console.WriteLine("\nSumme:");
    Console.WriteLine(s);
  }
}