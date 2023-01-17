using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Entities;

namespace Controller.Controllers;

[Route("/item")]
[ApiController]
public class ItemController : AController<Item> {
    private readonly IItemRepository _itemRepository;
    public ItemController(IItemRepository repository) : base(repository) {
        _itemRepository = repository;
    }

    [HttpGet("{code}")]
    public async Task<ActionResult<ItemDto>> ReadByCode(string code) {
        var item = await _itemRepository.ReadByCodeAsync(code);
        
        if (item == null) {
            return NotFound();
        }
        var itemDto = new ItemDto(item.Name, item.Description, item.AddedAt.ToString("dddd, dd MMMM yyyy HH:mm:ss"), item.Code, item.IsMissing, item.ItemType.ToString(), item.Location.Name, item.Location.Address, item.Location.IsRemote);
        return Ok(itemDto);
    } 
    
}