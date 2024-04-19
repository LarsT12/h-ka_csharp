using System;
using System.IO;
using System.Collections.Generic;

class Klausur2018WiSe {
  public static void Main() {
    Console.WriteLine("Klausur 2018, WiSe");

    Schreibe("klausur_2018_WiSe_Aufg3a.txt", 10);
    aufg3b();
  }

  public static void aufg3b() {
    List<double> summen = ZeilenSumme("klausur_2018_WiSe_Aufg3b.txt");
    Console.WriteLine("Ausgabe der zeilenweisen Summen:");

    foreach(double s in summen) {
      Console.WriteLine(s);
    }
  }

  public static List<double> ZeilenSumme(string dName) {
    List<double> summen = new List<double>();

    StreamReader sr = new StreamReader(dName);
    string zeile;
    while((zeile = sr.ReadLine()) != null) {
      double s = 0;
      string[] elemente = zeile.Split(new char[]{':'});
      foreach(string elem in elemente) {
        if(elem.Length > 0) {
          s += Convert.ToDouble(elem);
          /*
          // Alternative Lösung, die sicherstellt, dass nur gültige Zahlen verarbeitet werden
          double zahl;
          if(double.TryParse(elem, out zahl)) {
            s += zahl;
          }
          */
        }
      }
      summen.Add(s);
    }

    return summen;
  }

  public static void Schreibe(string dName, int breite) {
    StreamWriter sw = null;

    try {
      sw = new StreamWriter(dName);

      for(int z = 0; z < breite; z++) {
        for(int s = 0; s < breite; s++) {
          string x = (z - s) % 5 == 0 ? "+" : "_";
          /*
          // statt des o.g. Anweisung mit dem tenären (bedingten) Operator, kann man auch folgendes schreiben 
          string x;
          if((z - s) % 5 == 0) {
            x = "+";
          } else {
            x = "_";
          }
          */
          sw.Write(x);
        }
        sw.WriteLine();
      }
    } catch(IOException e) {
      Console.WriteLine("Fehlermeldung: " + e.Message);
    } finally {
      if(sw != null) {
        sw.Close();
      }
    }
  }

}