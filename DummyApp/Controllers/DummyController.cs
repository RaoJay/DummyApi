using DummyApp.ViewModels;
using DummyWrapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DummyApp.Controllers
{
    public class DummyController : Controller
    {
        private readonly ICaller _caller;
        public DummyController(ICaller caller)
        {
            _caller = caller;
        }

        // GET: Dummy
        public async Task<ActionResult> Index()
        {
            try
            {
                var results = await _caller.GetEmployees();
                var employees = new EmployeesViewModel
                {
                    employees = results
                };
                return View(employees);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ActionResult> GetEmployee(int? id) {
            try
            {
                var results = await _caller.GetEmployee(id);
                var employee = new EmployeeViewModel
                {
                    name = results.name,
                    id = results.id,
                    email = results.email,
                    gender = results.gender,
                    status = results.status
                };
                return View(employee);
            }
            catch (Exception)
            {

                throw;
            }
        } 
    }
}