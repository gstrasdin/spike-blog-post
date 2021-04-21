using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Spike.Jane.Blog.Service.Domain;
using Spike.Jane.Blog.Web.Models;

namespace Spike.Jane.Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWordpressClient _client;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IWordpressClient client, ILogger<HomeController> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _client.ListPostsAsync();
            var model = (
                    from post in posts
                    select new IndexViewModel
                    {
                        PostId = post.Id,
                        DatePosted = $"{post.Date:MMMM, d yyyy}",
                        Title = HttpUtility.HtmlDecode(post.Title.Rendered)
                    })
                .ToList();

            return View(model);
        }

        public async Task<IActionResult> Post(int postId)
        {
            var post = await _client.RetrievePostAsync(postId);
            var categories = await _client.ListCategoriesAsync();
            var model = new PostViewModel
            {
                Id = post.Id,
                Date = post.Date,
                Title = HttpUtility.HtmlDecode(post.Title.Rendered),
                Categories = String.Join(", ",
                    from c in categories
                    join cid in post.Categories on c.Id equals cid
                    select c.Name),
                ImageUrl = post.MediaUrl
            };

            return View(model);
        }

        public async Task<IActionResult> Moments()
        {
            var viewModel = new MomentsViewModel();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
