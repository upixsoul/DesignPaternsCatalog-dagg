
namespace BehavioralPatterns.Template
{
    public abstract class DatabaseMigration
    {
        public void RunMigration()
        {
            ConnectToDatabase();
            PrepareMigration();
            ExecuteMigration();
            LogResults();
            Disconnect();
        }

        protected abstract void ConnectToDatabase();
        protected abstract void PrepareMigration();
        protected abstract void ExecuteMigration();
        protected virtual void LogResults()
        {
            Console.WriteLine("Logging migration results...");
        }
        protected virtual void Disconnect()
        {
            Console.WriteLine("Disconnecting from database.");
        }
    }

}
