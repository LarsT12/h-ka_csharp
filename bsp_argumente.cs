using System;

class BeispielArgumente {
  static void Main(string[] args) {

    int number = 42;
    int factor;

    /*
    // Wenn kein Argument übergeben wird, verwenden wir einen Standardwert von 1.
    if(args.Length == 0) {
      Console.WriteLine("No factor provided, using default value of 1.");
      args = new string[] { "1" }; // Default factor
    }
    */
    
    // Wenn kein Argument übergeben wird, werfen wir eine Ausnahme, um den Benutzer darauf hinzuweisen, dass ein Faktor erforderlich ist.
    if(args.Length == 0) {
      throw new ArgumentException("No factor provided, please provide a factor as a command line argument.");
    }

    factor = int.Parse(args[0]);
    number *= factor;
    Console.WriteLine(number);

  }
}