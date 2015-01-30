using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Waz.Data;

namespace Waz.Core
{
    public class WazController : Controller
    {
        public new WazPrincipal User
        {
            get
            {
                return base.User as WazPrincipal;
            }
        }
    }
}
