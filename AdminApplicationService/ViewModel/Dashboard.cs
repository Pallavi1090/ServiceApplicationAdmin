using AdminApplicationService.App_Start;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminApplicationService.ViewModel
{
    //private MongoDBContext DbContext;

    //private IMongoCollection<RepairformViewModel> repairCollection;
       
    public class Dashboard
    {
        public List<RepairformViewModel> dataCompleted { get; set; }
        public List<RepairformViewModel> dataOnGoing { get; set; }
        public List<RepairformViewModel> dataNewOrder { get; set; }
        public List<RepairformViewModel> dataPending { get; set; }
        public List<RepairformViewModel> data { get; set; }
        public List<RepairformViewModel> dataDelivery { get; set; }
    }
}