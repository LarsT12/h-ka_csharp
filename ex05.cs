using System;
using System.IO;
using System.Collections.Generic;

class Textanalyse {
  
  static void Main() {
    string fileName = "ex05.txt";
    // ausgeben0(fileName);
    // ausgeben1(fileName);
    // rueckwaertsAusgeben0(fileName);
    rueckwaertsAusgeben1(fileName);
  }

  static void ausgeben0(string fileName) {
    Console.WriteLine("*** ausgeben0 ***");
    StreamReader reader;
    
    try {
      reader = new StreamReader(fileName);
    } catch (Exception ex) {
      Console.WriteLine($"Fehler beim Öffnen der Datei: {ex.Message}");
      return;
    }

    try {
      string line;
      while((line = reader.ReadLine()) != null) {
        Console.WriteLine(line);
      }
    } finally {
      reader.Close();
    }
    Console.WriteLine("****************");
  }

  static void ausgeben1(string fileName) {
    Console.WriteLine("*** ausgeben ***");
    using(StreamReader reader = new StreamReader(fileName)) {
      string line;
      while((line = reader.ReadLine()) != null) {
        Console.WriteLine(line);
      }
    }
    Console.WriteLine("****************");
  }

  static void rueckwaertsAusgeben0(string fileName) {
    Console.WriteLine("*** rueckwaertsAusgeben0 ***");
    using(StreamReader reader = new StreamReader(fileName)) {
      string line;
      while((line = reader.ReadLine()) != null) {
        Console.WriteLine();
        Console.WriteLine($"Original: {line}");
        Console.Write("Rückwärts: ");
        for (int i = line.Length - 1; i >= 0; i--) {
          char c = line[i];
          Console.Write(c);
        }
        Console.WriteLine();
      }
    }
    Console.WriteLine("****************************");
  }

  static void rueckwaertsAusgeben1(string fileName) {
    Console.WriteLine("*** rueckwaertsAusgeben1 ***");
    string[] lines = File.ReadAllLines(fileName);
    foreach(string line in lines) {
      Console.WriteLine();
      Console.WriteLine($"Original: {line}");
      Console.Write("Rückwärts: ");
      for(int i = line.Length - 1; i >= 0; i--) {
        Console.Write(line[i]);
      }
      Console.WriteLine();
    }
    Console.WriteLine("****************************");
  }  
}