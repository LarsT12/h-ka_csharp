using System;
using System.Collections.Generic;

class Messdaten {
  static void Main(string[] args) {
    Console.WriteLine("Messdaten");

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
    foreach(Messung m in messungen) {
      Console.WriteLine($"Aufg. 3 → Messung vom {m.Zeitpunkt}: {m.Wert:F1}°C");
    }

  }

  
  class Messung {
    public DateTime Zeitpunkt;
    public double Wert;

    public Messung(DateTime zeitpunkt, double wert) {
      Zeitpunkt = zeitpunkt;
      Wert = wert;
    }

  }
}