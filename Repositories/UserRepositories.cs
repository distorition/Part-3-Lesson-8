using Microsoft.EntityFrameworkCore;
using Part_3_Lesson_4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Repositories
{
    public class UserRepositories 
    {
        private readonly UserDbContext userDbContext;
        public UserRepositories(UserDbContext userDb)
        {
            userDbContext = userDb;
        }
        public async Task Add(User user)//берем и добавялем в нашу базу данных пользователя 
        {
            userDbContext.Add(user);
            await userDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entit = userDbContext.Users.Find(id);
            entit.IsDeleted = true;
            await userDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> GEt()
        {
            return await userDbContext.Users.Where(x => x.IsDeleted == false).ToListAsync();
            
        }

        public async Task Ubdate(User user)
        {
            var dbUser = await userDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            dbUser.FirstName = user.FirstName;
            dbUser.Email = user.Email;
            dbUser.Company = user.Company;
            dbUser.Age = user.Age;
           dbUser.IsDeleted= user.IsDeleted ;
            await userDbContext.SaveChangesAsync();
        }

    }
}
