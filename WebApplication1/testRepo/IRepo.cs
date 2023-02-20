using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.testRepo
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T FindById(int id);
        void Add(T user);
        void DeleteUser(int id);
        void Update(T user); 
        List<T> Search(string keyword);

    }
}
