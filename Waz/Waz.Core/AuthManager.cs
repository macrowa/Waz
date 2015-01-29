using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;

namespace Waz.Core
{
    public class AuthManager
    {
        public static bool SignIn(HttpContext context,long id,string name, int timeOut)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name");
            }
            if (timeOut <= 0)
            {
                throw new ArgumentOutOfRangeException("timeOut");
            }
            DateTime now = DateTime.Now;

            string userData = name;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, name, now, now.AddMinutes(timeOut), true, userData);
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

        public static bool Authenticate(HttpContext context)
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

            if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
            {
                string userData = ticket.UserData;
                context.User = new WazPrincipal(ticket);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SignOut()
        {
            FormsAuthentication.SignOut();
            return true;
        }
    }
}
