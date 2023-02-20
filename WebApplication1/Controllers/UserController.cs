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
    public class UserController : Controller
    {
        private readonly IRepo<Member> db;
        private readonly IRepo<Role> roleDB;
        private readonly SessionManager session;

        public UserController(IRepo<Member> db, IRepo<Role> roleDB, SessionManager session)
        {
            this.db = db;
            this.roleDB = roleDB;
            this.session = session;
        }

        public IActionResult Index(string keyword=null)
        {
            if(session.IsAuthenticated && session.Admin)
            {
                ViewBag.keyword = keyword;
                if(string.IsNullOrEmpty(keyword))
                {
                    return View(db.GetAll());
                }
                else
                {
                    return View(db.Search(keyword));
                }
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }



        //Add New Users
        public IActionResult Create()
        {
            if (session.IsAuthenticated && session.Admin)
            {
                ViewBag.roledata = roleDB.GetAll();
                return View();
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }
        [HttpPost]
        public IActionResult Create(Member member)
        {
            member.role = roleDB.FindById(member.roleID);

            db.Add(member);
            return RedirectToAction("Index");
        }



        //Show Information
        public IActionResult Details(int id)
        {
            if(session.IsAuthenticated && session.Admin)
            {
                var item = db.FindById(id);
                return View(item);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }
        

        //Delete User
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



        //Edit Informations
        public IActionResult Edit(int id)
        {
            if (session.IsAuthenticated && session.Admin)
            {
                ViewBag.roledata = roleDB.GetAll();
                var model = db.FindById(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Home");
            }
        }
        [HttpPost]
        public IActionResult Edit(Member item)
        {
            db.Update(item);
            return RedirectToAction("Index");
        }

    }
}
