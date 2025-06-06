using System;
using System.Collections.Generic;

class Messdaten {
  static void Main(string[] args)
  {
    Console.WriteLine($"Messdaten für den Standort {Messung.Ort}");

    //Messung m0 = new Messung();
    //m0.Zeitpunkt = new DateTime(2025, 5, 2, 9, 30, 0);
    //m0.Wert = 22.678;
    //Console.WriteLine($"Aufg. 1 → Messung vom {m0.Zeitpunkt}: {m0.Wert:F1}°C");

    //Messung m1 = new Messung() { Zeitpunkt = new DateTime(2025, 5, 3, 8, 30, 0), Wert = 23.445678 };
    //Console.WriteLine($"Aufg. 1 → Messung vom {m1.Zeitpunkt}: {m1.Wert:F1}°C");

    //Messung m2 = new Messung(new DateTime(2025, 5, 4, 8, 45, 0), 21.87);
    //Console.WriteLine($"Aufg. 2 → Messung vom {m2.Zeitpunkt}: {m2.Wert:F1}°C");

    List<Messung> messungen = new List<Messung>() {
      new Messung(new DateTime(2025,  5,  1,  8,  0,  0), 21.5),
      new Messung(new DateTime(2025,  5,  2, 12,  0,  0), 23.0),
      new Messung(new DateTime(2025,  5,  4, 16,  0,  0), 19.7),
      new Messung(new DateTime(2025,  5,  7, 20,  0,  0), 22.2),
      new Messung(new DateTime(2025,  5,  9,  4,  0,  0), 23.8),
      new Messung(new DateTime(2025,  5, 14, 13,  0,  0), 19.2),
      new Messung(new DateTime(2025,  5, 12,  9,  0,  0), 17.5),
      new Messung(new DateTime(2025,  5, 12, 19,  0,  0), 19.6),
      new Messung(new DateTime(2025,  5, 12, 15,  0,  0), 25.8)
    };
    foreach (Messung m in messungen)
    {
      //Console.WriteLine($"Aufg. 3 → Messung vom {m.Zeitpunkt}: {m.Wert:F1}°C");
      Console.WriteLine($"Aufg. 4 → {m}");
    }

    Messung m3 = new Messung(new DateTime(2025, 5, 4, 8, 45, 0), 21.87);
    m3.setWert(m3.getWert() + 1);
    m3.Zeitpunkt = new DateTime(2025, 5, 5, 8, 45, 0);
    Console.WriteLine($"\nAufg. 5 → {m3}");

    // Messung.AnzahlMessungen = 8;
    Console.WriteLine($"\nInsgesamt wurden an meinem Standort {Messung.Ort} {Messung.Anzahl} Messungen erfasst.");
    Console.WriteLine($"Der Mittelwert am Standort {Messung.Ort} liegt bei {Messung.Mittelwert():F1}°C.");

    /*
    Console.WriteLine($"Aufg. 5 → Mittelwert der Temperaturen: {Mittelwert(messungen):F1} °C");
    Console.WriteLine($"Aufg. 5 → Minimum der Temperaturen: {Minimum(messungen):F1} °C");
    Console.WriteLine($"Aufg. 5 → Maximum der Temperaturen: {Maximum(messungen):F1} °C");
    Console.WriteLine($"Aufg. 5 → Der Median liegt bei: {Median(messungen):F1} °C");

    DateTime von = new DateTime(2025,  5,  4,  0,  0,  0);
    DateTime bis = new DateTime(2025,  5, 12, 23, 59, 59);
    Console.WriteLine($"Aufg. 6 → Messungen vom {von:dd.MM.yyyy} bis {bis:dd.MM.yyyy}: {AnzahlImZeitraum(messungen, von, bis)}");
    */
  }

  /*
    

    static double Minimum(List<Messung> daten) {
      if(daten == null || daten.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

      double min = daten[0].Wert;
      foreach(Messung m in daten) {
        if(m.Wert < min) {
          min = m.Wert;
        }
      }
      return min;
    }

    static double Maximum(List<Messung> daten) {
      if(daten == null || daten.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

      double max = daten[0].Wert;
      foreach(Messung m in daten) {
        if(m.Wert > max) {
          max = m.Wert;
        }
      }
      return max;
    }

    static double Median(List<Messung> daten) {
      if(daten == null || daten.Count == 0) throw new ArgumentException("Liste darf nicht leer sein.");

      // Werte extrahieren
      List<double> werte = new List<double>();
      foreach(Messung m in daten) {
        werte.Add(m.Wert);
      }
      werte.Sort();

      int n = werte.Count;
      if(n % 2 == 0) {
        // gerade Anzahl: Durchschnitt der beiden mittleren
        double m1 = werte[n / 2 - 1];
        double m2 = werte[n / 2];
        return (m1 + m2) / 2.0;
      } else {
        // ungerade Anzahl: mittlerer Wert
        return werte[n / 2];
      }
    }

    static int AnzahlImZeitraum(List<Messung> daten, DateTime von, DateTime bis) {
      if(daten == null) throw new ArgumentNullException(nameof(daten));

      int count = 0;
      foreach(Messung m in daten) {
        if(m.Zeitpunkt >= von && m.Zeitpunkt <= bis) {
          count++;
        }
      }
      return count;
    }
  */
  class Messung {
    private const double DIFF = 273.15;

    public static string Ort = "Karlsruhe";

    public static int Anzahl { get; private set; }

    private static List<Messung> _AlleMessungen = new List<Messung>();

    public static double Mittelwert() {
      if(_AlleMessungen == null || _AlleMessungen.Count == 0) throw new ArgumentException("Bitte zuerst mind. eine Messung erfassen!");

      double summe = 0;
      foreach(Messung m in _AlleMessungen) {
        summe += m.getWert();
      }
      return summe / _AlleMessungen.Count;
    }

    private DateTime _Zeitpunkt;
    public DateTime Zeitpunkt {
      get {
        return _Zeitpunkt;
      }

      set {
        if(value > DateTime.Now) {
          throw new Exception($"{value} liegt in der Zukunft. Es sind nur Werte bis spätestens heute erlaubt!");
        }
        _Zeitpunkt = value;
      }
    }
    private double _Wert;
    public double getWert() {
      return _Wert - DIFF;
    }
    public void setWert(double v) {
      if (v <= -50.0 || v >= 50.0) {
        throw new Exception("Nur Werte im Intervall ±50°C erlaubt!");
      }
      _Wert = v + DIFF;
    }

    public Messung(DateTime zeitpunkt, double wert) {
      Zeitpunkt = zeitpunkt;
      setWert(wert);

      Anzahl++;
      _AlleMessungen.Add(this);
    }

    public override string ToString() =>
      $"Messung am Standort {Ort} vom {Zeitpunkt}: {getWert():F1}°C";

  }

}