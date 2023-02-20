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
    public class CategoriesController : Controller
    {
        private readonly IRepo<MoviesCategories> db;
        private readonly IRepo<SubMoviesCategories> subDB;
        private readonly SessionManager session;

        public CategoriesController(IRepo<MoviesCategories> db, IRepo<SubMoviesCategories> subDB, SessionManager session)
        {
            this.db = db;
            this.subDB = subDB;
            this.session = session;
        }


        public IActionResult CategoriesHome()
        {
            if (session.IsAuthenticated && session.Admin)
            {
                var item = db.GetAll();
                var item2 = subDB.GetAll();
                return View(item);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }

        public IActionResult SubCategoriesHome()
        {
            if (session.IsAuthenticated && session.Admin)
            {
                var item = subDB.GetAll();
                return View(item);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }

        public IActionResult AddCategory()
        {
            if (session.IsAuthenticated && session.Admin)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult AddCategory(MoviesCategories category)
        {
            db.Add(category);
            return RedirectToAction("CategoriesHome");
        }



        public IActionResult AddSubCategory()
        {
            if (session.IsAuthenticated && session.Admin)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult AddSubCategory(SubMoviesCategories category)
        {
            subDB.Add(category);
            return RedirectToAction("SubCategoriesHome");
        }



        public IActionResult CategoryEdit(int id)
        {
            if (session.IsAuthenticated && session.Admin)
            {
                ViewBag.category = db.GetAll();
                var model = db.FindById(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult CategoryEdit(MoviesCategories item)
        {
            db.Update(item);
            return RedirectToAction("CategoriesHome");
        }


        public IActionResult SubCategoryEdit(int id)
        {
            if (session.IsAuthenticated && session.Admin)
            {
                ViewBag.category = subDB.GetAll();
                var model = subDB.FindById(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult SubCategoryEdit(SubMoviesCategories item)
        {
            subDB.Update(item);
            return RedirectToAction("SubCategoriesHome");
        }


        [ActionName("CategoryDelete")]
        public IActionResult CategoryDeletee(int id)
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
        public IActionResult CategoryDelete(int id)
        {
            db.DeleteUser(id);
            return RedirectToAction("CategoriesHome");
        }



        [ActionName("SubCategoryDelete")]
        public IActionResult SubCategoryDeletee(int id)
        {
            if (session.IsAuthenticated && session.Admin)
            {
                var item = subDB.FindById(id);
                return View(item);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult SubCategoryDelete(int id)
        {
            subDB.DeleteUser(id);
            return RedirectToAction("SubCategoriesHome");
        }

    }
}
