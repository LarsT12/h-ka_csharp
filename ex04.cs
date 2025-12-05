using System;
using System.Collections.Generic;

class Test {
  static void Main(string[] args) {
    A foo = new A();
    Console.WriteLine(foo);
  }
}

class A {

  public override string ToString() {
    return $"Ich bin ein A-Objekt mit dem Hashcode {GetHashCode()}.";
  }

  public override int GetHashCode() {
    return 42;
  }
}