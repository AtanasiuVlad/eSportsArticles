using eSportsArticles.Models;

namespace eSportsArticles.Data.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(Guid Id);
        Task AddAsync(Employee employee);
        Task<Employee> UpdateAsync(Guid Id, Employee newEmployee);
        Task DeleteAsync(Guid Id);
    }
}
