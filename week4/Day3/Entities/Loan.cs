namespace MyFirstApi.Entities;

public class Loan
{
    public int LoanId { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string Status { get; set; } = string.Empty;

    // Foreign Keys
    public int BookId { get; set; }

    public int LibraryMemberId { get; set; }

    // Navigation Properties
    public Book Book { get; set; } = null!;

    public LibraryMember LibraryMember { get; set; } = null!;
}