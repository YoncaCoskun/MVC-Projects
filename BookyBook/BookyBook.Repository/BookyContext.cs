using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookyBook.Entity;

namespace BookyBook.Repository
{
    public class BookyContext: DbContext
    {
        public BookyContext(): base("BookyContext")
        {

Database.SetInitializer(
new MigrateDatabaseToLatestVersion<BookyContext,BookyConfiguration>()
);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<RentTransaction> RentTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
} 
