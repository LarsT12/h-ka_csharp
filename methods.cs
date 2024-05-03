using System;

class Methods {
  public static void Main(string[] args) {
    int a = Convert.ToInt32(args[0]);
    int f = Convert.ToInt32(args[1]);
    begrüßung();
    berechnung(a, f);
    verabschiedung();
  }

  public static void berechnung(int sum, int factor) {
    sum += calc(3, 8);
    sum += calc(4, 2);
    sum *= factor;
    wp("Ergebnis: " + sum);
  }

  public static int calc(int a, int b) {
    int c = a * b;
    return c;
  }

  public static void begrüßung() {
    wp("Hallo");
    wp("Guten Morgen");
  }

  public static void verabschiedung() {
    wp("Schönen Tag");
    wp("Ciao");
  }

  public static void wp(string text) {
    Console.Write("\n");
    Console.Write(text.ToUpper());
    Console.Write("\n");
  }

}