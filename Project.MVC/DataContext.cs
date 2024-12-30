using Microsoft.EntityFrameworkCore;
using Project.MVC.Models;

namespace Project.MVC
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Ogrenci> Ogrenciler{ get; set; }
    }
}
