using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCityEF.Controllers
{
    public class CityController : Controller
    {
        private DB_CityContext context = new DB_CityContext();
        // GET: City
        public ActionResult Index()
        {
            var cityList = context.tbl_cities.ToList();

            return View(cityList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_cities city)
        {
            context.tbl_cities.Add(city);
            context.SaveChanges();
            ViewBag.Message = "City Added successfully";
            return RedirectToAction("Index");
         
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            tbl_cities city = context.tbl_cities.Where(x => x.Id == id).FirstOrDefault();
            return View(city);
        }
        [HttpPost]
        public ActionResult Edit(tbl_cities Model)
        {
            var city = context.tbl_cities.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (city!=null)
            {
                city.Name = Model.Name;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var city = context.tbl_cities.Where(x => x.Id==id).FirstOrDefault();
            context.tbl_cities.Remove(city);
            context.SaveChanges();
            ViewBag.Message = "City deleted successfully";
            return RedirectToAction("Index");
        }


    }
}