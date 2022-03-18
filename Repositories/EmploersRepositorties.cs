using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Repositories
{
    public class EmploersRepositorties
    {
        private readonly EmployersDbContext EmployersDbContext;
        public EmploersRepositorties(EmployersDbContext employersDb)
        {
            EmployersDbContext = employersDb;
        }

        public async Task Add(Employers user)//берем и добавялем в нашу базу данных пользователя 
        {
            EmployersDbContext.Add(user);
            await EmployersDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entit = EmployersDbContext.Employers.Find(id);
            entit.IsDeleted = true;
            await EmployersDbContext.SaveChangesAsync();
        }

    

        public async Task<IReadOnlyCollection<Employers>> GEt()
        {
            return await EmployersDbContext.Employers.Where(x => x.IsDeleted == false).ToListAsync();

        }

 

        public async Task Ubdate(Employers user)
        {
            var dbUser = await EmployersDbContext.Employers.FirstOrDefaultAsync(x => x.Id == user.Id);
            dbUser.FirstName = user.FirstName;
            dbUser.Email = user.Email;
            dbUser.Company = user.Company;
            dbUser.Age = user.Age;
            dbUser.IsDeleted = user.IsDeleted;
            await EmployersDbContext.SaveChangesAsync();
        }
    }
}
