using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Api.Entities
{
    public class Product
    {
        // BsonId Is needed for the Mongo DB
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // BsonElement - You can overwrite the element name
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Category { get; set; }
        
        public string Summary { get; set; }
        
        public string Description { get; set; }
        
        public string ImageFile { get; set; }
        
        public decimal Price { get; set; }
    }
}