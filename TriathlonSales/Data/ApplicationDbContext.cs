using Microsoft.EntityFrameworkCore;
using TriathlonSales.Models;

namespace TriathlonSales.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Countries> Countries { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<SalesOrdersHead> SalesOrdersHead { get; set; }
        public DbSet<SalesOrdersItems> SalesOrdersItems { get; set; }
        public DbSet<CustomerTemporary> CustomerTemporary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }


      


    }
}
