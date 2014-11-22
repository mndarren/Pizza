using PizzaGUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaGUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Provider(string username = "your name", int id = 0)
        {
            ViewBag.ID = id;
            ViewBag.Username = username;
            return View(new ProviderViewModel());
        }

        public ActionResult Admin(string username = "your name", int id = 0)
        {
            ViewBag.ID = id;
            ViewBag.Username = username;
            return View(new AdminViewModel());
        }

        public ActionResult Manager(string username = "your name", int id = 0)
        {
            ViewBag.ID = id;
            ViewBag.Username = username;
            return View(new ManagerViewModel());
        }
    }
}