using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Post post = new Post()
            {
                Title = "Hello Extension!",
                Content = "Mvc Extension!",
                Comments = new List<string>() { "good!", "thx" }
            };
            return View(post);
        }

    }
}
