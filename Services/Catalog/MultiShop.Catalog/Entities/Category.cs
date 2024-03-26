using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]// Mango Db bu id olduğunu anlaması için
        [BsonRepresentation(BsonType.ObjectId)] // id'nin ObjectId olduğunu belirtmek için
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
