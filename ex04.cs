using System;
using System.Collections.Generic;

class Test {
  static void Main(string[] args) {
    Console.WriteLine(A.getDescription());
    
    A a = new A(3);
    Console.WriteLine(a.calculateSomething());
    Console.WriteLine(a);

    B b = new B();
    Console.WriteLine(b);
  
  }
  
  class B {
    public override string ToString() {
      return "Ich bin die Klasse B.";
    }
  }
}

class A {
  public static string getDescription() {
    return "Ich bin die Klasse A.";
  }

  private int someValue;
  public int calculateSomething() {
    return someValue * 7;
  }

  public A(int someValue) {
    this.someValue = someValue;
  }

  public override string ToString() {
    return $"Ich bin ein A-Objekt mit der Wertigkeit {someValue}.";
  }

  public override int GetHashCode() {
    return 42;
  }

}