using System;
using System.Collections.Generic;
using System.IO;

class Probeklausur_2025WiSe {
  // ProgI2025WSPK.pdf

  public static void Main() {
    Console.WriteLine("Hallo Probeklausur 2025 WiSe!");
    /*
    aufg1a();
    aufg1b();
    aufg1c();
    aufg1d();
    aufg1e();
    */

    // Aufgabe 2: Beispiel-Daten
    List<Gemüse> gemuese = new List<Gemüse> {
      new Gemüse("Karotte", 41, 120.5),
      new Gemüse("Tomate", 18, 80.0),
      new Gemüse("Tomate", 20, 95.0),
      new Gemüse("Gurke", 16, 300.0),
      new Gemüse("Tomate", 22, 110.0)
    };

    foreach(Gemüse g in gemuese) {
      Console.WriteLine(g);
    }

    // Aufgabe 2b: Durchschnitt Kalorien für Gewicht > grenze
    double ds = Gemüse.DSKal(gemuese, 90);
    Console.WriteLine($"DSKal: {ds}");

    // Aufgabe 2c: MaxGewicht für Namen
    double maxTomate = Gemüse.MaxGewicht(gemuese, "Tomate");
    Console.WriteLine($"MaxGewicht Tomate: {maxTomate}");

    // Aufgabe 2d: AlleKalorien bei Gewicht <= maxgewicht
    List<int> kalorienListe = Gemüse.AlleKalorien(gemuese, 100.0);
    Console.WriteLine($"AlleKalorien bis 100g: {string.Join(", ", kalorienListe)}");

    // Aufgabe 2e: Alle Elemente mit maximalem Gewicht und passendem Namen
    List<Gemüse> schwersteTomaten = Gemüse.AlleMaxGewichtMit(gemuese, "Tomate");
    Console.WriteLine("AlleMaxGewichtMit Tomate:");
    foreach(Gemüse g in schwersteTomaten) {
      Console.WriteLine($"  {g}");
    }

  }

  /* Aufgabe 1a:
    Die Variable zl enthält eine ganze Zahl. Übersetzen Sie: 
    Wenn zl ungleich 2 und ungleich 3 ist, wird zl verdoppelt. 
    Andernfalls wird die Hälfte von zl ausgegeben.
  */
  static void aufg1a() {
    Console.WriteLine("Aufgabe 1a");
    int zl = 3;
    
    // Lösungsmöglichkeit 1
    /*
    if(zl != 2 && zl != 3) {
      zl *= 2;
    } else {
      zl /= 2;
    }
    */
    // Lösungsmöglichkeit 2
    // ergebnis = (wennbedingung) ? wertWennWahr : wertWennFalsch;
    zl = (zl != 2 && zl != 3) ? zl * 2 : zl / 2;
    
    Console.WriteLine(zl);    
  }

  /* Aufgabe 1b:
    Die Variable ch enthält ein Zeichen, st einen String mit mehr als einem Zeichen. Übersetzen Sie:
    Wenn das vorletzte Zeichen von st ein Kleinbuchstabe ist, wird ch um 1 größer gemacht. 
    Andernfalls wird ein Fragezeichen an den String angehängt.
  */
  static void aufg1b() {
    Console.WriteLine("Aufgabe 1b");
    char ch = 'b';
    string st = "HalLo";

    char vl = st[st.Length - 2]; // vorletztes Zeichen
    if (vl >= 'a' && vl <= 'z') {
      ch++;
      // ch = (char)(ch + 1);
    } else {
      st += "?";
    }

    Console.WriteLine(ch);
    Console.WriteLine(st);
  }

  /* Aufgabe 1c:
    Die Variable zahlen bezeichnet ein Feld von Gleitpunktzahlen. Übersetzen Sie: 
    Beginnend mit dem dritten Element wird jedes dritte Element des Feldes verdreifacht falls es größer gleich 0 ist.
  */
  static void aufg1c() {
    Console.WriteLine("Aufgabe 1c");
    double[] zahlen = { 1.0, -2.0, 3.5, 4.0, -1.0, -2.0, 0.5, 1.5, 2.5 };

    for(int i = 2; i < zahlen.Length; i += 3) {
      if(zahlen[i] >= 0) {
        zahlen[i] *= 3.0;
      }
    }

    Console.WriteLine(string.Join("; ", zahlen));
  }

