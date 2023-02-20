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
    public class RoleController : Controller
    {
        private readonly IRepo<Role> db;
        private readonly SessionManager session;

        public RoleController(IRepo<Role> db, SessionManager session)
        {
            this.db = db;
            this.session = session;
        }

        public IActionResult Index()
        {
            if(session.IsAuthenticated && session.Admin)
            {
                var roles = db.GetAll();
                return View(roles);
            }
            else
            {
                return RedirectToAction("AccessDenied","Home");
            }
        }

        public IActionResult Create()
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
        public IActionResult Create(Role role)
        {
            db.Add(role);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (session.IsAuthenticated && session.Admin)
            {
                ViewBag.roledata = db.GetAll();
                var model = db.FindById(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }
        [HttpPost]
        public IActionResult Edit(Role item)
        {
            db.Update(item);
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public IActionResult Deletee(int id)
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
            return RedirectToAction("Index");
        }

    }
}
