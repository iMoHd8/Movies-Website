using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.testRepo
{
    public class RoleBLL : IRepo<Role>
    {
        private readonly DatabaseContext database;

        public RoleBLL(DatabaseContext database)
        {
            this.database = database;
        }

        public void Add(Role user)
        {
            database.Roles.Add(user);
            database.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var item = FindById(id);
            database.Roles.Remove(item);
            database.SaveChanges();
        }

        public Role FindById(int id)
        {
            return database.Roles.SingleOrDefault(x => x.RoleID == id);
        }

        public List<Role> GetAll()
        {
            return database.Roles.ToList();
        }

        public List<Role> Search(string keyword)
        {
            keyword = keyword.ToLower();

            return database.Roles.Where(x => x.RoleName.ToLower().Contains(keyword)).ToList();
        }

        public void Update(Role role)
        {
            database.Roles.Update(role);
            database.SaveChanges();
        }
    }
}
