namespace MyFirstApi.Models;

public class UpdateBookRequest
{
    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int AuthorId { get; set; }
}