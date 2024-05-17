using System;
using System.Collections.Generic;

class WarenWirtschaft {
  public static void Main() {
    Console.WriteLine("Meine Warenwirtschaft");

    Stock s1 = new Stock("Hauptlager");
 
    Product p1 = new Product("987678", "Bürostuhl", "Büromöbel", 70.5, 10);
    Product p2 = new Product("983424", "Arbeitstisch", "Büromöbel", 230.0, 5);
    Product p3 = new Product("981424", "Barhocker");

    p1.PriceProtocol.Add(p1.Price);
    p1.Price = 89.0;

    p1.PriceProtocol.Add(p1.Price);
    p1.Price = 91.5;

    s1.Products.Add(p1);
    s1.Products.Add(p2);
  
    Console.WriteLine(s1.Products[0].Name + ": " + s1.Products[0].Price + " EUR");
    Console.WriteLine(p2.Number + " (" + p2.Name + "): " + p2.Price + " EUR");
  }
}

class Product {
  public string Number { get; private set; }
  public string Name;
  public double Price;
  public List<double> PriceProtocol = new List<double>();
  public string Category;
  public int MinOrderQty;

  public Product(string number, string name) {
    Number = number;
    Name = name;
  }

  public Product(string number, string name, string category, double price, int minOrderQty) {
    Number = number;
    Name = name;
    Category = category;
    Price = price;
    MinOrderQty = minOrderQty;
  }
}

class Stock {
  public string Name;
  public List<Product> Products;

  public Stock(string Name) {
    this.Name = Name;
    Products = new List<Product>();
  }
}