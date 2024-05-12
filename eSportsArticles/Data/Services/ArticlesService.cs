using eSportsArticles.Data.Base;
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

		public async Task<Article> GetArticleByIdAsync(Guid id)
		{
			var articleDetails = await _context.Articles
				.Include(a => a.Store)
				.FirstOrDefaultAsync(n => n.Id == id);

			return articleDetails;
		}
	}
}
