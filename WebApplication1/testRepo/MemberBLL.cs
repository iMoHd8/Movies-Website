using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.testRepo
{
    public class MemberBLL:IRepo<Member>
    {
        private readonly DatabaseContext database;

        public MemberBLL(DatabaseContext database)
        {
            this.database = database;
        }

        public List<Member> GetAll()
        {
            return database.Members.Include(x => x.role).ToList();
        }

        public Member FindById(int id)
        {
            return database.Members.SingleOrDefault(x=>x.userId == id);
        }

        public void Add(Member user)
        {
            database.Members.Add(user);
            database.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var item = FindById(id);
            database.Members.Remove(item);
            database.SaveChanges();
        }

        public void Update(Member user)
        {
            database.Members.Update(user);
            database.SaveChanges();
        }

        public List<Member> Search(string keyword)
        {
            keyword = keyword.ToLower();

            return database.Members.Where(x => x.name.ToLower().Contains(keyword) || x.email.ToLower().Contains(keyword)).ToList();
        }
    }
}
