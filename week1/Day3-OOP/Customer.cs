public class Customer : INotifiable
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public Customer(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public void ChangeEmail(string newEmail)
    {
        Email = newEmail;
    }

    public void Notify()
    {
        Console.WriteLine($"Notification sent to customer {Name}");
    }
}