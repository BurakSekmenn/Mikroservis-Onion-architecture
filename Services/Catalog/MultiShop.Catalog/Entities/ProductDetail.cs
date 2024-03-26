using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail
    {

        [BsonId]// Mango Db bu id olduğunu anlaması için
        [BsonRepresentation(BsonType.ObjectId)] // id'nin ObjectId olduğunu belirtmek için
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }

        public string ProductId { get; set; }
        [BsonIgnore]//MongoDb'ye kaydetme demek
        public Product Product { get; set; }    

    }
}
