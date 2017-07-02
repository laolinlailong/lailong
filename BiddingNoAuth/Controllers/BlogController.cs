using System.Web.Mvc;
using Blogging.Services.ImplementedInterfaces.InputModels;
using Blogging.Services.ImplementedInterfaces.Queries;
using Blogging.Services.ImplementedInterfaces.Services;

namespace BiddingNoAuth.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogQuery _blogQuery;
        private readonly IBlogService _blogService;

        public BlogController(IBlogQuery blogQuery, IBlogService blogService)
        {
            _blogQuery = blogQuery;
            _blogService = blogService;
        }
        // GET: Blog
        public ActionResult Index()
        {
            var blogs = _blogQuery.Blogs();
            return View(blogs);
        }

        // GET: Blog/Details/5
        public ActionResult Detail(long id)
        {
            var blog = _blogQuery.Blog(id);
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            var model = new BlogInputModel();
            return View(model);
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(BlogInputModel model)
        {
            if(ModelState.IsValid)
            {
                _blogService.Create(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Blog/Edit/5
        public ActionResult Comment(int blogId)
        {
            var model = new CommentInputModel {BlogId = blogId};
            return View(model);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Comment(CommentInputModel model)
        {
            if (ModelState.IsValid)
            {
                _blogService.Comment(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
