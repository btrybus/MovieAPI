using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Services
{
    public interface IDirectorRepository
    {
        Director Get(int directorId);
        IEnumerable<Director> GetAll();
        Director Post(Director newDirector);
        Director Put(Director updatedDirector);
        Director Delete(int directorId);
    }

    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieDbContext context;

        public DirectorRepository(MovieDbContext _context)
        {
            context = _context;
        }

        public Director Delete(int directorId)
        {
            Director director = context.Directors.Find(directorId);
            if (director != null)
            {
                context.Directors.Remove(director);
                context.SaveChanges();
            }
            return director;
        }

        public Director Get(int directorId)
        {
            return context.Directors.Find(directorId);
        }

        public IEnumerable<Director> GetAll()
        {
            return context.Directors;
        }

        public Director Post(Director newDirector)
        {
            context.Directors.Add(newDirector);
            context.SaveChanges();
            return newDirector;
        }

        public Director Put(Director updatedDirector)
        {
            var director = context.Directors.Attach(updatedDirector);
            director.State = Microsoft
                               .EntityFrameworkCore
                               .EntityState
                               .Modified;
            context.SaveChanges();
            return updatedDirector;
        }

    }
}
