using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sample data setup
            List<Product> ProductList = new List<Product>
            {
                new Product { Name = "Chai", Category = "Beverages", UnitPrice = 18.00m, UnitsInStock = 39 },
                new Product { Name = "Chang", Category = "Beverages", UnitPrice = 19.00m, UnitsInStock = 17 },
                new Product { Name = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00m, UnitsInStock = 13 },
                new Product { Name = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00m, UnitsInStock = 53 },
                new Product { Name = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18.40m, UnitsInStock = 123 },
                new Product { Name = "Jack's New England Clam Chowder", Category = "Seafood", UnitPrice = 9.65m, UnitsInStock = 0 },
                new Product { Name = "Konbu", Category = "Seafood", UnitPrice = 6.00m, UnitsInStock = 24 },
                new Product { Name = "Röd Kaviar", Category = "Seafood", UnitPrice = 15.00m, UnitsInStock = 15 }
            };

            List<Order> OrderList = new List<Order>
            {
                new Order { CustomerID = "ALFKI", OrderDate = new DateTime(1996, 7, 4) },
                new Order { CustomerID = "BERGS", OrderDate = new DateTime(1997, 8, 15) },
                new Order { CustomerID = "ANTON", OrderDate = new DateTime(1998, 3, 10) },
                new Order { CustomerID = "BONAP", OrderDate = new DateTime(1996, 12, 1) }
            };

            // Q1: Get all products from the "Seafood" category
            Console.WriteLine("=== Q1 ===");
            var seafoodProducts = ProductList.Where(p => p.Category == "Seafood");
            foreach (var product in seafoodProducts)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.UnitPrice:C}");
            }

            // Q2: Get a list of only the product names from ProductList
            Console.WriteLine("\n=== Q2 ===");
            var productNames = ProductList.Select(p => p.Name);
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }

            // Q3: Sort all products by UnitPrice (ascending)
            Console.WriteLine("\n=== Q3 ===");
            var sortedByPrice = ProductList.OrderBy(p => p.UnitPrice);
            foreach (var product in sortedByPrice)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.UnitPrice:C}");
            }

            // Q4: Get all products where UnitPrice is between 10 and 30
            Console.WriteLine("\n=== Q4 ===");
            var priceRangeProducts = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var product in priceRangeProducts)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.UnitPrice:C}");
            }

            // Q5: Get all products that are in stock and belong to "Condiments" category
            Console.WriteLine("\n=== Q5 ===");
            var inStockCondiments = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
            foreach (var product in inStockCondiments)
            {
                Console.WriteLine($"Product: {product.Name}, Stock: {product.UnitsInStock}, Category: {product.Category}");
            }

            // Q6: Create a new anonymous type with three properties
            Console.WriteLine("\n=== Q6 ===");
            var productStatus = ProductList.Select(p => new
            {
                Name = p.Name,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in productStatus)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price:C}, Status: {item.StockStatus}");
            }

            // Q7: Print each product's name along with its position (1-based)
            Console.WriteLine("\n=== Q7 ===");
            var productsWithPosition = ProductList.Select((p, index) => new { Position = index + 1, Name = p.Name });
            Console.WriteLine(string.Join(", ", productsWithPosition.Select(x => $"{x.Position}. {x.Name}")));

            // Q8: Sort ProductList by Category ascending, then within each category by UnitPrice descending
            Console.WriteLine("\n=== Q8 ===");
            var sortedByCategoryThenPrice = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var product in sortedByCategoryThenPrice)
            {
                Console.WriteLine($"Category: {product.Category}, Product: {product.Name}, Price: {product.UnitPrice:C}");
            }

            // Q9: Get all products from "Beverages" category, sorted by UnitsInStock descending
            Console.WriteLine("\n=== Q9 ===");
            var beveragesByStock = ProductList.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);
            foreach (var product in beveragesByStock)
            {
                Console.WriteLine($"Product: {product.Name}, Stock: {product.UnitsInStock}");
            }

            // Q10: Using QUERY SYNTAX with compound from clause, list orders from 1997 or later
            Console.WriteLine("\n=== Q10 ===");
            var recentOrders = from order in OrderList
                               where order.OrderDate.Year >= 1997
                               select new { order.CustomerID, order.OrderDate };
            foreach (var order in recentOrders)
            {
                Console.WriteLine($"CustomerID: {order.CustomerID}, OrderDate: {order.OrderDate.ToShortDateString()}");
            }

            // Q11: Show position number alongside ProductName
            Console.WriteLine("\n=== Q11 ===");
            var productsWithIndex = ProductList.Select((p, idx) => $"{idx + 1}. {p.Name}");
            foreach (var item in productsWithIndex)
            {
                Console.WriteLine(item);
            }

            // Q12: Sort array by word length, then case-insensitive sort
            Console.WriteLine("\n=== Q12 ===");
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }

            // Q13: Create a list of all digits in the array whose second letter is 'i' (reversed from original order)
            Console.WriteLine("\n=== Q13 ===");
            string[] wordsWithDigits = { "ti2ger", "li3on", "zi4bra", "fi5sh", "bi6rd" };
            var result = wordsWithDigits
                .Where(w => w.Length > 1 && w[1] == 'i')
                .SelectMany(w => w.Where(char.IsDigit))
                .Reverse();
            Console.WriteLine("Digits from words with second letter 'i' (reversed): " + string.Join(", ", result));

            // Alternative if question meant digits as numbers 0-9 in a string array
            Console.WriteLine("\n=== Q13 Alternative (if array contains digits as strings) ===");
            string[] digitArray = { "ai0", "bi1", "ci2", "di3", "ei4", "fi5" };
            var digitResult = digitArray
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse()
                .SelectMany(d => d.Where(char.IsDigit));
            Console.WriteLine("Digits: " + string.Join(", ", digitResult));
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    public class Order
    {
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}