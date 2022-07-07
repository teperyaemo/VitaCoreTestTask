using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IEmployee
    {
        public Employee GetEmployee(int id);
        public IEnumerable<Employee> Employees { get; }
    }
}
