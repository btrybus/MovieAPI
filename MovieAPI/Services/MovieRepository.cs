using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Services
{

    public interface IMovieRepository
    {
        Movie Get(int movieId);
        IEnumerable<Movie> GetAll();
        Movie Post(Movie newMovie);
        Movie Put(Movie updatedMovie);
        Movie Delete(int movieId);
    }


    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext context;

        public MovieRepository(MovieDbContext _context)
        {
            context = _context;
        }

        public Movie Delete(int movieId)
        {
            Movie movie = context.Movies.Find(movieId);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }

        public Movie Get(int movieId)
        {
            return context.Movies.Find(movieId);
        }

        public IEnumerable<Movie> GetAll()
        {
            return context.Movies;
        }

        public Movie Post(Movie newMovie)
        {
            context.Movies.Add(newMovie);
            context.SaveChanges();
            return newMovie;
        }

        public Movie Put(Movie updatedMovie)
        {
            var movie = context.Movies.Attach(updatedMovie);
            movie.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedMovie;
        }

    }
}
