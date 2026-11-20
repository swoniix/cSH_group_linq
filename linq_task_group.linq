<Query Kind="Program" />

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "iPhone 15", Category = "Smartphones", Brand = "Apple", Price = 35000 },
            new Product { Name = "iPhone 14", Category = "Smartphones", Brand = "Apple", Price = 28000 },
            new Product { Name = "Samsung S24", Category = "Smartphones", Brand = "Samsung", Price = 32000 },
            new Product { Name = "Samsung A55", Category = "Smartphones", Brand = "Samsung", Price = 15000 },

            new Product { Name = "MacBook Air", Category = "Laptops", Brand = "Apple", Price = 45000 },
            new Product { Name = "MacBook Pro", Category = "Laptops", Brand = "Apple", Price = 75000 },
            new Product { Name = "Lenovo ThinkPad", Category = "Laptops", Brand = "Lenovo", Price = 38000 },
            new Product { Name = "Lenovo IdeaPad", Category = "Laptops", Brand = "Lenovo", Price = 25000 },

            new Product { Name = "Samsung TV", Category = "TV", Brand = "Samsung", Price = 29000 },
            new Product { Name = "LG OLED", Category = "TV", Brand = "LG", Price = 55000 },

            new Product { Name = "AirPods", Category = "Accessories", Brand = "Apple", Price = 8000 },
            new Product { Name = "Galaxy Buds", Category = "Accessories", Brand = "Samsung", Price = 5000 },
            new Product { Name = "Logitech Mouse", Category = "Accessories", Brand = "Logitech", Price = 1500 },
            new Product { Name = "Logitech Keyboard", Category = "Accessories", Brand = "Logitech", Price = 2500 }
        };
		Console.WriteLine("Task 1");
        var brandCounts = products
            .GroupBy(product => product.Brand)
            .Select(group => new
            {
                Brand = group.Key,
                Count = group.Count()
            });

        foreach (var item in brandCounts)
        {
            Console.WriteLine($"{item.Brand}: {item.Count}");
        }
		Console.WriteLine("\nTask 2");
        var averagePrices = products
            .GroupBy(product => product.Category)
            .Select(group => new
            {
                Category = group.Key,
                AveragePrice = Math.Round(group.Average(product => product.Price), 2)
            });

        foreach (var item in averagePrices)
        {
            Console.WriteLine($"{item.Category}: {item.AveragePrice}");
        }
		Console.WriteLine("\nTask 3");
        var mostExpensive = products
            .GroupBy(product => product.Brand)
            .Select(group => group
                .OrderByDescending(product => product.Price)
                .First());

        foreach (var product in mostExpensive)
        {
            Console.WriteLine($"{product.Brand}: {product.Name}: {product.Price}");
        }
    }
}

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
}