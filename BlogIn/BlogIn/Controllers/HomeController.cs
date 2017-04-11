using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BlogIn.DataAccess;
using BlogIn.Services;

namespace BlogIn.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            List<Post> posts = _blogService.All();
            return View(posts);
        }

        [HttpGet]
        public ActionResult Entry(Guid id)
        {
            Post post = _blogService.Get(id);
            return View(post);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
            if (string.IsNullOrWhiteSpace(post.Content) || string.IsNullOrWhiteSpace(post.Author))
            {
                return View();
            }

            Guid postId = _blogService.Create(post);
            return RedirectToAction("Entry", new { id = postId });
        }
    }
}