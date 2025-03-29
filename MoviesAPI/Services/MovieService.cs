using MoviesAPI.Controllers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MoviesAPI.Models;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> _movieCollection;

        public MovieService( IOptions<MovieDatabaseSettings> MovieDatabaseSettings)
        {
            var mongoClient = new MongoClient(MovieDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(MovieDatabaseSettings.Value.DatabaseName);

            _movieCollection = mongoDatabase.GetCollection<Movie>(MovieDatabaseSettings.Value.DatabaseName);
        }
        public async Task<List<Movie>> GetAsync() => await _movieCollection.Find(_=>true).ToListAsync();

        public async Task<Movie> GetAsync(string id) => await _movieCollection.Find(x =>x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Movie newMovie) => await _movieCollection.InsertOneAsync(newMovie);

        public async Task UpdateAsync(string id, Movie updatedMovie) => await _movieCollection.ReplaceOneAsync(x => x.Id == id, updatedMovie);

        public async Task RemoveAsync(string id) => await _movieCollection.DeleteOneAsync(x => x.Id == id);

    }
}
