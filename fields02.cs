using System;
using System.Collections.Gerneric;

class Fields02 {
  public static void Main() {
    string[] ar = new string[] { "Hallo", "Moin", "Tach", "Ciao", "Hello" };
    List<string> li = new List<string>() { "Hallo", "Moin", "Tach", "Ciao", "Hello" };

    foreach (string elem in li) {
      Console.WriteLine(elem);      
    }
  }

}