using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Interfaces
{
   public  interface Interface <T>
    {
        bool Add(T entity);
        IEnumerable<T> Get();
        bool Update(T id);
        bool Delete(int id);
    }
}
