namespace MovieApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Services;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesController(IMovieService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _service.GetById(id);
        if (movie is null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        var created = _service.Create(movie);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Movie updated)
    {
        var success = _service.Update(id, updated);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _service.Delete(id);
        if (!success) return NotFound();
        return NoContent();
    }
}