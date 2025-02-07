using CollegeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
       public DbSet<Student> Students { get; set; }
    }
}
