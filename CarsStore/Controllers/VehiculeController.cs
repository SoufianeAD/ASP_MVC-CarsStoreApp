using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Controllers
{
    using Models;
    public class VehiculeController : Controller
    {
        Model1 db = new Model1();

        // GET: Vehicule
        public ActionResult Index()
        {
            return View(db.Vehicules);
        }

        // GET: Vehicule/Details/5
        public ActionResult Details(int id)
        {
            Vehicule v = db.Vehicules.Find(id);
            return View(db.Vehicules.Find(id));
        }

        // GET: Vehicule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicule/Create
        [HttpPost]
        public ActionResult Create(Vehicule vehicule, string mainPicture, string picture1, string picture2, string picture3, string picture4)
        {
            try
            {
                vehicule.Pictures.Add(picture1);
                vehicule.Pictures.Add(picture2);
                vehicule.Pictures.Add(picture3);
                vehicule.Pictures.Add(picture4);
                db.Vehicules.Add(vehicule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vehicule/Edit/5
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

        // GET: Vehicule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vehicule/Delete/5
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
