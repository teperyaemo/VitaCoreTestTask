using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;
using VitaCoreTestTask.Data.ViewModels;
using System.Threading.Tasks;

namespace VitaCoreTestTask.Controllers
{
    public class ServiceController : Controller
    {
        private readonly VCappContext _context;
        private readonly IService _service;

        public ServiceController(VCappContext context,IService service)
        {
            _context = context;
            _service = service;
        }
        // GET: PetOwnerController
        public ActionResult Index()
        {
            IEnumerable<Service> services = _service.services;
            var sercieVM = new ServiceVM
            {
                services = services
            };
            return View(sercieVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id_Service,Name, Price")] ServiceVM sercieVM)
        {
            if (ModelState.IsValid)
            {
                var service = new Service
                {
                    Id_Service = sercieVM.Id_Service,
                    Name = sercieVM.Name,
                    Price = sercieVM.Price
                };
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(sercieVM);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = _context.Services
                .FirstOrDefault(m => m.Id_Service == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
