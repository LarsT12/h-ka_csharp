using System;
using System.Collections.Generic;

class Fields02 {
  public static void Main() {
    // string[] ar = new string[5];
    // List<string> li = new List<string>();
    string[] ar = new string[] { "Hi", "Moin", "Tach", "Ciao", "Hello" };
    List<string> li = new List<string>() { "Hi", "Moin", "Tach", "Ciao", "Hello" };

    /*
    ar[0] = "Hallo";
    li.Add("Hallo");
    Console.WriteLine(ar[0]);
    Console.WriteLine(li[0]);

    ar[1] = "Tach";
    li.Add("Tach");

    // Ändere den String im 0. Element von "Hallo" auf "Hi"!

    ar[0] = "Hi";
    li[0] = "Hi";
    Console.WriteLine(ar[0]);
    Console.WriteLine(li[0]);
    */

    // Separate Ausgabe aller Werte von ar und li

    Console.WriteLine("for Schleife für ar");
    for(int i = 0; i < ar.Length; i++) {
      Console.WriteLine(i + ". Element: " + ar[i]);
    }
    Console.WriteLine();

    Console.WriteLine("for Schleife für li");
    for(int i = 0; i < li.Count; i++) {
      Console.WriteLine(i + ". Element: " + li[i]);
    }
    Console.WriteLine();

    // foreach auseinander genommen:
    /*
    string item;
    item = ar[0];
    item = ar[1];
    item = ar[2];
    item = ar[3];
    item = ar[4];
    */

    Console.WriteLine("foreach Schleife für ar");
    foreach(string elem in ar) {
      Console.WriteLine(elem);
    }
    Console.WriteLine();
    
    Console.WriteLine("foreach Schleife für li");
    foreach(string elem in li) {
      Console.WriteLine(elem);
    }
    Console.WriteLine();

  }

}