using Bookstore_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
