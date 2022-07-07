using System.Collections.Generic;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class EmplyeeRepository : IEmployee
    {
        private readonly VCappContext _context;

        public EmplyeeRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public IEnumerable<Employee> Employees => _context.Employees;

        public Employee GetEmployee(int id)=> _context.Employees.Find(id);
    }
}
