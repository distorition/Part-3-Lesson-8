using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Interfaces
{
   public interface IUserRepositories
    {
        bool  Add(User user);
        IEnumerable<User> GEt();
        bool Ubdate(User user);
        bool Delete(int id);
    }
}
