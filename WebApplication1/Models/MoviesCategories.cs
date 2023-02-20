using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MoviesCategories
    {
        [Key]
        public int categoryID { get; set; }
        public string categoryName { get; set; }

        // Navigation
        public List<Movies> Movies { get; set; }

    }

    public class SubMoviesCategories
    {
        [Key]
        public int subCategoryID { get; set; }
        public string subCategoryName { get; set; }

        // Navigation
        public List<Movies> Movies { get; set; }
    }
}
