using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Controllers
{
    using Models;
    public class HomeController : Controller
    {
        private UserRoleProvider roleProvider = new UserRoleProvider();
        ApplicationDbContext db0 = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult createRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createRole(string roleName)
        {
            try
            {
                roleProvider.CreateRole(roleName);
            } catch(Exception e)
            {
                ViewBag.message = "Error :: " + e.Message;
                return View();
            }
            return View();
        }

        public ActionResult IndexRole()
        {
            ViewBag.roles = db0.Roles.ToList();
            return View();
        }

        public ActionResult DeleteRole(string id)
        {
            foreach (var item in db0.Roles.ToList())
            {
                if(item.Id.Equals(id))
                {
                    db0.Roles.Remove(item);
                    db0.SaveChanges();
                }
            }
            return RedirectToAction("IndexRole");
        }

    }
}