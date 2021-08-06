using AdminApplicationService.App_Start;
using AdminApplicationService.ViewModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApplicationService.Controllers
{
    public class DashboardController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<RepairformViewModel> repairCollection;

        public DashboardController()
        {
            dBContext = new MongoDBContext();
            repairCollection = dBContext.database.GetCollection<RepairformViewModel>("Repairform");
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            var viewModel = new Dashboard();
            dBContext = new MongoDBContext();

            var dataCompleted = repairCollection.Find(x => x.OrderStatus == "Completed").ToList();
            var dataNewOrder = repairCollection.Find(x => x.OrderStatus == "New Order").ToList();
            var dataPending = repairCollection.Find(x => x.OrderStatus == "Pending").ToList();
            var dataOnGoing = repairCollection.Find(x => x.OrderStatus == "On Going").ToList();
            var dataDelivery = repairCollection.Find(x => x.OrderStatus == "Delivery").ToList();


            viewModel.dataCompleted = dataCompleted;
            viewModel.dataNewOrder = dataNewOrder;
            viewModel.dataPending = dataPending;
            viewModel.dataOnGoing = dataOnGoing;
            viewModel.dataDelivery = dataDelivery;

            return View(viewModel);

        }
    
    [HttpPost]
    public ActionResult Index(Dashboard viewModel)
    {
            viewModel = new Dashboard();
            dBContext = new MongoDBContext();

            var dataCompleted = repairCollection.Find(x => x.OrderStatus == "Completed").ToList();
            var dataNewOrder = repairCollection.Find(x => x.OrderStatus == "New Order").ToList();
            var dataPending = repairCollection.Find(x => x.OrderStatus == "Pending").ToList();
            var dataOnGoing = repairCollection.Find(x => x.OrderStatus == "On Going").ToList();


            viewModel.dataCompleted = dataCompleted;
            viewModel.dataNewOrder = dataNewOrder;
            viewModel.dataPending = dataPending;
            viewModel.dataOnGoing = dataOnGoing;
            return View("Index", viewModel);
    }
}

}
