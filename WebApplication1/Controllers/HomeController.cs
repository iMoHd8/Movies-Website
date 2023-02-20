using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.testRepo;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext db;
        private readonly SessionManager session;

        public HomeController(DatabaseContext db, SessionManager session)
        {
            this.db = db;
            this.session = session;
        }


        [Route("Login")]
        public IActionResult Login()
        {

            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            var user = db.Members.SingleOrDefault(x => x.email == login.email && x.password == login.password);
            if (ModelState.IsValid)
            {
                if (user is null)
                {
                    ModelState.AddModelError("email", "Email or Password is not Right");
                    return View();
                }

                session.Email = login.email;

                if (user.roleID == 1)
                {
                    session.Admin = true;
                }
                else
                {
                    session.User = true;
                }

                return RedirectToAction("Home", "Movie");
                
            }
            else
            {
                return View();
            }

        }



        [Route("Register")]
        public IActionResult Register()
        {
            
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(RegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                if (db.Members.Any(x => x.email == user.email))
                {
                    ModelState.AddModelError("email", "This Email is Already Exist, Try To Login");
                    return View();
                }

            
                db.Members.Add(new Member
                {
                    name = user.userName,
                    password = user.password,
                    email = user.email,
                    roleID = 2
                    
                });

            
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            session.Clear();

            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult ProjectMembers()
        {
            return View();
        }
    }
}
