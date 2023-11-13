using Microsoft.EntityFrameworkCore;
using MIS3033_LC_1108_BenReilly.Models;

namespace MIS3033_LC_1108_BenReilly.Data
{
    public class StuDB : DbContext// Change DbCon to your own database connect class name
    {
        public DbSet<Student> Students { get; set; }// Define a table in the database. The table name here is: Students
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=129.15.67.240;Database=reil00081108;Port=5432;Username=reil0008;Password=Go1QeQQJWroftQbm7jUU");
            // start your database name with netid
        }
    }
}
