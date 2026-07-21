public class Order : INotifiable
{
    public int OrderId { get; }
    public string ProductName { get; private set; }
    public decimal Price { get; private set; }

    public Order(int orderId, string productName, decimal price)
    {
        OrderId = orderId;
        ProductName = productName;
        Price = price;
    }

    public void Notify()
    {
        Console.WriteLine($"Notification sent for Order #{OrderId}");
    }
}