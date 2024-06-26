using eSportsArticles.Data.Base;
using eSportsArticles.Data.ViewModels;
using eSportsArticles.Models;
using Microsoft.EntityFrameworkCore;

namespace eSportsArticles.Data.Services
{
	public class ArticlesService : EntityBaseRepository<Article>, IArticlesService
	{
		private readonly AppDBContext _context;

		public ArticlesService(AppDBContext context) : base(context)
        {
            _context = context;
        }

		public async Task AddNewArticleAsync(NewArticleVM data)
		{
			var newArticle = new Article()
			{
				articleName = data.articleName,
				articleCategory = data.articleCategory,
				Price = data.Price,
				Description = data.Description,
				Color = data.Color,
				Size = data.Size,
				ratingStars = data.ratingStars,
				isAvailable = data.isAvailable,
				startAvailablePeriod = data.startAvailablePeriod,
				endAvailablePeriod = data.endAvailablePeriod,
				PictureURL = data.PictureURL,
				StoreId = data.StoreIds.FirstOrDefault()
			};

			await _context.Articles.AddAsync(newArticle);
			await _context.SaveChangesAsync();

            //Add Article Store
            foreach (var StoreId in data.StoreIds)
            {
				var newStoreArticle = new StoresArticles()
				{
					storeId = StoreId,
					articleId = newArticle.Id
				};
				await _context.StoresArticles.AddAsync(newStoreArticle);
            }
			await _context.SaveChangesAsync();
        }

		public async Task<Article> GetArticleByIdAsync(Guid id)
		{
			var articleDetails = await _context.Articles
				.Include(a => a.Store)
				.Include(sa => sa.storeArticles)
				.FirstOrDefaultAsync(n => n.Id == id);

			return articleDetails;
		}

		public async Task<NewArticleDropdownsVM> GetNewArticleDropdownsValues()
		{
			var response = new NewArticleDropdownsVM()
			{
				Stores = await _context.Stores.OrderBy(n => n.storeName).ToListAsync()
			};

			return response;
		}

        public async Task UpdateArticleAsync(NewArticleVM data)
        {
			var dbArticle = await _context.Articles.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbArticle != null)
            {
				dbArticle.articleName = data.articleName;
				dbArticle.articleCategory = data.articleCategory;
				dbArticle.Price = data.Price;
				dbArticle.Description = data.Description;
				dbArticle.Color = data.Color;
				dbArticle.Size = data.Size;
				dbArticle.ratingStars = data.ratingStars;
				dbArticle.isAvailable = data.isAvailable;
				dbArticle.startAvailablePeriod = data.startAvailablePeriod;
				dbArticle.endAvailablePeriod = data.endAvailablePeriod;
				dbArticle.PictureURL = data.PictureURL;
				dbArticle.StoreId = data.StoreIds[0];

                await _context.SaveChangesAsync();
            }

			//Remove all stores
			var existingStoresDb = _context.StoresArticles.Where(n => n.articleId == data.Id).ToList();
			_context.StoresArticles.RemoveRange(existingStoresDb);
			await _context.SaveChangesAsync();

            //Add Article Store
            foreach (var StoreId in data.StoreIds)
            {
                var newStoreArticle = new StoresArticles()
                {
                    storeId = StoreId,
                    articleId = data.Id
                };
                await _context.StoresArticles.AddAsync(newStoreArticle);
            }
            await _context.SaveChangesAsync();
        }
    }
}
