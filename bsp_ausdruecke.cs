using System;

class BeispieleAusdruecke {
  static void Main(string[] args) {

    int a; // Deklaration einer Variablen
    int b = 5; // Deklaration und Initialisierung einer Variablen
    int c, d, f; // Mehrere Variablen deklarieren
    string s;

    d = int.Parse(args[0]);
    a = 9;
    if(a > b) {
      c = a - b;
    } else {
      c = a * b;
    }

    s = "" + 'a' + c; // Konkatination (Verbinden) von String und Integer, c wird automatisch in einen String umgewandelt
    c = 'A'; // Implizite Umwandlung von char zu int, 'A' hat den ASCII-Wert 65

    c *= d; // äquivalent zu c = c * d;
    c -= d; // äquivalent zu c = c - d;

    string ausgabe = $"result is: {c}";
    Console.WriteLine(ausgabe);

    c++; // äquivalent zu c = c + 1;
    Console.WriteLine($"c after c++: {c}");
    ++c; // äquivalent zu c = c + 1;
    Console.WriteLine($"c after ++c: {c}");

    f = c++;
    Console.WriteLine($"f after f = c++: {f}, c is now: {c}");
    f = ++c;
    Console.WriteLine($"f after f = ++c: {f}, c is now: {c}");

    //  init        abbruch  inkrement
    for(int g = 0;  g < 10;  ++g) {
      Console.WriteLine($"g: {g}");
      // Platzhalter-Code
      // Platzhalter-Code
      // Platzhalter-Code
    }
    Console.WriteLine("----");

    int h = 0; // init
    while(h < 10) { // abbruch
      Console.WriteLine($"h: {h}");
      // Platzhalter-Code
      // Platzhalter-Code
      // Platzhalter-Code

      h++; // inkrement
    }

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


    // ternärer Operator: Bedingung ? Ausdruck1 : Ausdruck2
    int max = a > b ? a : b;
    Console.WriteLine($"a, b, max: {a}, {b} -> {max}");
    if(a > b) {
      max = a;
    } else {
      max = b;
    }
    Console.WriteLine($"a, b, max: {a}, {b} -> {max}");
  }
}