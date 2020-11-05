using NetflixApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace NetflixApp.Controllers
{
    public class NetflixController : Controller
    {
        // GET: Netflix

        public ViewResult Details()
        {
            var context = new SeriesDBEntities();
            var model = context.MyTables.ToList();
            return View(model);
        }

        public ViewResult Update(string id)
        {
            int Id = int.Parse(id);
            var context = new SeriesDBEntities();
            var model = context.MyTables.FirstOrDefault((s) => s.Id == Id);
            return View(model);

        }
        [HttpPost]
        public ActionResult Update(MyTable srs)
        {
            var context = new SeriesDBEntities();
            var model = context.MyTables.FirstOrDefault((s) => s.Id == srs.Id);
            model.Generes = srs.Generes;
            model.Title = srs.Title;
            model.Language = srs.Language;
            model.Starring = srs.Starring;
            model.Released_Date = srs.Released_Date;
            model.Rating = srs.Rating;

            context.SaveChanges();
            return RedirectToAction("Details");
        }

        public ViewResult AddNewSeries()
        {
            var model = new MyTable();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddNewSeries(MyTable srs)
        {
            var context = new SeriesDBEntities();
            context.MyTables.Add(srs);
            context.SaveChanges();
            return RedirectToAction("Details");
        }
        public ViewResult Delete(string id)
        {
            var srsId = int.Parse(id);
            var context = new SeriesDBEntities();
            var model = context.MyTables.FirstOrDefault((s) => s.Id == srsId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(string id, string conformbutton)
        {
            int srsId = int.Parse(id);
            var context = new SeriesDBEntities();
            var model = context.MyTables.FirstOrDefault((s) => s.Id == srsId);
            context.MyTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Details");
        }
    }
}