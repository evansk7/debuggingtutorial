using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteDebugDemo.Models;

namespace RemoteDebugDemo.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        [HttpPost]
        public IActionResult Add(Blog blog)
        {

            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }

            return new RedirectToActionResult("Index", "Home", null);
        }

        public IActionResult Test()
        {
            return View("Home/Index");
        }
    }
}