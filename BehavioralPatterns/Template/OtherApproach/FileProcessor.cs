
namespace BehavioralPatterns.Template.OtherApproach
{
    public abstract class FileProcessor
    {
        public void ProcessFile(string filePath)
        {
            LoadFile(filePath);
            if (!ValidateContent())
            {
                Console.WriteLine("Invalid content.");
                return;
            }
            var data = ParseContent();
            SaveData(data);
            CleanUp();
        }

        protected abstract void LoadFile(string filePath);
        protected abstract bool ValidateContent();
        protected abstract List<object> ParseContent();

        protected virtual void SaveData(List<object> data)
        {
            Console.WriteLine($"Saving {data.Count} items to database...");
        }

        protected virtual void CleanUp()
        {
            Console.WriteLine("Cleaning up temporary resources...");
        }
    }

}
