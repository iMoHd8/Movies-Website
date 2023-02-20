using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        // Navigation

        public List<Member> Members { get; set; }

    }
}
