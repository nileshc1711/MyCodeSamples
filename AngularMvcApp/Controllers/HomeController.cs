using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMvcApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NgErrorDemo() 
        {
            return View();
        }

        public ActionResult NgPracticeDemo() 
        {
            return View();
        }
    }
}
