using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminApplicationService.ViewModel
{
    public class RepairformViewModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("uName")]
        public string uName { get; set; }
        [BsonElement("uNumber")]
        public string uNumber { get; set; }
        [BsonElement("uAlterNumber")]
        public string uAlterNumber { get; set; }
        [BsonElement("uMail")]
        public string uMail { get; set; }
        [BsonElement("PickUpTime")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "PickUp Time")]
        public DateTime PickUpTime { get; set; }
        [BsonElement("PickUpDate")]
        public DateTime PickUpDate { get; set; }
        [BsonElement("deliverDate")]
        public DateTime deliverDate { get; set; }
        [BsonElement("deliverAddres")]
        public string deliverAddres { get; set; }
        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [BsonElement("pType")]
        public string pType { get; set; }
        [BsonElement("pName")]
        public string pName { get; set; }
        [BsonElement("pDescription")]
        public string pDescription { get; set; }
        [BsonElement("pPrice")]
        public string pPrice { get; set; }
        [BsonElement("pMrpPrice")]
        public string pMrpPrice { get; set; }
        [BsonElement("delivercharge")]
        public string delivercharge { get; set; }
        [BsonElement("pOffers")]
        public string pOffers { get; set; }
        [BsonElement("pSpecifications")]
        public string pSpecifications { get; set; }
        [BsonElement("orderType")]
        public string orderType { get; set; }
        [BsonElement("OrderStatus")]
        public string OrderStatus { get; set; }
        [BsonElement("orderDate")]
        public DateTime orderDate { get; set; }

    }
}