using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.testRepo
{
    public class CategoriesBLL : IRepo<MoviesCategories>
    {
        private readonly DatabaseContext database;

        public CategoriesBLL(DatabaseContext database)
        {
            this.database = database;
            
        }


        public void Add(MoviesCategories category)
        {

            database.Categories.Add(category);
            database.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var item = FindById(id);
            database.Categories.Remove(item);
            database.SaveChanges();
        }

        public MoviesCategories FindById(int id)
        {
            return database.Categories.SingleOrDefault(x => x.categoryID == id);
        }

        public List<MoviesCategories> GetAll()
        {
            return database.Categories.ToList();
        }

        public List<MoviesCategories> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public void Update(MoviesCategories category)
        {
            database.Categories.Update(category);
            database.SaveChanges();
        }
    }
}
