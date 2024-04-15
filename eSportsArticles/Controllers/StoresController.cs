using eSportsArticles.Data;
using Microsoft.AspNetCore.Mvc;

namespace eSportsArticles.Controllers
{
    public class StoresController : Controller
    {
        private readonly AppDBContext _context;

        //dependacy injection AppDBContext by a constructor
        public StoresController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var storesList = _context.Stores.ToList();
            return View(storesList);
        }
    }
}
