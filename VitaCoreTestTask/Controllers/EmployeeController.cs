using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;
using VitaCoreTestTask.Data.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VitaCoreTestTask.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly VCappContext _context;
        private readonly IEmployee _employee;

        public EmployeeController(VCappContext context, IEmployee employee)
        {
            _context = context;
            _employee = employee;
        }
        // GET: PetOwnerController
        public ActionResult Index(string SearchString)
        {
            IEnumerable<Employee> employees = _employee.Employees;

            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = _employee.Employees.Where(s => s.FullName!.Contains(SearchString));
            }

            var emplVM = new EmployeeVM()
            {
                employees = employees
            };

            return View(emplVM);
        }

        // GET: PetOwnerController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Emloyee,FullName,Address,Email,PhoneNumber,JobTitle")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Emloyee,FullName,Address,Email,PhoneNumber,JobTitle")] Employee employee)
        {
            if (id != employee.Id_Emloyee)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id_Emloyee))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees
                .FirstOrDefault(m => m.Id_Emloyee == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id_Emloyee == id);
        }
    }
}
