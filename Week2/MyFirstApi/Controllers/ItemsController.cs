using MyFirstApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    // Constructor Injection
    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        var items = _itemService.GetItems();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        var items = _itemService.GetItems();

        if (id < 1 || id > items.Count)
        {
            return NotFound();
        }

        return Ok(items[id - 1]);
    }
}