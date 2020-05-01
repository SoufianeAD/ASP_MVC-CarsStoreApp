using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarsStore.Controllers
{
    using Models;
    public class PublicationController : Controller
    {
        ApplicationDbContext db0 = new ApplicationDbContext();
        Model1 db = new Model1();


        public ActionResult AchatClient(int id)
        {
            string email = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            ApplicationUser user = db0.Users.First(item => item.Email == email);
            Client client = db.Clients.First(c => c.IdAccount == user.Id);
            Achat achat = new Achat { Client = client, Vehicule = db.Vehicules.Find(id) };
            db.Achats.Add(achat);
            db.SaveChanges();
            return RedirectToAction("IndexAchat");
        }

        public ActionResult IndexAchat()
        {
            string email = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            ApplicationUser user = db0.Users.First(item => item.Email == email);
            //
            return View(db.Achats.Where(a => a.Client.IdAccount == user.Id));
        }

        // GET: Publication
        public ActionResult Index()
        {
            return View(db.Publications);
        }

        [AllowAnonymous]
        public ActionResult IndexClient()
        {
            return View(db.Publications);
        }

        [Authorize]
        public ActionResult DetailsClient(int id)
        {
            Publication publication = db.Publications.Find(id);
            Vehicule vehicule = db.Vehicules.Find(publication.Vehicule.Id);
            Char[] sep = { ';' };
            String[] res = vehicule.Pictures.Split(sep);
            ViewData["pictures"] = res;

            //
            string email = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            ApplicationUser user = db0.Users.First(item => item.Email == email);
            Client client = db.Clients.First(c => c.IdAccount == user.Id);
            ViewData["client"] = client;

            //
            ViewBag.comments = db.Commentaires.Where(c => c.Publication.Id == id);

            return View(publication);
        }

        public ActionResult CreateComment(int id, string commentaire)
        {
            string email = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            ApplicationUser user = db0.Users.First(item => item.Email == email);
            Client client = db.Clients.First(c => c.IdAccount == user.Id);
            //
            Commentaire com = new Commentaire { Client = client, Publication = db.Publications.Find(id), CommentText = commentaire };
            db.Commentaires.Add(com);
            db.SaveChanges();
            return RedirectToAction("DetailsClient", new { id = id });
        }

        // GET: Publication/Details/5
        public ActionResult Details(int id)
        {
            Publication publication = db.Publications.Find(id);
            Vehicule vehicule = db.Vehicules.Find(publication.Vehicule.Id);
            Char[] sep = { ';' };
            String[] res = vehicule.Pictures.Split(sep);
            ViewData["pictures"] = res;
            return View(publication);
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            ViewBag.vehicules = db.Vehicules;
            return View();
        }

        // POST: Publication/Create
        [HttpPost]
        public ActionResult Create(Publication publication, int vehiculeId)
        {
            try
            {
                ViewBag.vehicules = db.Vehicules;
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
            Publication publication = db.Publications.Find(id);
            Vehicule vehicule = publication.Vehicule;
            Char[] sep = { ';' };
            String[] res = vehicule.Pictures.Split(sep);
            ViewData["pictures"] = res;
            return View(publication);
        }

        // POST: Publication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                db.Publications.Remove(db.Publications.Find(id));
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