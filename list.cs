using System;
using System.Collections.Generic;

class Temperaturen {
  static void Main(string[] args) {
    // Skalare Variable
    int z = 5;
    Console.WriteLine(z);

    // Array (Liste)
    int[] t = new int[] { 15, 22, 18, 30, 25, 20, 28, 19 };
    Console.WriteLine(t[2]);
    t[3] = 26;
    Console.WriteLine(t[3]);

    int[] t2 = { 15, 22, 18, 30, 25, 20, 28, 19, 24, 21 };
    for(int i = 0; i < t2.Length; i++) {
      Console.WriteLine($"Tag {(i + 1)}: {t2[i]}°C");
    }

    // List
    List<double> temperaturen = new List<double> { 21.5, 23.1, 19.8, 22.0, 24.3, 20.9, 21.8, 22.4, 21.0, 23.8 };
    temperaturen.Add(21.4);
    Console.WriteLine(temperaturen[4]);
    temperaturen[7] = 27.1;
    Console.WriteLine(temperaturen[7]);

    for(int i = 0; i < temperaturen.Count; i++) {
      Console.WriteLine($"Tag {(i + 1)}: {temperaturen[i]}°C");
    }

    foreach(double temp in temperaturen) {
      Console.WriteLine($"{temp}°C");
    }

    temperaturen.RemoveAt(2);
    Console.WriteLine("Nach dem Entfernen des 3. Elements:");
    foreach(double temp in temperaturen) {
      Console.WriteLine($"{temp}°C");
    }

    List<double> preise = new List<double> { 0.99, 1.49, 2.49 };

    double avg;
    avg = Mittelwert(preise);
    avg = Mittelwert(new List<double> { 5.0, 10.0, 15.0 });
    avg = Mittelwert(temperaturen);
    Console.WriteLine($"Aufg. 2 → Mittelwert der Temperaturen: {avg:F1} °C");
    Console.WriteLine($"Aufg. 2 → Minimum der Temperaturen: {Minumum(temperaturen):F1} °C");
    Console.WriteLine($"Aufg. 2 → Maximum der Temperaturen: {Maximum(temperaturen):F1} °C");

    Console.WriteLine("Vor dem Median");
    foreach(double temp in temperaturen) {
      Console.WriteLine($"{temp}°C");
    }

    Console.WriteLine($"Aufg. 2 → Median der Temperaturen: {Median(temperaturen):F1} °C");

    Console.WriteLine("Nach dem Median");
    foreach(double temp in temperaturen) {
      Console.WriteLine($"{temp}°C");
    }
  }

  static double Mittelwert(List<double> werte) {
    if(werte == null || werte.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

    double summe = 0;
    foreach(double w in werte) {
      summe += w;
    }
    return summe / werte.Count;
  }

  static double Minumum(List<double> werte) {
    if(werte == null || werte.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

    double min = werte[0];
    foreach(double w in werte) {
      if(w < min) {
        min = w;
      }
    }
    return min;
  }

  static double Maximum(List<double> werte) {
    if(werte == null || werte.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

    double max = werte[0];
    foreach(double w in werte) {
      if(w > max) {
        max = w;
      }
    }
    return max;
  }

  static double Median(List<double> daten) {
    if(daten == null || daten.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

    List<double> kopie = new List<double>(daten); // Kopie der Liste erzeugen, um das Original nicht zu verändern
    List<double> kopie = daten; // Keine Kopie, sondern nur ein Alias für daten. Das Original wird verändert

    kopie.Sort();

    int n = kopie.Count;
    if(n % 2 != 0) {
      // ungerade Anzahl: mittlerer Wert
      return kopie[n / 2];
    } else {
      // gerade Anzahl: Durchschnitt der beiden mittleren
      double m1 = kopie[n / 2 - 1];
      double m2 = kopie[n / 2];
      return (m1 + m2) / 2.0;      
    }
  }
  
}