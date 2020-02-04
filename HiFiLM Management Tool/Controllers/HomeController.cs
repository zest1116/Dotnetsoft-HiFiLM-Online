using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dotnetsoft.HiFiLM.Management.Tool.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Dashboard()
        {
            ViewBag.Title = Resources.ResourceDictionary.Main_Dashboard;
            return View();
        }
    }
}