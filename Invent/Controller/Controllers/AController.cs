using System.ComponentModel.DataAnnotations;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

public abstract class AController<TEntity> : ControllerBase where TEntity : class {
    private readonly IRepository<TEntity> _repository;

    public AController(IRepository<TEntity> repository) {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<TEntity>>> ReadAllAsync() {
        return Ok(await _repository.ReadAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<TEntity>> CreateAsync([Required] TEntity entity) {
        await _repository.CreateAsync(entity);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TEntity>> UpdateAsync([Required] int id, [Required] TEntity entity) {
        var c = await _repository.ReadAsync(id);

        if (c == null) return NotFound();

        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult<TEntity>> DeleteAsync([Required] int id) {
        var c = await _repository.ReadAsync(id);

        if (c == null) return NotFound();

        await _repository.DeleteAsync(c);
        return NoContent();
    }
}