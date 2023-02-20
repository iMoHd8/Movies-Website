using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.testRepo;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepo<Movies> db;
        private readonly IRepo<MoviesCategories> cateDB;
        private readonly IRepo<SubMoviesCategories> subCatDb;
        private readonly IRepo<Member> userDb;
        private readonly SessionManager session;

        public MovieController(IRepo<Movies> db, IRepo<MoviesCategories> cateDB, IRepo<SubMoviesCategories> subCatDb, IRepo<Member> userDb, SessionManager session)
        {
            this.db = db;
            this.cateDB = cateDB;
            this.subCatDb = subCatDb;
            this.userDb = userDb;
            this.session = session;
        }

        public IActionResult Home(string keyword = null)
        {
            ViewBag.counterUser = userDb.GetAll().Count;
            ViewBag.keyword = keyword;
            if (string.IsNullOrEmpty(keyword))
            {
                return View(db.GetAll());
            }
            else
            {
                return View(db.Search(keyword));
            }
        }

        public IActionResult Create()
        {
            if (session.IsAuthenticated && session.Admin)
            {
                ViewBag.Categories = cateDB.GetAll();
                ViewBag.SubCategories = subCatDb.GetAll();
                return View();
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }
        [HttpPost]
        public IActionResult Create(Movies movie)
        {
            movie.movieGenres = cateDB.FindById(movie.movieCategoryID);
            movie.subMovieGenres = subCatDb.FindById(movie.subMovieCategoryID);

            db.Add(movie);
            return RedirectToAction("Home");
        }


        [ActionName("Delete")]
        public IActionResult DeleteMovie(int id)
        {
            if (session.IsAuthenticated && session.Admin)
            {
                var item = db.FindById(id);
                return View(item);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.DeleteUser(id);
            return RedirectToAction("Home");
        }

        public IActionResult Edit(int id)
        {
            if(session.IsAuthenticated && session.Admin)
            {
                ViewBag.Categories = cateDB.GetAll();
                ViewBag.SubCategories = subCatDb.GetAll();
                var model = db.FindById(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }
        [HttpPost]
        public IActionResult Edit(Movies item)
        {
            db.Update(item);
            return RedirectToAction("Home");
        }

        public IActionResult MovieDetails(int id)
        {
            if (session.IsAuthenticated)
            {
                var movieDetails = db.FindById(id);
                return View(movieDetails);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

    }
}
