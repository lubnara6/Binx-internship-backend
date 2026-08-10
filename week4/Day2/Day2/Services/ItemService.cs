namespace MyFirstApi.Services;

public class ItemService : IItemService
{
    public List<string> GetItems()
    {
        return new List<string>
        {
            "Laptop",
            "Mouse",
            "Keyboard"
        };
    }
}