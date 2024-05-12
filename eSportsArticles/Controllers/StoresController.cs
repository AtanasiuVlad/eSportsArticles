using eSportsArticles.Data;
using eSportsArticles.Data.Services;
using eSportsArticles.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace eSportsArticles.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoresServices _service;

        //dependacy injection AppDBContext by a constructor
        public StoresController(IStoresServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var storesList = await _service.GetAllAsync();
            return View(storesList);
        }

        //GET: stores/details/'GUID'
        public async Task<IActionResult> Details(Guid Id)
        {
            var storeDetails = await _service.GetByIdAsync(Id);

            if(storeDetails == null) 
            {
                return View("NotFound");
            }

            return View(storeDetails);
        }

        //GET: stores/create
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("storeName, Location, openHour, closeHour, PictureURL")]Store store)
        {
			if (store.storeName == null || store.Location == null || store.openHour == null ||
				store.closeHour == null || store.PictureURL == null)
			{
				return View(store);
			}

            await _service.AddAsync(store);

            return RedirectToAction(nameof(Index));
		}

		//GET: stores/edit/guid
		public async Task<IActionResult> Edit(Guid Id)
		{
            var storeDetails = await _service.GetByIdAsync(Id);

            if (storeDetails == null)
            {
                return View("NotFound");
            }

			return View(storeDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Guid Id,[Bind("Id, storeName, Location, openHour, closeHour, PictureURL")] Store store)
		{
			if (store.storeName == null || store.Location == null || store.openHour == null ||
				store.closeHour == null || store.PictureURL == null)
			{
				return View(store);
			}

            if(Id == store.Id) 
            { 
                await _service.UpdateAsync(Id, store);
                return RedirectToAction(nameof(Index));
            }

			

			return View(store);
		}

		//GET: stores/delete/guid
		public async Task<IActionResult> Delete(Guid Id)
		{
			var storeDetails = await _service.GetByIdAsync(Id);

			if (storeDetails == null)
			{
				return View("NotFound");
			}

			return View(storeDetails);
		}


		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(Guid Id)
		{
			var storeDetails = await _service.GetByIdAsync(Id);

			if (storeDetails == null)
			{
				return View("NotFound");
			}

            await _service.DeleteAsync(Id);

            return RedirectToAction(nameof(Index));
		}

	}
}
