using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(

                new Book
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Book 1",
                    Price = 100
                },
                new Book
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "Book 11",
                    Price = 10000
                },
                new Book
                {
                    Id = 3,
                    CategoryId = 2,
                    Title = "Book 10",
                    Price = 1000
                });
        }
    }
}