  /* Aufgabe 1d:
    Die Variable bFeld enthält ein Feld von Wahrheitswerten mit mehr als 2 Elementen. Übersetzen Sie: 
    Das letzte Element wird auf das Gegenteil des Elements in der Mitte des Feldes gesetzt.
    (Annahme: Das Feld hat eine ungerade Anzahl von Elementen.)
  */
  static void aufg1d() {
    Console.WriteLine("Aufgabe 1d");
    bool[] bFeld = { true, false, false, true, false, false, true };
    Console.WriteLine(bFeld.Length / 2); // Index des mittleren Elements

    bFeld[bFeld.Length - 1] = !bFeld[bFeld.Length / 2];

    Console.WriteLine(string.Join("; ", bFeld));
  }

  /* Aufgabe 1e:
    Die Variable sfeld enthält ein dynamisches Feld von Strings. Übersetzen Sie: 
    Solange die Anzahl der Elemente nicht durch 13 teilbar ist, werden leere Strings an das Ende des Feldes angehängt.
  */
  static void aufg1e() {
    Console.WriteLine("Aufgabe 1e");
    List<string> sfeld = new List<string> { "Hallo", "C#", "Probeklausur" };

    while(sfeld.Count % 13 != 0) {
      sfeld.Add("");
    }

    Console.WriteLine(sfeld.Count);
  }

}

// Aufgabe 2a: Öffentliche Struktur Gemüse
public struct Gemüse {
  public string Name;
  public int Kalorien;
  public double Gewicht;

  // Optionaler Konstruktor
  public Gemüse(string name, int kalorien, double gewicht) {
    Name = name;
    Kalorien = kalorien;
    Gewicht = gewicht;
  }

  // Optional: Überschreiben der ToString-Methode für bessere Ausgabe
  public override string ToString() {
    return $"{Name} ({Gewicht} g, {Kalorien} kcal)";
  }

  // Aufgabe 2b: Durchschnitt Kalorien für Gewicht > grenze
  public static double DSKal(List<Gemüse> dasGemüse, int grenze) {
    double summe = 0.0;
    int anzahl = 0;

    foreach(Gemüse g in dasGemüse) {
      if(g.Gewicht > grenze) {
        summe += g.Kalorien;
        anzahl++;
      }
    }

    return anzahl == 0 ? 0.0 : summe / anzahl;
  }

  // Aufgabe 2c: MaxGewicht für Namen
  public static double MaxGewicht(List<Gemüse> dasGemüse, string name) {
    double max = double.MinValue;

    foreach(Gemüse g in dasGemüse) {
      if(g.Name == name && g.Gewicht > max) {
        max = g.Gewicht;
      }
    }

    return max;
  }

  // Aufgabe 2d: AlleKalorien bei Gewicht <= maxgewicht
  public static List<int> AlleKalorien(List<Gemüse> dasGemüse, double maxgewicht) {
    List<int> kalorien = new List<int>();

    foreach(Gemüse g in dasGemüse) {
      if(g.Gewicht <= maxgewicht) {
        kalorien.Add(g.Kalorien);
      }
    }

    return kalorien;
  }

  // Aufgabe 2e: Alle Elemente mit maximalem Gewicht und passendem Namen
  public static List<Gemüse> AlleMaxGewichtMit(List<Gemüse> dasGemüse, string name) {
    List<Gemüse> ergebnis = new List<Gemüse>();
    double max = MaxGewicht(dasGemüse, name);
    if(max == double.MinValue) {
      return ergebnis;
    }

    foreach(Gemüse g in dasGemüse) {
      if(g.Name == name && g.Gewicht == max) {
        ergebnis.Add(g);
      }
    }

    return ergebnis;
  }

}
