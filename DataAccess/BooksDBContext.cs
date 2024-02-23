using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BooksDBContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    public BooksDBContext(DbContextOptions options) : base(options)
    {
        
    }

}