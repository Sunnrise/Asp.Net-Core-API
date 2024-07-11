using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiBtk.Models;

namespace WebApiBtk.Repositories.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(

                new Book
                {
                    Id = 1,
                    Title = "Book 1",
                    Price = 100
                },
                new Book
                {
                    Id = 2,
                    Title = "Book 11",
                    Price = 10000
                },
                new Book
                {
                    Id = 3,
                    Title = "Book 10",
                    Price = 1000
                });
        }
    }
}
