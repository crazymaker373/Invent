using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<Item>> ReadByCode(string code) => Ok(await _itemRepository.ReadByCodeAsync(code));
    
}