using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BCX_Assessment_01.Models;
using BCX_Assessment_01.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BCX_Assessment_01.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees/View
        public ActionResult TasksPerEmployee(int id)
        {
            var emp = new Employee() {Id = 1, Name = "Christiaan"};

            var tasks = new List<Models.Tasks>
            {
                new Models.Tasks { Id = 1, Name = "Bug Fix"},
                new Models.Tasks {Id = 1, Name = "Bug Fix"}
            };
            
            var viewModel = new EmployeeTasksViewModel
            {
                Employee = emp,
                Tasks = tasks
            };

            return View(viewModel);
        }

    }
}
