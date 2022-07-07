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
    public class PetOwnerController : Controller
    {
        private readonly VCappContext _context;
        private readonly IPetOwner _petOwner;
        private readonly IPet _pet;

        public PetOwnerController(VCappContext context, IPetOwner petOwner, IPet pet)
        {
            _context = context;
            _petOwner = petOwner;
            _pet = pet;
        }
        // GET: PetOwnerController
        public ActionResult Index(string searchString)
        {
            IEnumerable<PetOwner> petOwners = _petOwner.petOwners;

            if (!string.IsNullOrEmpty(searchString))
            {
                petOwners = _petOwner.petOwners.Where(s => s.Fullname!.Contains(searchString));
            }

            var PetOwnerVM = new PetOwnerVM()
            {
                petOwners = petOwners
            };

            return View(PetOwnerVM);
        }

        // GET: PetOwnerController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PetOwner petOwner = _petOwner.GetPetOwner(id);
            if (petOwner == null)
            {
                return NotFound();
            }

            var PetOwnerReviewVm = new PetOwnerReviewVM
            {
                PetOwner = petOwner,
                Pets = _pet.GetPetsByOwnerId(id)
            };


            return View(PetOwnerReviewVm);
        }

        // GET: PetOwnerController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_PetOwner,Fullname,PhoneNumber,Email,Other")] PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petOwner);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _context.PetOwners.FindAsync(id);
            if (petOwner == null)
            {
                return NotFound();
            }
            return View(petOwner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_PetOwner,Fullname,PhoneNumber,Email,Other")] PetOwner petOwner)
        {
            if (id != petOwner.Id_PetOwner)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetOwnerExists(petOwner.Id_PetOwner))
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
            return View(petOwner);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = _context.PetOwners
                .FirstOrDefault(m => m.Id_PetOwner == id);
            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var petOwner = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PetOwnerExists(int id)
        {
            return _context.PetOwners.Any(e => e.Id_PetOwner == id);
        }
    }
}
