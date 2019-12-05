using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;
using System.Linq;

namespace CRUDelicious.Models {
    public class MyContext : DbContext 
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<Dish> Dishes {get;set;}
    }
}