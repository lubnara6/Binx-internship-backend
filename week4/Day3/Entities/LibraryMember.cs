namespace MyFirstApi.Entities;

public class LibraryMember
{
    public int LibraryMemberId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}