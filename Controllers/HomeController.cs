using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostsBaord.Data;
using PostsBaord.Models;
using PostsBaord.VIewModels;

namespace PostsBaord.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainDbContext context;

        public HomeController(ILogger<HomeController> logger,
            MainDbContext context)
        {
            this._logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
                var list = context.Posts.ToList();
                return View("PostBoard");
        }

        public IActionResult AddPost()
        {
            var category = context.PostCategory.ToList();
            return View(category);
        }

    

        public async Task<IActionResult> ShowPost(int id)
        {
            var post = context.Posts.SingleOrDefault(p => p.ID == id);
            ++post.ViewCount;
            await context.SaveChangesAsync();
            return View(post);
        }

        public IActionResult EditPost(int id)
        {
            var post = context.Posts.SingleOrDefault(p => p.ID == id);
            ViewBag.abc = "123";

            return View(new EditPostViewModel
            {
                Post = post,
                Categories = context.PostCategory
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(int id,string title, string writer, string body)
        {
            var post = context.Posts.SingleOrDefault(n => n.ID == id);

          
            post.Title = title;
            post.Writer = writer;
            post.Content = body;
            post.UpdatedDate = DateTime.UtcNow;
            await context.SaveChangesAsync();

            return Redirect("/Home/ShowPost/"+id);
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = context.Posts.SingleOrDefault(n => n.ID == id);
            if(post!=null)
            {
                context.Posts.Remove(post);
            }
            await context.SaveChangesAsync();
            return Redirect("/");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
