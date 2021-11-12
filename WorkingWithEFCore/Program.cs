using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Logging;
using Packt.Shared;
using static System.Console;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // modelBuilder.Entity<Product>().Property(product => product.ProductName).IsRequired().HasMaxLength(40);
            // modelBuilder.Entity<Product>().HasData(new Product { ProductName = "test" });
            // QueryingCategories();
            QueryingProducts();

        }

        static void QueryingCategories()
        {
            using(var db=new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Categories and how many products they have:");

                // a query to get all categories and ther related products
                IQueryable<Category> cats = db.Categories.Include(c => c.Products);

                foreach(Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db=new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Products that cost more than a price,highest at top.");
                string input;
                decimal price;
                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                // IOrderedEnumerable<Product> prods = db.Products.AsEnumerable().Where(p => p.Cost > price).OrderByDescending(p => p.Cost);
                IOrderedEnumerable<Product>  prods =db.Products.TagWith("Products filtered by price and sorted.").AsEnumerable().Where(p => p.Cost > price).OrderByDescending(p => p.Cost);
                foreach (Product item in prods)
                {
                    WriteLine("{0}:{1} costs {2:$#,##0.0..} and has {3} in stock.", item.ProductID, item.ProductName, item.Cost, item.Stock);
                }
            }
        }
    }
}
