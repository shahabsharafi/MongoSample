using MongoSample.Infrasructure.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MongoSample.Domain.Models
{
    public class Person : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;   
        public string Family { get; set; } = String.Empty;
        public string GetId() { return Id; }
    }
}
