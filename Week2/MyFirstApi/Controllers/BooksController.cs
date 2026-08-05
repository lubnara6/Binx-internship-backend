using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Data;
using MyFirstApi.Entities;
using MyFirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookRequest request)
    {
        Book book = new Book();

        book.Title = request.Title;
        book.Price = request.Price;
        book.AuthorId = request.AuthorId;

        _context.Books.Add(book);

        await _context.SaveChangesAsync();

        return Ok(book);
    }
    [HttpGet]
public async Task<IActionResult> GetAll()
{
    var books = await _context.Books.ToListAsync();

    return Ok(books);
}
[HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
{
    var book = await _context.Books.FindAsync(id);

    if (book == null)
    {
        return NotFound();
    }

    return Ok(book);
}
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, CreateBookRequest request)
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