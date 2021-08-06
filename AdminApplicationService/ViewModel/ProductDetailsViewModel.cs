using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApplicationService.ViewModel
{
    public class ProductDetailsViewModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("ProductDescription")]
        public string ProductDescription { get; set; }
        [BsonElement("ProductPrice")]
        public string ProductPrice { get; set; }
        [BsonElement("ProductMRPPrice")]
        public string ProductMRPPrice { get; set; }
        [BsonElement("DeliveryCharge")]
        public string DeliveryCharge { get; set; }
        [BsonElement("ProductSpecification")]
        public string ProductSpecification { get; set; }
        [BsonElement("Brand")]
        public string Brand { get; set; }
        [BsonElement("Manufacturer")]
        public string Manufacturer { get; set; }
        [BsonElement("ModelName")]
        public string ModelName { get; set; }
        [BsonElement("ProductDimentions")]
        public string ProductDimentions { get; set; }
        [BsonElement("RAMSize")]
        public string RAMSize { get; set; }
        [BsonElement("ProcessorType")]
        public string ProcessorType { get; set; }
        [BsonElement("HardwarePlatform")]
        public string HardwarePlatform { get; set; }
        [BsonElement("Resolution")]
        public string Resolution { get; set; }
        [BsonElement("MountingHardware")]
        public string MountingHardware { get; set; }
        [BsonElement("Banner")]
        public string Banner { get; set; }
        [BsonElement("BestOffer")]
        public string BestOffer { get; set; }
        [BsonElement("SearchType")]
        public string SearchType { get; set; }
    }
}