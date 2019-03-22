using Microsoft.EntityFrameworkCore;
 
namespace exam.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> users {get;set;}
        public DbSet<Activityclass> activities {get;set;}
        public DbSet<RSVP> rsvps {get;set;}
    }
}