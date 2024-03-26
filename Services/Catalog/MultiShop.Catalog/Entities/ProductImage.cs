using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]// Mango Db bu id olduğunu anlaması için
        [BsonRepresentation(BsonType.ObjectId)] // id'nin ObjectId olduğunu belirtmek için
        public string ProductImageId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public string ProductId { get; set; }
        [BsonIgnore]//MongoDb'ye kaydetme demek
        public Product Product { get; set; }
    }
}
