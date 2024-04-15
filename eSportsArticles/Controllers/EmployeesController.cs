using eSportsArticles.Data;
using eSportsArticles.Data.Services;
using eSportsArticles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eSportsArticles.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _service;

        public EmployeesController(IEmployeesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var employeesList = await _service.GetAllAsync();
            return View(employeesList);
        }

        // Get: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("lastName, firstName, Email, Phone, City, employeePosition, Salary")]Employee employee)
        {
            if(!ModelState.IsValid) 
            {
                return View(employee);
            }
            await _service.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        //Get: Employees/Details/1

        public async Task<IActionResult> Details(Guid id)
        {
            var employeeDetails = await _service.GetByIdAsync(id);

            if(employeeDetails == null)
            {
                return View("NotFound");
            }
            
            return View(employeeDetails);
        }


		// Get: Employees/Create
		public async Task<IActionResult> Edit(Guid Id)
		{
			var employeeDetails = await _service.GetByIdAsync(Id);

			if (employeeDetails == null)
			{
				return View("NotFound");
			}

			return View(employeeDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Guid Id, [Bind("Id, lastName, firstName, Email, Phone, City, employeePosition, Salary")] Employee employee)
		{
			if (!ModelState.IsValid)
			{
				return View(employee);
			}

			
			employee.Id = Id;

			await _service.UpdateAsync(Id, employee);

			return RedirectToAction(nameof(Index));
		}
		

		// Get: Employees/Delete
		public async Task<IActionResult> Delete(Guid Id)
		{
			var employeeDetails = await _service.GetByIdAsync(Id);

			if (employeeDetails == null)
			{
				return View("NotFound");
			}

			return View(employeeDetails);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(Guid Id)
		{
			var employeeDatails = await _service.GetByIdAsync(Id);
			if (employeeDatails == null)
			{
				return View("NotFound");
			}

			await _service.DeleteAsync(Id);
			
			return RedirectToAction(nameof(Index));
		}
	}
}
