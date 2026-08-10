namespace MyFirstApi.Entities;

public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}