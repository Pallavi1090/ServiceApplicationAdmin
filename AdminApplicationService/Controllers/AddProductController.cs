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
    public class AddProductController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<AddProductViewModel> addProductCollection;

        public AddProductController()
        {
            dBContext = new MongoDBContext();
            addProductCollection = dBContext.database.GetCollection<AddProductViewModel>("AddProduct");
        }
        // GET: AddProduct
        public ActionResult Index()
        {
            List<AddProductViewModel> AddProductDetails = addProductCollection.AsQueryable<AddProductViewModel>().ToList();
            return View(AddProductDetails);
          
        }

        // GET: AddProduct/Details/5
        public ActionResult Details(string id)
        {
            var AddProductId = new ObjectId(id);
            var AddProduct = addProductCollection.AsQueryable<AddProductViewModel>().SingleOrDefault(x => x.Id == AddProductId);

            return View(AddProduct);         
        }

        // GET: AddProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddProduct/Create
        [HttpPost]
        public ActionResult Create(AddProductViewModel addProduct)
        {
            string fileName = Path.GetFileNameWithoutExtension(addProduct.ImageFile.FileName);
            string imageExtension = Path.GetExtension(addProduct.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + imageExtension;
            addProduct.ImagePath = "~/assets/AddProduct/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/assets/AddProduct/"), fileName);
            addProduct.ImageFile.SaveAs(fileName);
                        
            try
            {

                //var Amount = addProduct.Price;
                //var Gst = addProduct.GST;
                //var GSTtotal = Amount * Gst / 100;
                //var TotalPrice = GSTtotal.ToString();
                                                     
                // TODO: Add insert logic here
                addProductCollection.InsertOne(addProduct);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddProduct/Edit/5
        public ActionResult Edit(string id)
        {
            var AddProductId = new ObjectId(id);
            var AddProduct = addProductCollection.AsQueryable<AddProductViewModel>().SingleOrDefault(x => x.Id == AddProductId);
            return View(AddProduct);
           
        }

        // POST: AddProduct/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AddProductViewModel addProduct)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<AddProductViewModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<AddProductViewModel>.Update
                    .Set("uName", addProduct.Category)
                    .Set("uName", addProduct.ProductName)
                    .Set("uName", addProduct.ProductSpecification)
                    .Set("uName", addProduct.ProductDescription)
                    .Set("uName", addProduct.Price)
                    .Set("uName", addProduct.GST)
                    .Set("uName", addProduct.TotalPrice);                   
                var result = addProductCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddProduct/Delete/5
        public ActionResult Delete(string id)
        {
            var AddProductId = new ObjectId(id);
            var AddProduct = addProductCollection.AsQueryable<AddProductViewModel>().SingleOrDefault(x => x.Id == AddProductId);
            return View(AddProduct);            
        }

        // POST: AddProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, AddProductViewModel addProduct)
        {
            try
            {
                // TODO: Add delete logic here
                addProductCollection.DeleteOne(Builders<AddProductViewModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
