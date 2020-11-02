using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCX_Assessment_01.Models;

namespace BCX_Assessment_01.ViewModels
{
    public class EmployeeTasksViewModel
    {
        public Employee Employee { get; set; }
        public List<Models.Tasks> Tasks { get; set; }
    }
}
