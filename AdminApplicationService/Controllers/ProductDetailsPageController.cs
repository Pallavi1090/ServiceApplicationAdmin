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
    public class ProductDetailsPageController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<ProductDetailsViewModel> productCollection;

        public ProductDetailsPageController()
        {
            dBContext = new MongoDBContext();
            productCollection = dBContext.database.GetCollection<ProductDetailsViewModel>("ProductDetails");
        }
        // GET: ProductDetailsPage
        public ActionResult Index()
        {
            var viewModel = new Product_DetailsPage();
            dBContext = new MongoDBContext();
            
                var ProductPage =productCollection.AsQueryable<ProductDetailsViewModel>().ToList();           
                


                viewModel.ProductPage = ProductPage;                

                return View(viewModel);
            

        }
    [HttpPost]
    public ActionResult Index(Product_DetailsPage viewModel)
    {
        viewModel = new Product_DetailsPage();
        dBContext = new MongoDBContext();

        var ProductPage = productCollection.AsQueryable<ProductDetailsViewModel>().ToList();



        viewModel.ProductPage = ProductPage;



        return View("Index", viewModel);
    }
  }

}
