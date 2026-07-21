using System;

class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer(1, "Lubna", "lubna@gmail.com");

        Order order = new Order(1001, "Arduino ", 250);

        OrderRequest request = new OrderRequest("ESP32", 80);

        Console.WriteLine("Customer Information");
        Console.WriteLine($"Name: {customer.Name}");
        Console.WriteLine($"Email: {customer.Email}");

        Console.WriteLine();

        Console.WriteLine("Order Information");
        Console.WriteLine($"Product: {order.ProductName}");
        Console.WriteLine($"Price: {order.Price}");

        Console.WriteLine();

        Console.WriteLine("Record Information");
        Console.WriteLine($"Product: {request.ProductName}");
        Console.WriteLine($"Price: {request.Price}");

        Console.WriteLine();

        SendNotification(customer);
        SendNotification(order);

        customer.ChangeEmail("lubna22@gmail.com");

        Console.WriteLine();
        Console.WriteLine("Updated Email:");
        Console.WriteLine(customer.Email);
    }

    static void SendNotification(INotifiable target)
    {
        target.Notify();
    }
}