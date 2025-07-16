
namespace BehavioralPatterns.Template
{
    public class CodeBasedMigration : DatabaseMigration
    {
        protected override void ConnectToDatabase()
        {
            Console.WriteLine("Connecting to PostgreSQL...");
        }

        protected override void PrepareMigration()
        {
            Console.WriteLine("Preparing EF Core migration steps...");
            // build migration logic
        }

        protected override void ExecuteMigration()
        {
            Console.WriteLine("Applying migration via Entity Framework...");
            // mock EF call
        }
    }

}
