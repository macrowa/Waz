using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace Waz.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class WazAuthAttribute : FilterAttribute, IAuthorizationFilter
    {

        private List<string> m_Users = new List<string>();

        private List<string> m_Roles = new List<string>();

        private string m_Permission = string.Empty;

        public string Users
        {
            get
            {
                return string.Join(",", m_Users);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    m_Users = new List<string>();
                }
                else
                {
                    m_Users = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }
        }

        public string Roles
        {
            get
            {
                return string.Join(",", m_Roles);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    m_Roles =new List<string>();
                }
                else
                {
                    m_Roles = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }
        }

        public string Permission
        {
            get
            {
                return m_Permission;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    m_Permission = string.Empty;
                }
                else
                {
                    m_Permission = value;
                }
            }
        }

        public bool IsAnd = false;

        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }


        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }


            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                return;
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
        protected virtual bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            WazPrincipal user = httpContext.User as WazPrincipal;
            if (user == null || httpContext.User.Identity.IsAuthenticated == false)
            {
                return false;
            }
            if (m_Users.Count == 0 && m_Roles.Count == 0 && string.IsNullOrEmpty(m_Permission))
            {
                return true;
            }
            bool userFlag = m_Users.Exists(x => x == user.Info.Name);
            bool roleFlag = false;
            foreach (string role in m_Roles)
            {
                if (user.Roles.Exists(x => x.Name == role))
                {
                    roleFlag = true;
                    break;
                }
            }
            bool permissionFlag = user.Permissions.Exists(x => x.Name == Permission);

            if (IsAnd)
            {
                return userFlag && roleFlag && permissionFlag;
            }
            else
            {
                return userFlag || roleFlag || permissionFlag;
            }
        }

    }
}
