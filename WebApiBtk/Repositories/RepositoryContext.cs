using Microsoft.EntityFrameworkCore;
using WebApiBtk.Models;

namespace WebApiBtk.Repositories
{


    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        { 
        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.BookConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
