using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Waz.Core;
using Waz.Data;

namespace Waz.Web.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult SignIn()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string name,string password)
        {
            
            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}
