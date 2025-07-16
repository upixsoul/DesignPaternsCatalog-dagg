
namespace BehavioralPatterns.Template.OtherApproach
{
    public class JsonFileProcessor : FileProcessor
    {
        private string rawJson;

        protected override void LoadFile(string filePath)
        {
            Console.WriteLine("Loading JSON file...");
            rawJson = System.IO.File.ReadAllText(filePath);
        }

        protected override bool ValidateContent()
        {
            return !string.IsNullOrWhiteSpace(rawJson);
        }

        protected override List<object> ParseContent()
        {
            Console.WriteLine("Parsing JSON...");
            var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(rawJson);
            return items.Cast<object>().ToList();
        }
    }

}
