namespace MovieApi.Services;

using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;

public interface IMovieService
{
    List<Movie> GetAll();
    Movie? GetById(int id);
    Movie Create(Movie movie);
    bool Update(int id, Movie updated);
    bool Delete(int id);
}

public class MovieService : IMovieService
{
    private readonly AppDbContext _context;

    public MovieService(AppDbContext context)
    {
        _context = context;
    }

    public List<Movie> GetAll() => _context.Movies.ToList();

    public Movie? GetById(int id) =>
        _context.Movies.FirstOrDefault(m => m.Id == id);

    public Movie Create(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return movie;
    }

    public bool Update(int id, Movie updated)
    {
        var movie = GetById(id);
        if (movie is null) return false;

        movie.Title = updated.Title;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var movie = GetById(id);
        if (movie is null) return false;

        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return true;
    }
}