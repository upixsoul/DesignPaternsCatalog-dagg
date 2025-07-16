
namespace BehavioralPatterns.Template.OtherApproach
{
    public class CsvFileProcessor : FileProcessor
    {
        private List<string> lines;

        protected override void LoadFile(string filePath)
        {
            Console.WriteLine("Loading CSV file...");
            lines = System.IO.File.ReadAllLines(filePath).ToList();
        }

        protected override bool ValidateContent()
        {
            return lines != null && lines.Any();
        }

        protected override List<object> ParseContent()
        {
            Console.WriteLine("Parsing CSV content...");
            return lines.Select(line => (object)line.Split(',')).ToList();
        }
    }

}
