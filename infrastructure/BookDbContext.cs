using Microsoft.EntityFrameworkCore;

namespace dotnetcoreWebAPI.infrastructure
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options ) : base( options )
        {

        }

        public DbSet<models.Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
