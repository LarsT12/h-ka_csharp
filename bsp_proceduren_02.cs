using System;

class BeispieleZinseszin {
  static void Main(string[] args) {
    Zinseszin(1000.0, 0.05, 10);
    Zinseszin(1500.0, 0.06, 12);
    Zinseszin(2000.0, 0.07, 15);

    int x = 5;
    procMitVeraenderung(ref x);
    Console.WriteLine(x);
  }

  static void procMitVeraenderung(ref int s) {
    Console.WriteLine(s);
    s++;
  }

  static void Zinseszin(double kapital, double zinssatz, int jahre) {
    for(int i = 0; i < jahre; ++i) {
      kapital *= (1 + zinssatz); // Kapital wächst um den Zinssatz
    }
    Console.WriteLine($"Mein Kapital nach {jahre} Jahren: {kapital}");
  }
}

