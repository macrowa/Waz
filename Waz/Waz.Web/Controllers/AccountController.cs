using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Waz.Core;
using Waz.Data;
using System.Web.Security;

namespace Waz.Web.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult SignIn()
        {    
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string name, string password)
        {
            T_UserInfo userinfo = WazDb.QueryUserInfoByNameAndPassword(name, password);
            if (userinfo == null)
            {
                return View();
            }
            else
            {
                AuthManager.SignIn(HttpContext, userinfo, 60*24*90);
                return Redirect(FormsAuthentication.GetRedirectUrl(userinfo.Name, false));
            }
        }

        public ActionResult SignOut()
        {
            AuthManager.SignOut();
            return RedirectToAction("SignIn");
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}
