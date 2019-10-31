namespace FarmStore3
{
    public class FarmStoreConfiguration
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public string ConectionString { get; set; }
    }
}
