using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.testRepo
{
    public class MoviesBLL : IRepo<Movies>
    {
        private readonly DatabaseContext database;

        public MoviesBLL(DatabaseContext database)
        {
            this.database = database;
        }

        public List<Movies> GetAll()
        {
            return database.Movies.Include(x => x.movieGenres).Include(x => x.subMovieGenres).ToList();
        }

        public Movies FindById(int id)
        {
            return database.Movies.Include(x => x.movieGenres).Include(x => x.subMovieGenres).SingleOrDefault(x => x.movieID == id);

        }

        public void Add(Movies movie)
        {
            database.Movies.Add(movie);
            database.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var item = FindById(id);
            database.Movies.Remove(item);
            database.SaveChanges();
        }

        public void Update(Movies movie)
        {
            database.Movies.Update(movie);
            database.SaveChanges();
        }

        public List<Movies> Search(string keyword)
        {
            keyword = keyword.ToLower();

            return database.Movies.Where(x => x.movieName.ToLower().Contains(keyword)).ToList();
        }
    }
}
