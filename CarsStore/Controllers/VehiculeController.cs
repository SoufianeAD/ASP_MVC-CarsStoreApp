using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Controllers
{
    using Models;
    [Authorize(Roles = "Admin")]
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
            Vehicule vehicule = db.Vehicules.Find(id);
            Char[] sep = { ';' };
            String[] res = vehicule.Pictures.Split(sep);
            ViewData["pictures"] = res;
            return View(vehicule);
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
                vehicule.Pictures = picture1;
                vehicule.Pictures += ";" + picture2;
                vehicule.Pictures += ";" + picture3;
                vehicule.Pictures += ";" + picture4;
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
            Vehicule vehicule = db.Vehicules.Find(id);
            Char[] sep = { ';' };
            String[] res = vehicule.Pictures.Split(sep);
            ViewBag.pictures = res;
            return View(db.Vehicules.Find(id));
        }

        // POST: Vehicule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Vehicule vehicule, string mainPicture, string picture1, string picture2, string picture3, string picture4)
        {
            try
            {
                Vehicule v = db.Vehicules.Find(id);
                //
                v.Company = vehicule.Company;
                v.Model = vehicule.Model;
                v.Power = vehicule.Power;
                v.Price = vehicule.Price;
                v.Engine = vehicule.Engine;
                //
                if(mainPicture != "")
                {
                    v.MainPicture = mainPicture;
                } 
                //
                Char[] sep = { ';' };
                String[] res = v.Pictures.Split(sep);
                if(picture1 != "")
                {
                    v.Pictures = picture1;
                } else
                {
                    v.Pictures = res[0];
                }

                if (picture2 != "")
                {
                    v.Pictures += ";" + picture2;
                }
                else
                {
                    v.Pictures += ";" + res[1];
                }

                if (picture3 != "")
                {
                    v.Pictures += ";" + picture3;
                }
                else
                {
                    v.Pictures += ";" + res[2];
                }

                if (picture4 != "")
                {
                    v.Pictures += ";" + picture4;
                }
                else
                {
                    v.Pictures += ";" + res[3];
                }

                db.SaveChanges();
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
            Vehicule vehicule = db.Vehicules.Find(id);
            Char[] sep = { ';' };
            String[] res = vehicule.Pictures.Split(sep);
            ViewData["pictures"] = res;
            return View(db.Vehicules.Find(id));
        }

        // POST: Vehicule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                db.Vehicules.Remove(db.Vehicules.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
