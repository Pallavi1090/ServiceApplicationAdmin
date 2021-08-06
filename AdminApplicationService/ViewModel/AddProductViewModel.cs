using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApplicationService.ViewModel
{
    public class AddProductViewModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("ProductSpecification")]
        public string ProductSpecification { get; set; }
        [BsonElement("ProductDescription")]
        public string ProductDescription { get; set; }       

       
       
        [BsonElement("Price")]
        public string Price { get; set; }
        [BsonElement("Quantity")]
        public string Quantity { get; set; }
        [BsonElement("GST")]
        public string GST { get; set; }
        [BsonElement("TotalPrice")]
        public string TotalPrice { get; set; }
        
    }
}