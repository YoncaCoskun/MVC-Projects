using System.Data.Entity.Migrations;

namespace BookyBook.Repository
{
   public class BookyConfiguration : DbMigrationsConfiguration<BookyContext>
    {
       public BookyConfiguration()
       {
           AutomaticMigrationsEnabled = true;
           //AutomaticMigrationDataLossAllowed = true;
       }
    }
}
