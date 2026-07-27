using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public List<Order> Orders { get; set; } = new();
}
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new()
{
    new Customer { Id = 1, Name = "Ahmed" },
    new Customer { Id = 2, Name = "Lubna" },
    new Customer { Id = 3, Name = "Sara" },
    new Customer { Id = 4, Name = "Omar" },
    new Customer { Id = 5, Name = "Ali" },
    new Customer { Id = 6, Name = "Noor" }
};
List<Order> orders = new()
{
    new Order { Id = 1, CustomerId = 1, Amount = 100 },
    new Order { Id = 2, CustomerId = 2, Amount = 200 },
    new Order { Id = 3, CustomerId = 1, Amount = 50 },
    new Order { Id = 4, CustomerId = 3, Amount = 300 },
    new Order { Id = 5, CustomerId = 2, Amount = 150 },
    new Order { Id = 6, CustomerId = 4, Amount = 400 }
};



customers[0].Orders.Add(new Order { Id = 1, CustomerId = 1, Amount = 100 });
customers[0].Orders.Add(new Order { Id = 2, CustomerId = 1, Amount = 50 });

customers[1].Orders.Add(new Order { Id = 3, CustomerId = 2, Amount = 200 });
customers[1].Orders.Add(new Order { Id = 4, CustomerId = 2, Amount = 150 });

customers[2].Orders.Add(new Order { Id = 5, CustomerId = 3, Amount = 300 });

customers[3].Orders.Add(new Order { Id = 6, CustomerId = 4, Amount = 400 });



var ordersByCustomer = orders
    .GroupBy(o => o.CustomerId)
    .Select(g => new
    {
        CustomerId = g.Key,
        Total = g.Sum(o => o.Amount)
    });
    foreach (var item in ordersByCustomer)
{
    Console.WriteLine($"Customer ID: {item.CustomerId}, Total: {item.Total}");
}
var customerOrders = customers
    .Join(
        orders,
        c => c.Id,
        o => o.CustomerId,
        (c, o) => new
        {
            CustomerName = c.Name,
            OrderAmount = o.Amount
        });
        foreach (var item in customerOrders)
{
                 Console.WriteLine($"{item.CustomerName} - {item.OrderAmount}");
}
var allOrders = customers
    .SelectMany(c => c.Orders);
foreach (var order in allOrders)
{
    Console.WriteLine(order.Amount);
}

// Deferred Execution:
// The query is not executed when it is defined.
// It executes only during foreach.
// Therefore, the new order (Amount = 500) appears in the results.

var result = orders.Where(o => o.Amount > 100);

orders.Add(new Order
{
    Id = 7,
    CustomerId = 5,
    Amount = 500
});

foreach (var order in result)
{
    Console.WriteLine(order.Amount);
}
        }
    }
}