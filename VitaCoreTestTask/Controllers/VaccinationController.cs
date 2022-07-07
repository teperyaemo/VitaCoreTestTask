using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;
using VitaCoreTestTask.Data.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace VitaCoreTestTask.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly VCappContext _context;
        private readonly IPetVac _petVac;
        private readonly IVaccination _vaccination;

        public VaccinationController(VCappContext context, IPetVac petVac, IVaccination vaccination)
        {
            _context = context;
            _petVac = petVac;
            _vaccination = vaccination;
        }
        // GET: PetOwnerController
        public ActionResult Index()
        {
            IEnumerable<Vaccination> vaccinations = _vaccination.vaccinations;                       

            var VaccinationVM = new VaccinationVM()
            {
                vaccinations = vaccinations
            };

            return View(VaccinationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id_Vaccination,Name")] VaccinationVM vaccinationVM)
        {
            if (ModelState.IsValid)
            {
                var vaccination = new Vaccination
                {
                    Id_Vaccination = vaccinationVM.Id_Vaccination,
                    Name = vaccinationVM.Name
                };
                _context.Add(vaccination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var vaccinationVm = new VaccinationVM
            {
                vaccinations = _vaccination.vaccinations
            };
            return View(vaccinationVm);
        }

        // GET: PetOwnerController/Create
        public IActionResult Create(int id)
        {
            var VaccinationsQuery = _context.Vaccinations.Select(a => new SelectListItem()
            {
                Value = a.Id_Vaccination.ToString(),
                Text = a.Name
            }).ToList();

            var petVacVM = new PetVacVM
            {
                Id_Pet = id,
                VaccinationsList = VaccinationsQuery
            };

            return View(petVacVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_PetVac, Id_Pet, Id_Vaccination, Date,Period")] PetVacVM petVacVM)
        {
            if (ModelState.IsValid)
            {
                var petVac = new PetVaccination
                {
                    Id_Pet = petVacVM.Id_Pet,
                    Id_Vaccination = petVacVM.Id_Vaccination,
                    Date = System.DateTime.Now,
                    Period = petVacVM.Period
                };
                _context.Add(petVac);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Pet", new {id = petVac.Id_Pet});
            }
            return View(petVacVM);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccination = _context.Vaccinations
                .FirstOrDefault(m => m.Id_Vaccination == id);
            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vaccination = _context.Vaccinations.Find(id);
            _context.Vaccinations.Remove(vaccination);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeletePetVac(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Petvaccination = _context.PetVaccinations.Include(u=>u.Vaccination)
                .FirstOrDefault(m => m.Id_PetVac == id);
            if (Petvaccination == null)
            {
                return NotFound();
            }

            return View(Petvaccination);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("DeletePetVac")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePetVacConfirmed(int id)
        {
            var Petvaccination = _context.PetVaccinations.Find(id);
            _context.PetVaccinations.Remove(Petvaccination);
            _context.SaveChanges();
            return RedirectToAction("Details", "Pet", new { id = id });
        }
    }
}