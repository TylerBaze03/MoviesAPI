namespace MoviesAPI.Models
{
    public class MovieDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string MovieCollectionName { get; set; } = null!;

    }
}
