using eSportsArticles.Data.Base;
using eSportsArticles.Models;

namespace eSportsArticles.Data.Services
{
	public class StoresService : EntityBaseRepository<Store>, IStoresServices
	{
        public StoresService(AppDBContext context) : base(context)
        {
            
        }
    }
}
