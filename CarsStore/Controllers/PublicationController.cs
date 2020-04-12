using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Controllers
{
    using Models;
    public class PublicationController : Controller
    {
        Model1 db = new Model1();

        // GET: Publication
        public ActionResult Index()
        {
            return View(db.Publications);
        }

        // GET: Publication/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Publications.Find(id));
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            ViewBag.vehicules = db.Vehicules;
            //ViewBag.vehicule = db.Vehicules.Find(6);
            return View();
        }

        // POST: Publication/Create
        [HttpPost]
        public ActionResult Create(Publication publication, int vehiculeId)
        {
            try
            {
                ViewBag.vehicules = db.Vehicules;
                publication.PublishDate = DateTime.Now;
                publication.Status = "Open";
                publication.Vehicule = db.Vehicules.Find(vehiculeId);
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publication/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Publications.Find(id));
        }

        // POST: Publication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publication/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Publications.Find(id));
        }

        // POST: Publication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
