using System;

class Aufgabe11 {
  static void Main(string[] args) {
    Geldbörse g1 = new Geldbörse("Geldbörse 1");
    Geldbörse g2 = new Geldbörse("Geldbörse 2");

    Console.WriteLine(g1);
    g1.GeldbörseFüllen(2000);
    Console.WriteLine(g1);

    Console.WriteLine(g2);
    g2.GeldbörseFüllen(3000);
    Console.WriteLine(g2);
  }

  struct Geldbörse {
    string name;
    int betrag;
    bool leer;

    public Geldbörse(string name = "Geldbörse") {
      this.name = name;
      betrag = 0;
      leer = true;
    }

    public void GeldbörseFüllen(int zusätzlicherBetrag) {
      if (zusätzlicherBetrag < 0)
        throw new Exception("zusätzlicher Betrag muss positivsein!");
      
      betrag += zusätzlicherBetrag;
      leer = betrag == 0;
    }

    public void GeldbörseLeeren(ref int entnommenerBetrag) {
      if (entnommenerBetrag < 0)
        throw new Exception("entnommener Betrag muss positiv sein!");
    
      entnommenerBetrag = betrag - entnommenerBetrag < 0 ? betrag : entnommenerBetrag;
      betrag -= entnommenerBetrag;
      leer = betrag == 0;
    }

    public override string ToString()
      => $"Name: {name}, Betrag: {betrag / 100.0:C}{(leer ? " (leer)" : "")}";

  }
}
