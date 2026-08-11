namespace MyFirstApi.Entities;

public class Author
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}