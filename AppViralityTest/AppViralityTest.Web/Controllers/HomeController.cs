using AppViralityTest.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppViralityTest.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public CategoryManager _categoryManager;
        public HomeController()
        {
            _categoryManager = new CategoryManager();
        }
        public ActionResult Index()
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = categories;

            return View();
        }

    }
}