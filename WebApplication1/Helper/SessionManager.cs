using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Helper
{
    public class SessionManager
    {
        readonly ISession _Session;
        private readonly IHttpContextAccessor accessor;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _Session = accessor.HttpContext.Session;
            this.accessor = accessor;
        }

        public bool IsAuthenticated
        {
            get
            {
                return _Session.GetString("email") != null;
            }
        }

        public string Email
        {
            get
            {
                return _Session.GetString("email");
            }
            set
            {
                _Session.SetString("email", value);
            }
        }

        public bool Admin
        {
            get
            {
                bool.TryParse(_Session.GetString("Admin"), out bool Admin);
                return Admin;
            }

            set
            {
                 _Session.SetString("Admin", value.ToString());
            }
        }

        public bool User
        {
            get
            {
                bool.TryParse(_Session.GetString("User"), out bool User);
                return User;
            }

            set
            {
                _Session.SetString("User", value.ToString());
            }
        }

        public void Clear()
        {
            _Session.Clear();
        }
    }
}
