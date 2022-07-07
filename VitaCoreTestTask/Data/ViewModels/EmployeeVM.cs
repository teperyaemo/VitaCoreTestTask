using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class EmployeeVM
    {
        public string SearchString { get; set; }
        public IEnumerable<Employee> employees { get; set; }
    }
}
