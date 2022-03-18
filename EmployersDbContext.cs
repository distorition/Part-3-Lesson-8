
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4
{
    public class EmployersDbContext:DbContext
    {
        public EmployersDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employers> Employers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(x => x.Age);
        }
    }
}
