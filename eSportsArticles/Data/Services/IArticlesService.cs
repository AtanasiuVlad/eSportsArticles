using eSportsArticles.Data.Base;
using eSportsArticles.Data.ViewModels;
using eSportsArticles.Models;

namespace eSportsArticles.Data.Services
{
	public interface IArticlesService: IEntityBaseRepository<Article>
	{
		Task<Article> GetArticleByIdAsync(Guid id);
		Task<NewArticleDropdownsVM> GetNewArticleDropdownsValues();
		Task AddNewArticleAsync(NewArticleVM data);
		Task UpdateArticleAsync(NewArticleVM data);

    }
}
