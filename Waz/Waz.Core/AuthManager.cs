using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using Waz.Data;
using Newtonsoft.Json;

namespace Waz.Core
{
    public class AuthManager
    {
        public static bool SignIn(HttpContextBase context,T_UserInfo userinfo, int timeOut)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context");
            }
            if (string.IsNullOrEmpty(userinfo.Name))
            {
                throw new ArgumentNullException("Name");
            }
            if (timeOut <= 0)
            {
                throw new ArgumentOutOfRangeException("timeOut");
            }
            DateTime now = DateTime.Now;

            string userData = JsonConvert.SerializeObject(userinfo,Formatting.Indented);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, userinfo.Name, now, now.AddMinutes(timeOut), true, userData);
            string str_ticket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, str_ticket);
            cookie.HttpOnly = false;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = now.AddSeconds(timeOut);

            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
            return true;
        }

        public static bool Authenticate(HttpContextBase context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context");
            }

            HttpCookie cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
            {
                return false;
            }

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

            context.User = new WazPrincipal(ticket);
            return true;
        }

        public static bool SignOut()
        {
            FormsAuthentication.SignOut();
            return true;
        }
    }
}
