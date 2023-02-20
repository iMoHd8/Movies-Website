using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.testRepo
{
    public class SubCategoriesBLL : IRepo<SubMoviesCategories>
    {
        private readonly DatabaseContext database;

        //List<SubMoviesCategories> categories;
        //static int counter;

        public SubCategoriesBLL(DatabaseContext database)
        {
            this.database = database;
            //categories = new List<SubMoviesCategories>()
            //{
            //    new SubMoviesCategories() { subCategoryID = 1, subCategoryName = "Action" },
            //    new SubMoviesCategories() { subCategoryID = 2, subCategoryName = "Drama" },
            //    new SubMoviesCategories() { subCategoryID = 3, subCategoryName = "Horror" },
            //    new SubMoviesCategories() { subCategoryID = 4, subCategoryName = "Sci-Fi" },
            //    new SubMoviesCategories() { subCategoryID = 5, subCategoryName = "Fantasy" },
            //    new SubMoviesCategories() { subCategoryID = 6, subCategoryName = "Romance" },
            //    new SubMoviesCategories() { subCategoryID = 7, subCategoryName = "Thriller" },
            //    new SubMoviesCategories() { subCategoryID = 6, subCategoryName = "Comedy" },
            //    new SubMoviesCategories() { subCategoryID = 6, subCategoryName = "Western" }
            //};
            //counter = categories.Count;
        }


        public void Add(SubMoviesCategories category)
        {
            //category.subCategoryID = ++counter;
            database.SubCategories.Add(category);
            database.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var item = FindById(id);
            database.SubCategories.Remove(item);
            database.SaveChanges();
        }

        public SubMoviesCategories FindById(int id)
        {
            return database.SubCategories.SingleOrDefault(x => x.subCategoryID == id);
        }

        public List<SubMoviesCategories> GetAll()
        {
            return database.SubCategories.ToList(); ;
        }

        public List<SubMoviesCategories> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public void Update(SubMoviesCategories category)
        {
            database.SubCategories.Update(category);
            database.SaveChanges();
        }
    }
}
