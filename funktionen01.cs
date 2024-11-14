using System;

class Funktionen01 {
  static void Main() {
    /* Version 1: Ohne Funktionen
    Console.WriteLine("15.11.2024");
    Console.WriteLine("Karlsruhe");
    Console.WriteLine("Hallo");
    Console.WriteLine("15.11.2024");
    Console.WriteLine("Karlsruhe");
    Console.WriteLine("Hi");
    Console.WriteLine("Programmstart");
    Console.WriteLine("...");
    */

    /* Version 2: Mit Funktionen
    header();
    Console.WriteLine("Hallo");
    header();
    Console.WriteLine("Hi");
    Console.WriteLine("Programmstart");
    Console.WriteLine("...");
    */

    /* Version 3: Mit Funktionen und Parameter
    header("Hallo");
    header("Hi");
    Console.WriteLine("Programmstart");
    Console.WriteLine("...");
    */

    int x = 7;
    int y = 3;
    int z = f(x, y);
    Console.WriteLine(z);
  }

  static void header() {
    Console.WriteLine("15.11.2024");
    Console.WriteLine("Karlsruhe");
  }

  static void header(string begruessung) {
    string datum = "15.11.2024";
    Console.WriteLine(datum);
    Console.WriteLine("Karlsruhe");
    Console.WriteLine(begruessung);
  }

  static int f(int a, int b) {
    int c = a * b;
    
    return c;
  }


}