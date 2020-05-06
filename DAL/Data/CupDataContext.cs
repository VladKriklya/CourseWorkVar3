using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class CupDataContext : DbContext
    {
        public CupDataContext(DbContextOptions<CupDataContext> options) : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
