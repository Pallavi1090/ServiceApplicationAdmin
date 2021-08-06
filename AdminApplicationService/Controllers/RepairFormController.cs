using AdminApplicationService.App_Start;
using AdminApplicationService.ViewModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApplicationService.Controllers
{
    public class RepairFormController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<RepairformViewModel> repairCollection;

        public RepairFormController()
        {
            dBContext = new MongoDBContext();
            repairCollection = dBContext.database.GetCollection<RepairformViewModel>("Repairform");
        }
        // GET: RepairForm
        public ActionResult Index()
        {
            List<RepairformViewModel> RepairformDetails = repairCollection.AsQueryable<RepairformViewModel>().ToList();
            return View(RepairformDetails);
        }
        public ActionResult Report()
         {
            var viewModel = new Dashboard();
            dBContext = new MongoDBContext();
            var data = repairCollection.AsQueryable<RepairformViewModel>().ToList();
            var dataCompleted = repairCollection.Find(x => x.OrderStatus == "Completed").ToList();
            var dataNewOrder = repairCollection.Find(x => x.OrderStatus == "New Order").ToList();
            var dataPending = repairCollection.Find(x => x.OrderStatus == "Pending").ToList();
            var dataOnGoing = repairCollection.Find(x => x.OrderStatus == "On Going").ToList();
            var dataDelvery = repairCollection.Find(x => x.OrderStatus == "Delivery").ToList();

            viewModel.data = data;
            viewModel.dataCompleted = dataCompleted;
            viewModel.dataNewOrder = dataNewOrder;
            viewModel.dataPending = dataPending;
            viewModel.dataOnGoing = dataOnGoing;
            viewModel.dataDelivery = dataDelvery;
            return View(viewModel);
        }

        // GET: RepairForm/Details/5
        public ActionResult Details(string id)
        {
            var repairId = new ObjectId(id);
            var repairform = repairCollection.AsQueryable<RepairformViewModel>().SingleOrDefault(x => x.Id == repairId);

            return View(repairform);
        }

        // GET: RepairForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairForm/Create
        [HttpPost]
        public ActionResult Create(RepairformViewModel repairform)
        {
            try
            {
                // TODO: Add insert logic here
                repairCollection.InsertOne(repairform);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RepairForm/Edit/5
        public ActionResult Edit(string id)
        {
            var repairId = new ObjectId(id);
            var repairform = repairCollection.AsQueryable<RepairformViewModel>().SingleOrDefault(x => x.Id == repairId);
            return View(repairform);
        }

        // POST: RepairForm/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, RepairformViewModel repairform)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<RepairformViewModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<RepairformViewModel>.Update
                    .Set("uName", repairform.uName)
                    .Set("uNumber", repairform.uNumber)
                    .Set("uAlterNumber", repairform.uAlterNumber)
                    .Set("uMail", repairform.uMail)
                    .Set("PickUpTime", repairform.PickUpTime)
                    .Set("PickUpDate", repairform.PickUpDate)
                    .Set("deliverDate", repairform.deliverDate)
                    .Set("deliverAddres", repairform.deliverAddres)
                    .Set("ImagePath", repairform.ImagePath)
                    .Set("pType", repairform.pType)
                    .Set("pName", repairform.pName)
                    .Set("pDescription", repairform.pDescription)
                    .Set("pPrice", repairform.pPrice)
                    .Set("pMrpPrice", repairform.pMrpPrice)
                    .Set("delivercharge", repairform.delivercharge)
                    .Set("pOffers", repairform.pOffers)
                    .Set("pSpecifications", repairform.pSpecifications)
                    .Set("orderType", repairform.orderType)
                    .Set("OrderStatus", repairform.OrderStatus)
                    .Set("orderDate", repairform.orderDate);
                var result = repairCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RepairForm/Delete/5
        public ActionResult Delete(string id)
        {
            var repairId = new ObjectId(id);
            var repairform = repairCollection.AsQueryable<RepairformViewModel>().SingleOrDefault(x => x.Id == repairId);
            return View(repairform);
        }

        // POST: RepairForm/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, RepairformViewModel repairform)
        {
            try
            {
                // TODO: Add delete logic here
                repairCollection.DeleteOne(Builders<RepairformViewModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(repairform);
            }
        }
    }
}
