using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public PostsController(ITagRepository tagRepository)
        {
            this._tagRepository = tagRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await _tagRepository.GetAllTagsAsync();
            var model = new PostAddRequest
            {
                Tags = tags.Select(tmp => new SelectListItem
                {
                    Text = tmp.Name,
                    Value = tmp.ID.ToString(),
                })
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PostAddRequest request)
        {
            return RedirectToAction("Add");
        }
    }
}
