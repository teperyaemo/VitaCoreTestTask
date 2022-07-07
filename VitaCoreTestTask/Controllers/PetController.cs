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
    public class PetController : Controller
    {
        private readonly VCappContext _context;
        private readonly IPetOwner _petOwner;
        private readonly IPet _pet;
        private readonly IPetVac _petVac;

        public PetController(VCappContext context, IPetOwner petOwner, IPet pet, IPetVac petVac)
        {
            _context = context;
            _petOwner = petOwner;
            _pet = pet;
            _petVac = petVac;
        }

        // GET: PetOwnerController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pet pet = _pet.GetPet(id);
            if (pet == null)
            {
                return NotFound();
            }

            var PetReviewVM = new PetReviewVM
            {
                pet = pet,
                petVaccinations = _petVac.GetPetVaccinationsByPetId(id)
            };

            return View(PetReviewVM);
        }

        // GET: PetOwnerController/Create
        public IActionResult Create(int id)
        {
            var SpeciesQuery = _context.Species.Select(a => new SelectListItem()
            {
                Value = a.Id_Species.ToString(),
                Text = a.Name
            }).ToList();

            var BreedQuery = _context.Breeds.Select(a => new SelectListItem()
            {
                Value = a.Id_Breed.ToString(),
                Text = a.Name
            }).ToList();

            var petVM = new PetAddEditVM
            {
                Id_PetOwner = id,
                SpeciesList = SpeciesQuery,
                BreedList = BreedQuery
            };

            return View(petVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Pet,Id_PetOwner,Id_Species,Id_Breed,Sex, DateOfBirth,Color,Other")] PetAddEditVM petVM)
        {
            if (ModelState.IsValid)
            {
                Pet pet = new Pet
                {
                    Id_PetOwner = petVM.Id_PetOwner,
                    Id_Species = petVM.Id_Species,
                    Id_Breed = petVM.Id_Breed,
                    Sex = petVM.Sex,
                    DateOfBirth = petVM.DateOfBirth,
                    Color = petVM.Color,
                    Other = petVM.Other
                };
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), nameof(PetOwner), pet.Id_PetOwner);
            }
            return View(petVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var SpeciesQuery = _context.Species.Select(a => new SelectListItem()
            {
                Value = a.Id_Species.ToString(),
                Text = a.Name
            }).ToList();

            var BreedQuery = _context.Breeds.Select(a => new SelectListItem()
            {
                Value = a.Id_Breed.ToString(),
                Text = a.Name
            }).ToList();

            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            var petVM = new PetAddEditVM
            {
                Id_Pet = pet.Id_Pet,
                Id_PetOwner = pet.Id_PetOwner,
                Id_Species = pet.Id_Species,
                Id_Breed = pet.Id_Breed,
                Sex = pet.Sex,
                DateOfBirth = pet.DateOfBirth,
                Color = pet.Color,
                Other = pet.Other,
                SpeciesList = SpeciesQuery,
                BreedList = BreedQuery
            };

            
            return View(petVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Pet,Id_PetOwner,Id_Species,Id_Breed,Sex, DateOfBirth,Color,Other")] PetAddEditVM petVM)
        {
            if (id != petVM.Id_Pet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Pet pet = new Pet
                {
                    Id_PetOwner = petVM.Id_PetOwner,
                    Id_Species = petVM.Id_Species,
                    Id_Breed = petVM.Id_Breed,
                    Sex = petVM.Sex,
                    DateOfBirth = petVM.DateOfBirth,
                    Color = petVM.Color,
                    Other = petVM.Other
                };
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id_Pet))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), nameof(PetOwner), pet.Id_PetOwner);
            }
            return View(petVM);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = _pet.GetPet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pet = _context.Pets.Find(id);
            _context.Pets.Remove(pet);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), nameof(PetOwner), pet.Id_PetOwner);
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id_Pet == id);
        }
    }
}
