using Mc2.CrudTest.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Shared.Data
{
    public class CrudTestContext : DbContext
    {
        public CrudTestContext(DbContextOptions<CrudTestContext> options) : base(options) 
        {
        
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
