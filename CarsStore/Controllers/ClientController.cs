using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Controllers
{
    using Models;
    public class ClientController : Controller
    {

        ApplicationDbContext db0 = new ApplicationDbContext();
        Model1 db = new Model1();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.Clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            Client client = db.Clients.Find(id);
            ApplicationUser user = db0.Users.First(item => item.Id == client.IdAccount);
            ViewBag.email = user.Email;
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                string email = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                ApplicationUser user = db0.Users.First(item => item.Email == email);
                client.IdAccount = user.Id;
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Publication");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Clients.Find(id));
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                Client c = db.Clients.Find(id);
                c.FirstName = client.FirstName;
                c.LastName = client.LastName;
                c.Address = client.Address;
                c.Phone = client.Phone;
                if(client.Picture != null)
                {
                    c.Picture = client.Picture;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Clients.Find(id));
        }

        // POST: Client/Delete/5
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
