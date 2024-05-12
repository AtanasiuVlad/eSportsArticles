using eSportsArticles.Data.Base;
using eSportsArticles.Models;
using Microsoft.EntityFrameworkCore;

namespace eSportsArticles.Data.Services
{
    public class EmployeesService : EntityBaseRepository<Employee>, IEmployeesService
    {

        public EmployeesService(AppDBContext context) : base(context) { }



	}
}
