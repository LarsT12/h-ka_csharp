using System;
using System.Collections.Generic;

class WarenWirtschaft {
  public static void Main() {
    Console.WriteLine("Meine Warenwirtschaft");

    Stock s1 = new Stock("Hauptlager");
 
    Product p1 = new Product();
    p1.Number = "987678";
    p1.Name = "Bürostuhl";
    p1.Category = "Büromöbel";
    p1.Price = 70.5;
    p1.MinOrderQty = 10;

    Product p2 = new Product();
    p2.Number = "983424";
    p2.Name = "Arbeitstisch";
    p2.Category = "Büromöbel";
    p2.Price = 230.0;
    p2.MinOrderQty = 5;

    s1.Products.Add(p1);
    s1.Products.Add(p2);
  
    Console.WriteLine(s1.Products[0].Name + ": " + s1.Products[0].Price + " EUR");
    Console.WriteLine(p2.Name + ": " + p2.Price + " EUR");
  }
}

class Product {
  public string Number;
  public string Name;
  public double Price;
  public string Category;
  public int MinOrderQty;
}

class Stock {
  public string Name;
  public List<Product> Products;

  public Stock(string Name) {
    this.Name = Name;
    Products = new List<Product>();
  }
}