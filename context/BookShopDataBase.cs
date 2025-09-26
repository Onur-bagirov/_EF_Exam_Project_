using _EF_Exam_Project_.entities;
using _EF_Exam_Project_.entitiesConfiguration;
using Microsoft.EntityFrameworkCore;
namespace _EF_Exam_Project_.context
{
    public class BookShopDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=WINDOWS_11_ONUR\\MSSQLSERVER01;Initial Catalog=MainDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBook> OrderBook { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderBookConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
