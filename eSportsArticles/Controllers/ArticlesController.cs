using eSportsArticles.Data;
using eSportsArticles.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eSportsArticles.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _service;

        public ArticlesController(IArticlesService service)
        {
                _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var articlesList = await _service.GetAllAsync(n => n.Store);
            string test = "";
            return View(articlesList);
        }

        //Get: Articles/Details/Guid
        public async Task<IActionResult> Details(Guid Id)
        {
            var articleDetails = await _service.GetArticleByIdAsync(Id);
            return View(articleDetails);
        }
    }
}
