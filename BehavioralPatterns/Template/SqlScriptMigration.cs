
namespace BehavioralPatterns.Template
{
    public class SqlScriptMigration : DatabaseMigration
    {
        protected override void ConnectToDatabase()
        {
            Console.WriteLine("Connecting to SQL Server...");
        }

        protected override void PrepareMigration()
        {
            Console.WriteLine("Reading SQL script from file...");
            // read from file logic here
        }

        protected override void ExecuteMigration()
        {
            Console.WriteLine("Executing SQL script...");
            // mock execution
        }
    }

}
