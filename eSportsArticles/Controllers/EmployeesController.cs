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
        public async Task<IActionResult> Create([Bind("lastName, firstName, Email, Phone, City, employeePosition, Salary, storeId")]Employee employee)
        {
			if (employee.lastName == null || employee.firstName == null || employee.Email == null ||
				employee.Phone == null || employee.City == null || employee.employeePosition == null
				|| employee.Salary == null)
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


		// Get: Employees/Edit
		public async Task<IActionResult> Edit(Guid id)
		{
			var employeeDetails = await _service.GetByIdAsync(id);

			if (employeeDetails == null)
			{
				return View("NotFound");
			}

			return View(employeeDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Guid id, [Bind(" lastName, firstName, Email, Phone, City, employeePosition, Salary")] Employee newEmployee)
		{
			if (newEmployee.lastName == null || newEmployee.firstName == null || newEmployee.Email == null || 
				newEmployee.Phone == null || newEmployee.City == null || newEmployee.employeePosition == null
				|| newEmployee.Salary == null)
			{
				return View(newEmployee);
			}

			var employeeDetails = await _service.GetByIdAsync(id);

			if (employeeDetails == null)
			{
				return View("NotFound");
			}

			employeeDetails.lastName = newEmployee.lastName;
			employeeDetails.firstName = newEmployee.firstName;
			employeeDetails.Email = newEmployee.Email;
			employeeDetails.Phone = newEmployee.Phone;
			employeeDetails.City = newEmployee.City;
			employeeDetails.employeePosition = newEmployee.employeePosition;
			employeeDetails.Salary = newEmployee.Salary;

			await _service.UpdateAsync(id, employeeDetails);

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
