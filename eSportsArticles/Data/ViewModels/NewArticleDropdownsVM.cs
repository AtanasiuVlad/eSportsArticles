using eSportsArticles.Models;

namespace eSportsArticles.Data.ViewModels
{
	public class NewArticleDropdownsVM
	{
        public NewArticleDropdownsVM()
        {
            Stores = new List<Store>();    
        }

        public List<Store> Stores { get; set; }

    }
}
