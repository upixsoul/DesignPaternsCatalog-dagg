namespace CreationalPatterns.Singleton;

public class Singleton
{
    private static Singleton instance = null;
    public string Id { get; }

    //This is the KEY of the Singleton pattern:
    private Singleton()
    {
        Id = Guid.NewGuid().ToString();
    }

    public static Singleton Instance
    {
        get
        {
            if (instance is null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}