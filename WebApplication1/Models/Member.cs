using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Member
    {
        [Key]
        public int userId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }


        [ForeignKey(nameof(role))]
        public int roleID { get; set; }

        public Role role { get; set; }

    }
}
