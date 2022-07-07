
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;
using VitaCoreTestTask.Data.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace VitaCoreTestTask.Controllers
{
    public class RenderedServiceController : Controller
    {
        private readonly VCappContext _context;
        private readonly IRenderedService _renderedService;

        public RenderedServiceController(VCappContext context, IRenderedService renderedService)
        {
            _context = context;
            _renderedService = renderedService;
        }

        // GET: PetOwnerController/Create
        public IActionResult Create(int id)
        {
            return View(GetVM(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_RenderedServ,Id_VisitLog,Id_Employee,Id_Service,ServiceCount")] RenderedServiceVM renderedServiceVM)
        {
            if (ModelState.IsValid)
            {
                var rService = new RenderedServices
                {
                    Id_VisitLog = renderedServiceVM.Id_VisitLog,
                    Id_Employee = renderedServiceVM.Id_Employee,
                    Id_Service = renderedServiceVM.Id_Service,
                    ServiceCount = renderedServiceVM.ServiceCount
                };
                _context.Add(rService);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "VisitLog", new { id = renderedServiceVM.Id_VisitLog });
            }
            return View(GetVM(renderedServiceVM.Id_VisitLog));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var EmployeeQuery = _context.Employees.Select(a => new SelectListItem()
            {
                Value = a.Id_Emloyee.ToString(),
                Text = a.FullName
            }).ToList();

            var ServiceQuery = _context.Services.Select(a => new SelectListItem()
            {
                Value = a.Id_Service.ToString(),
                Text = a.Name
            }).ToList();

            var rService = await _context.RenderedServices.FindAsync(id);

            if (rService == null)
            {
                return NotFound();
            }

            var renderedServiceVM = new RenderedServiceVM
            {
                Id_RenderedServ = rService.Id_RenderedServ,
                Id_VisitLog = rService.Id_VisitLog,
                Id_Employee = rService.Id_Employee,
                Id_Service = rService.Id_Service,
                ServiceCount = rService.ServiceCount,
                ServiceList = ServiceQuery,
                EmployeeList = EmployeeQuery
                
            };


            return View(renderedServiceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_RenderedServ,Id_VisitLog,Id_Employee,Id_Service,ServiceCount")] RenderedServiceVM renderedServiceVM)
        {
            if (id != renderedServiceVM.Id_RenderedServ)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                RenderedServices rService = new RenderedServices
                {
                    Id_RenderedServ = renderedServiceVM.Id_RenderedServ,
                    Id_VisitLog = renderedServiceVM.Id_VisitLog,
                    Id_Employee = renderedServiceVM.Id_Employee,
                    Id_Service = renderedServiceVM.Id_Service,
                    ServiceCount = renderedServiceVM.ServiceCount
                };
                try
                {
                    _context.Update(rService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rServExists(rService.Id_RenderedServ))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "VisitLog", new { id = id });
            }
            return View(renderedServiceVM);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rService = _context.RenderedServices.Include(c=>c.Service).Include(u=>u.Employee).First(p=>p.Id_RenderedServ == id);
            if (rService == null)
            {
                return NotFound();
            }

            return View(rService);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var rService = _context.RenderedServices.Find(id);
            _context.RenderedServices.Remove(rService);
            _context.SaveChanges();
            return RedirectToAction("Details", "VisitLog", new { id = id });
        }

        private bool rServExists(int id)
        {
            return _context.RenderedServices.Any(e => e.Id_RenderedServ == id);
        }

        private RenderedServiceVM GetVM(int id)
        {
            var EmployeeQuery = _context.Employees.Select(a => new SelectListItem()
            {
                Value = a.Id_Emloyee.ToString(),
                Text = a.FullName
            }).ToList();

            var ServiceQuery = _context.Services.Select(a => new SelectListItem()
            {
                Value = a.Id_Service.ToString(),
                Text = a.Name
            }).ToList();

            var rServiceVM = new RenderedServiceVM
            {
                Id_VisitLog = id,
                EmployeeList = EmployeeQuery,
                ServiceList = ServiceQuery
            };

            return rServiceVM;
        }
    }
}
