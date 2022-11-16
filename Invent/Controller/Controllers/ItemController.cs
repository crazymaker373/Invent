using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace Controller.Controllers;
[Route("/item")]
[ApiController]
public class ItemController : AController<Item>{
    public ItemController(IRepository<Item> repository) : base(repository){
    }
}