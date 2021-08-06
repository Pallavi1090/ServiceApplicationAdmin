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
    public class BannerController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<BannerViewModel> BannerCollection;

        public BannerController()
        {
            dBContext = new MongoDBContext();
            BannerCollection = dBContext.database.GetCollection<BannerViewModel>("Banner");
        }
        // GET: Banner
        public ActionResult Index()
        {
            List<BannerViewModel> BannerDetails = BannerCollection.AsQueryable<BannerViewModel>().ToList();
            return View(BannerDetails);
        }

        // GET: Banner/Details/5
        public ActionResult Details(string id)
        {
            var BannerId = new ObjectId(id);
            var Banner = BannerCollection.AsQueryable<BannerViewModel>().SingleOrDefault(x => x.Id == BannerId);            
            return View(Banner);
        }

        // GET: Banner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        [HttpPost]
        public ActionResult Create(BannerViewModel banner)
        {
            string fileName = Path.GetFileNameWithoutExtension(banner.ImageFile.FileName);
            string imageExtension = Path.GetExtension(banner.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + imageExtension;
            banner.ImagePath = "~/assets/Banner/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/assets/Banner/"), fileName);
            banner.ImageFile.SaveAs(fileName);
            try
            {
                // TODO: Add insert logic here
                BannerCollection.InsertOne(banner);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banner/Edit/5
        public ActionResult Edit(string id)
        {
            var BannerId = new ObjectId(id);
            var Banner = BannerCollection.AsQueryable<BannerViewModel>().SingleOrDefault(x => x.Id == BannerId);
            return View(Banner);
           
        }

        // POST: Banner/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, BannerViewModel banner)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<BannerViewModel>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<BannerViewModel>.Update
                    .Set("uName", banner.ImagePath)
                    .Set("uName", banner.ImageFile);
                   
                var result = BannerCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banner/Delete/5
        public ActionResult Delete(string id)
        {
            var BannerId = new ObjectId(id);
            var Banner = BannerCollection.AsQueryable<BannerViewModel>().SingleOrDefault(x => x.Id == BannerId);
            return View(Banner);
           
        }

        // POST: Banner/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, BannerViewModel banner)
        {
            try
            {
                // TODO: Add delete logic here
                BannerCollection.DeleteOne(Builders<BannerViewModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
