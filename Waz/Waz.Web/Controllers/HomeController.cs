using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Waz.Core;


namespace Waz.Web.Controllers
{
    [WazAuth(Permission="a")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

    }
}
