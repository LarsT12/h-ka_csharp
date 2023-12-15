using System;
using System.IO;

class Klausur2018SoSe {
  public static void Main() {
    Console.WriteLine("Klausur 2018, SoSe");

    Schreibe("klausur_2018_SoSe_Aufg3a.txt", 5);
    ZähleEinser("klausur_2018_SoSe_Aufg3c.txt");
  }

  public static void Schreibe(string dateiname, int breite) {
    using(StreamWriter sw = new StreamWriter(dateiname)) {
      for(int y = 0; y < breite; ++y) {
        for(int x = 0; x < breite; ++x) {
          sw.Write(1 + (x % (y + 1)));
        }
        sw.WriteLine();
      }
    }

    /*
    StreamWriter sw2 = new StreamWriter(dateiname);
    try {
      sw2.Write("Hier kommt ein alternativer Text.");
      int foo = 10 / 0;
    } finally {
      sw2.Close();
    }
    */
  }

  public static void ZähleEinser(string dateiname) {
    StreamReader sr = null;
    try {
      sr = new StreamReader(dateiname);
    } catch(Exception e) {
      Console.WriteLine(e.Message);
    } finally {
      if(sr != null) {
        sr.Close();
      }
    }
  }
}