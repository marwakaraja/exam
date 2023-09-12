
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School_management.Models;
using schoolManagement.Models;


namespace School_management.DataAccess
{
    public class MyAppContext : IdentityDbContext

           
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
        }

        public  DbSet<Video> Videos { get; set; }
        public  DbSet<Grade> Courses { get; set; }
        public DbSet<Post> Posts { get; set; }


        }
}
