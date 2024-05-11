using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibolity.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-U9RQD8E8;initial Catalog=ChainOfDb2; integrated security =true");
        }
        public DbSet<CustomerProcesses> CustumerProcesses { get; set; }
    }
}
