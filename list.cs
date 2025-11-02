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

    int[] temperaturen = { 15, 22, 18, 30, 25, 20, 28, 19, 24, 21 };
    for(int i = 0; i < temperaturen.Length; i++) {
      Console.WriteLine($"Tag {(i + 1)}: {temperaturen[i]}°C");
    }

    // List
    List<int> tempListe = new List<int>() { 15, 22, 18, 30, 25, 20, 28, 19, 24};
    tempListe.Add(21);
    Console.WriteLine(tempListe[4]);
    tempListe[7] = 27;
    Console.WriteLine(tempListe[7]);

    for(int i = 0; i < tempListe.Count; i++) {
      Console.WriteLine($"Tag {(i + 1)}: {tempListe[i]}°C");
    }

    foreach(int temp in tempListe) {
      Console.WriteLine($"{temp}°C");
    }

    tempListe.RemoveAt(2);
    Console.WriteLine("Nach dem Entfernen des 3. Elements:");
    foreach(int temp in tempListe) {
      Console.WriteLine($"{temp}°C");
    }
  }
}