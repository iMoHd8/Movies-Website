using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Movies
    {
        [Key]
        public int movieID { get; set; }
        public string movieName { get; set; }
        public string moviePoster { get; set; }
        public float movieRating { get; set; }
        public DateTime movieReleaseDate { get; set; }


        [ForeignKey(nameof(movieGenres))]
        public int movieCategoryID { get; set; }
        public MoviesCategories movieGenres { get; set; }


        [ForeignKey(nameof(subMovieGenres))]
        public int subMovieCategoryID { get; set; }
        public SubMoviesCategories subMovieGenres { get; set; }


        public MoviesGuide movieGuide { get; set; }
        public string movieTrailer { get; set; }
        public string movieStory { get; set; }

    }
}
