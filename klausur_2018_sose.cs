using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Klausur2018SoSe {
  public static void Main() {
    Console.WriteLine("Klausur 2018 SoSe");
    aufg3a();
    aufg3b();
  }

  public static void aufg3a() {
    Schreibe("klausur_2018_sose_aufg3a.txt", 5);
  }

  public static void Schreibe(string dateiname, int breite) {
    using(StreamWriter sw = new StreamWriter(dateiname)) {
      for(int zeile = 0; zeile < breite; ++zeile) {
        for(int spalte = 0; spalte < breite; ++spalte) { 
          sw.Write(1 + (spalte % (zeile + 1)));
        }
        sw.WriteLine();
      }
    }
  }

  public static void aufg3b() {
    int anzahl = ZaehleEinser("klausur_2018_sose_aufg3b.txt");
    Console.WriteLine(anzahl);

    anzahl = ZaehleEinser_Alternative("klausur_2018_sose_aufg3b.txt");
    Console.WriteLine(anzahl);
  }

  public static int ZaehleEinser(string dateiname) {
    int anzahl = 0;

    try {
      using(StreamReader sr = new StreamReader(dateiname)) {
        string zeile;
        while((zeile = sr.ReadLine()) != null) {
          string[] woerter = zeile.Split(new char[] {' ', '\t', '.', '?', '!', ',', ';', ':'}, StringSplitOptions.RemoveEmptyEntries); // Split bei Leerzeichen, Tabulator und üblichen Satzzeichen
          /* Hinweis: 
            Das Entfernen leerer Elemente ist NICHT optional, da ansonsten leere Wörter als Treffer gewertet werden. 
            Alternativ kann in der nachfolgenden foreach-Schleife noch eine if-Schleife als Prüfung ergänzt werden,
            ob das wort nicht leer ist - nur dann ist der gesamte Code in der Schleife auszuführen.
          */
          foreach(string wort in woerter) {
            // Console.WriteLine(wort); // Einschalten, um die Wörter zu kontrollieren (nicht Teil der Aufgabenstellung!)
            bool treffer = true;
            foreach(char z in wort) {
              if(z != '1') treffer = false;
            }
            if(treffer) anzahl++;
          }
        }
      }
    } catch(IOException e) {
      Console.WriteLine(e.Message);
    }

    return anzahl;
  }

  public static int ZaehleEinser_Alternative(string dateiname) {
    int anzahl = 0;

    try {
      anzahl = File.ReadLines(dateiname)
        .SelectMany(zeile => zeile.Split(new char[] {' ', '\t', '.', '?', '!', ',', ';', ':'}, StringSplitOptions.RemoveEmptyEntries))
        .Count(wort => wort.All(zeichen => zeichen == '1'));
    } catch(IOException e) {
      Console.WriteLine(e.Message);
    }

    return anzahl;
  }

}