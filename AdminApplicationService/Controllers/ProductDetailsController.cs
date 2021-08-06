using AdminApplicationService.App_Start;
using AdminApplicationService.ViewModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApplicationService.Controllers
{
    public class ProductDetailsController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<ProductDetailsViewModel> productCollection;

        public ProductDetailsController()
        {
            dBContext = new MongoDBContext();
            productCollection = dBContext.database.GetCollection<ProductDetailsViewModel>("ProductDetails");
        }

        // GET: ProductDetails
        public ActionResult Index()
        {
            List<ProductDetailsViewModel> ProductDetails = productCollection.AsQueryable<ProductDetailsViewModel>().ToList();
            return View(ProductDetails);
        }

        // GET: ProductDetails/Details/5
        public ActionResult Details(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<ProductDetailsViewModel>().SingleOrDefault(X => X.Id == productId);
            return View(product);
        }

        // GET: ProductDetails/Create
        public ActionResult Create()
        {
            return View(new ProductDetailsViewModel());
        }

        // POST: ProductDetails/Create
        [HttpPost]
        public ActionResult Create(ProductDetailsViewModel product)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string imageExtension = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + imageExtension;
            product.ImagePath = "~/assets/ProductDetails/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/assets/ProductDetails/"), fileName);
            product.ImageFile.SaveAs(fileName);
            try
            {
                // TODO: Add insert logic here
                productCollection.InsertOne(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetails/Edit/5
        public ActionResult Edit(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<ProductDetailsViewModel>().SingleOrDefault(X => X.Id == productId);
            return View(product);          
        }

        // POST: ProductDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ProductDetailsViewModel product)
        {
            try
            {
                var filter = Builders<ProductDetailsViewModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<ProductDetailsViewModel>.Update
                    .Set("ProductName", product.ProductName)
                    .Set("ProductDescription", product.ProductDescription)
                    .Set("ProductPrice", product.ProductPrice)
                    .Set("ProductMRPPrice", product.ProductMRPPrice)
                    .Set("DeliveryCharge", product.DeliveryCharge)
                    .Set("ProductSpecification", product.ProductSpecification)
                    .Set("Brand", product.Brand)
                    .Set("Manufacturer", product.Manufacturer)
                    .Set("ModelName", product.ModelName)
                    .Set("ProductDimentions", product.ProductDimentions)
                    .Set("RAMSize", product.RAMSize)
                    .Set("ProcessorType", product.ProcessorType)
                    .Set("HardwarePlatform", product.HardwarePlatform)
                    .Set("Resolution", product.Resolution)
                    .Set("MountingHardware", product.MountingHardware)
                    .Set("SearchType", product.SearchType);
                var result = productCollection.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetails/Delete/5
        public ActionResult Delete(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<ProductDetailsViewModel>().SingleOrDefault(X => X.Id == productId);
            return View(product);           
        }

        // POST: ProductDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ProductDetailsViewModel product)
        {
            try
            {
                // TODO: Add delete logic here
                productCollection.DeleteOne(Builders<ProductDetailsViewModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }
    }
}
