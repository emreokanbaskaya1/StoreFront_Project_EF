using Microsoft.EntityFrameworkCore;
using StoreFront.Entities;

namespace StoreFront.Context
{
    public class StoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLOCALDB; initial Catalog=StoreFlowDb; Integrated Security=true; trust server certificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }



}

