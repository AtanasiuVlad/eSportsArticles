using eSportsArticles.Data.Base;
using eSportsArticles.Models;

namespace eSportsArticles.Data.Services
{
	public interface IArticlesService: IEntityBaseRepository<Article>
	{
		Task<Article> GetArticleByIdAsync(Guid id);
	}
}
