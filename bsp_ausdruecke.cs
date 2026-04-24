using System;

class BeispieleAusdruecke {
  static void Main(string[] args) {

    int a; // Deklaration einer Variablen
    int b = 5; // Deklaration und Initialisierung einer Variablen
    int c;
    string s;

    a = 9;
    if(a > b) {
      c = a - b;
    } else {
      c = a * b;
    }

    s = "" + 'a' + c; // Konkatination (Verbinden) von String und Integer, c wird automatisch in einen String umgewandelt
    c = 'A'; // Implizite Umwandlung von char zu int, 'A' hat den ASCII-Wert 65
    
    string ausgabe = $"result is: {c}";
    Console.WriteLine(ausgabe);
    Console.WriteLine("----");

    double r = (double)(a) / (double)(b);
    Console.WriteLine(r);
    Console.WriteLine("----");

    string text = "Hallo";

    foreach(char ch in text) {
      int ch_code = ch + 1;
      Console.WriteLine((char)ch_code);
    }
    Console.WriteLine("----");
    foreach(char ch in text) {
      char ch_new = (char)(ch - 1);
      Console.WriteLine(ch_new);
    }
    Console.WriteLine("----");

    bool x = true;
    bool y = false;
    bool z;

    z = x && !y; // logisches UND
    Console.WriteLine(z);
    Console.WriteLine("----");
  }
}