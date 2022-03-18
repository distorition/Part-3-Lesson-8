using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Controllers.Interfaces
{
 public    interface IUserServices
    {
       public REsponseToken Authentication(string user, string password);
        string REfreshToken(string token);
    }
}
