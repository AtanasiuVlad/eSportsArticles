using eSportsArticles.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eSportsArticles.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly AppDBContext _context;

        public ArticlesController(AppDBContext context)
        {
                _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var articlesList = await _context.Articles.ToListAsync();
            return View(articlesList);
        }
    }
}
