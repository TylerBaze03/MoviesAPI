using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;


namespace MoviesAPI.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }


        [BsonSerializer(typeof(DateOnlySerializer))]
        public DateOnly Date { get; set; }
        public string Name { get; set; } = null!;

        public List<string>? Actors { get; set; } = null!;

        public string Director { get; set; } = null!;
    }
}
