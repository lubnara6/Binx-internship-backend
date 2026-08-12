using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Data;
using MyFirstApi.Entities;
using MyFirstApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MyFirstApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize(Policy = "AdminOnly")]
   [HttpPost]
public async Task<IActionResult> Create(CreateBookRequest request)
{
    var validator = new CreateBookRequestValidator();

    var validationResult = await validator.ValidateAsync(request);

    if (!validationResult.IsValid)
    {
        return BadRequest(validationResult.Errors);
    }

    var book = new Book
    {
        Title = request.Title,
        Price = request.Price,
        AuthorId = request.AuthorId
    };

    _context.Books.Add(book);
    await _context.SaveChangesAsync();

    return Ok(book);
}
   [HttpGet]
public async Task<IActionResult> GetAll()
{
    var books = await _context.Books
        .Select(book => new
        {
            book.BookId,
            book.Title,
            book.Price,
            book.AuthorId
        })
        .ToListAsync();

    return Ok(books);
}[HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
{
    var book = await _context.Books
        .Where(book => book.BookId == id)
        .Select(book => new
        {
            book.BookId,
            book.Title,
            book.Price,
            book.AuthorId
        })
        .FirstOrDefaultAsync();

    if (book == null)
    {
        return NotFound();
    }

    return Ok(book);
}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateBookRequest request)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = request.Title;
        book.Price = request.Price;
        book.AuthorId = request.AuthorId;

        await _context.SaveChangesAsync();

        return Ok(book);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}