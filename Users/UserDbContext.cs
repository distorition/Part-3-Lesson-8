using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public sealed  class UserDbContext:DbContext
    {
        /// <summary>
        /// реализованна подключения к бае данных
        /// </summary>
        /// <param name="options"></param>
        public UserDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(x => x.Age);
        }

    }
}
