using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace Controller.Controllers;

[ApiController]
[Route("inventory")]
public class InventoryController : AController<Inventory> {
    public InventoryController(IInventoryRepository repository) : base(repository) {
    }
}