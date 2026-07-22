using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Async Method
        string status = await GetOrderStatusAsync();
        Console.WriteLine(status);

        // List of Orders
        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, ProductName = "Laptop", Price = 3500 },
            new Order { OrderId = 2, ProductName = "Mouse", Price = 50 },
            new Order { OrderId = 3, ProductName = "Keyboard", Price = 120 },
            new Order { OrderId = 4, ProductName = "Monitor", Price = 900 },
            new Order { OrderId = 5, ProductName = "USB", Price = 40 },
            new Order { OrderId = 6, ProductName = "Headphones", Price = 200 },
            new Order { OrderId = 7, ProductName = "Camera", Price = 1500 },
            new Order { OrderId = 8, ProductName = "Speaker", Price = 300 }
        };

        // LINQ - Filter
        var expensiveOrders = orders.Where(order => order.Price > 500);

        Console.WriteLine("\nOrders with price greater than 500:");
        foreach (var order in expensiveOrders)
        {
            Console.WriteLine($"{order.ProductName} - {order.Price}");
        }

        // LINQ - Projection
        var productNames = orders.Select(order => order.ProductName);

        Console.WriteLine("\nProduct Names:");
        foreach (var name in productNames)
        {
            Console.WriteLine(name);
        }

        // LINQ - Aggregation
        decimal totalPrice = orders.Sum(order => order.Price);

        Console.WriteLine($"\nTotal Price: {totalPrice}");

        // Exception Handling
        try
        {
            Console.Write("\nEnter a number: ");
            int number = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"You entered: {number}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    // Async Method
    static async Task<string> GetOrderStatusAsync()
    {
        await Task.Delay(2000);

        return "Order processed successfully!";
    }
}