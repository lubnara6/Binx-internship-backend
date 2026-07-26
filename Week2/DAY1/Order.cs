public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public decimal Total { get; set; }

    public override string ToString()
    {
        return $"Order #{Id}: Customer: {CustomerName}, Total: {Total}";
    }
}