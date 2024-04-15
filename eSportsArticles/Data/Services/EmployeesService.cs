using eSportsArticles.Models;
using Microsoft.EntityFrameworkCore;

namespace eSportsArticles.Data.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly AppDBContext _context;
        public EmployeesService(AppDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
           await _context.Employees.AddAsync(employee);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(n => n.Id == Id);
            _context.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }

        public async Task<Employee> GetByIdAsync(Guid Id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(n => n.Id == Id);
            return result;
        }

        public async Task<Employee> UpdateAsync(Guid Id, Employee newEmployee)
        {
            _context.Update(newEmployee);

            await _context.SaveChangesAsync();

            return newEmployee;
        }
    }
}
