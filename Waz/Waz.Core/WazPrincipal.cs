using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace Waz.Core
{
    public class WazPrincipal : IPrincipal
    {
        private IIdentity m_Identity;

        public WazPrincipal(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }
            m_Identity = new FormsIdentity(ticket);
        }

        public IIdentity Identity
        {
            get
            {
                return m_Identity;
            }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}