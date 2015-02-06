using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Waz.Core.Extension;
using System.Web.Routing;
using System.Web.Mvc;

namespace HelloWorld
{
    public class Extension : IExtension
    {
        const string Name = "HelloWorld";

        public void Initialize()
        {
            RouteTable.Routes.MapRoute(
                name: Name,
                url: Name + "/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, Extension = Name }
            );
        }

        public void UnInitialize()
        {
            RouteTable.Routes.Remove(RouteTable.Routes[Name]);
        }
    }
}