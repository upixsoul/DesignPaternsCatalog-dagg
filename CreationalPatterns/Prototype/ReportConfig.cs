
namespace CreationalPatterns.Prototype
{
    //Interface for the prototype
    public interface IReportConfig : ICloneable
    {
        string Title { get; set; }
        string Format { get; set; }
        Dictionary<string, string> Metadata { get; set; }
        void DisplayConfig();
    }

    //Concrete class that implements the prototype
    public class ReportConfig : IReportConfig
    {
        public string Title { get; set; }
        public string Format { get; set; }
        public Dictionary<string, string> Metadata { get; set; }

        public ReportConfig(string title, string format, Dictionary<string, string> metadata)
        {
            Title = title;
            Format = format;
            Metadata = metadata;
        }

        //Implementation of the Clone method (deep copy to avoid sharing references)
        public object Clone()
        {
            //We make a deep copy to avoid modifying the original.
            var clonedMetadata = new Dictionary<string, string>(Metadata);
            return new ReportConfig(Title, Format, clonedMetadata);
        }

        public void DisplayConfig()
        {
            Console.WriteLine($"Report: {Title}, Format: {Format}");
            Console.WriteLine("Metadata:");
            foreach (var item in Metadata)
            {
                Console.WriteLine($"  {item.Key}: {item.Value}");
            }
        }
    }
}
