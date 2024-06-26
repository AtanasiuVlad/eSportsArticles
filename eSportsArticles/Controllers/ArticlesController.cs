using eSportsArticles.Data;
using eSportsArticles.Data.Services;
using eSportsArticles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return View(articlesList);
        }



        //Get: Articles/Details/Guid
        public async Task<IActionResult> Details(Guid Id)
        {
            var articleDetails = await _service.GetArticleByIdAsync(Id);
            return View(articleDetails);
        }

        //Get: Article/Create
        public async Task<IActionResult> Create() 
        {
            var articleDropdownsData = await _service.GetNewArticleDropdownsValues();

            ViewBag.Stores = new SelectList(articleDropdownsData.Stores, "Id", "storeName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewArticleVM article)
        {
            if(article.articleCategory == null || article.articleName == null || article.Price == null || article.Description == null ||
				article.ratingStars == null || article.Color == null || article.Size == null || article.isAvailable == null ||
				article.startAvailablePeriod == null || article.endAvailablePeriod == null || article.PictureURL == null) 
            {
				var articleDropdownsData = await _service.GetNewArticleDropdownsValues();

				ViewBag.Stores = new SelectList(articleDropdownsData.Stores, "Id", "storeName");

				return View(article);
            }

            await _service.AddNewArticleAsync(article);
            return RedirectToAction(nameof(Index));
        }


        //Get: Article/Edit/Guid

        public async Task<IActionResult> Edit(Guid Id)
        {
            var articleDetails = await _service.GetArticleByIdAsync(Id);

            if(articleDetails == null)
            {
                Console.WriteLine($"No article found with Id: {Id}");
                return View("NotFound");
            }

            var response = new NewArticleVM()
            {
                Id = articleDetails.Id,
                articleName = articleDetails.articleName,
                articleCategory = articleDetails.articleCategory,
                Price = articleDetails.Price,
                Description = articleDetails.Description,
                Color = articleDetails.Color,
                Size = articleDetails.Size,
                ratingStars = articleDetails.ratingStars,
                isAvailable = articleDetails.isAvailable,
                startAvailablePeriod = articleDetails.startAvailablePeriod,
                endAvailablePeriod = articleDetails.endAvailablePeriod,
                PictureURL = articleDetails.PictureURL,
                StoreIds =  articleDetails.storeArticles.Select(n => n.storeId).ToList()
            };


            var articleDropdownsData = await _service.GetNewArticleDropdownsValues();

            ViewBag.Stores = new SelectList(articleDropdownsData.Stores, "Id", "storeName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, NewArticleVM article)
        {
            if(Id != article.Id)
            {
                return View("NotFound");
            }

            if (article.articleCategory == null || article.articleName == null || article.Price == null || article.Description == null ||
                article.ratingStars == null || article.Color == null || article.Size == null || article.isAvailable == null ||
                article.startAvailablePeriod == null || article.endAvailablePeriod == null || article.PictureURL == null)
            {
                var articleDropdownsData = await _service.GetNewArticleDropdownsValues();

                ViewBag.Stores = new SelectList(articleDropdownsData.Stores, "Id", "storeName");

                return View(article);
            }

            await _service.UpdateArticleAsync(article);
            return RedirectToAction(nameof(Index));
        }

    }
}
