using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
