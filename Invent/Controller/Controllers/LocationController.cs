using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace Controller.Controllers;

[ApiController]
[Route("location")]
public class LocationController : AController<Location> {
    public LocationController(ILocationRepository repository) : base(repository) {
    }
}