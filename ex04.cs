using System;
using System.Collections.Generic;

class Temperaturen {
  static void Main(string[] args) {
    Console.WriteLine("Temperaturen");

    List<double> temperaturen = new List<double> { 21.5, 23.1, 19.8, 22.0, 24.3, 20.9, 21.8, 22.4, 21.0, 23.8 };
    List<double> temp = new List<double>();

    double avg = Mittelwert(temperaturen);
    Console.WriteLine($"Aufg. 2 → Mittelwert der Temperaturen: {avg:F1} °C");
    Console.WriteLine($"Aufg. 2 → Minimum der Temperaturen: {Minumum(temperaturen):F1} °C");
    Console.WriteLine($"Aufg. 2 → Maximum der Temperaturen: {Maximum(temperaturen):F1} °C");
    
    Console.WriteLine($"Aufg. 3 → Der Median liegt bei: {Median(temperaturen):F1} °C");

    double min = 20.5;
    double max = 21.5;
    Console.WriteLine($"Aufg. 4 → Anzahl Werte im Bereich von [{min:F1}, {max:F1}]: {AnzahlImBereich(temperaturen, min, max)}");

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

    List<double> kopie = new List<double>(daten);
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

  static int AnzahlImBereich(List<double> daten, double minWert, double maxWert) {
    if(daten == null || daten.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

    int count = 0;
    foreach (double d in daten) {
      if(d >= minWert && d <= maxWert) {
        count++;
      }
    }
    return count;
  }

}