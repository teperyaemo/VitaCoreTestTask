using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;
using VitaCoreTestTask.Data.ViewModels;
using System.Threading.Tasks;

namespace VitaCoreTestTask.Controllers
{

    public class SpeciesController : Controller
    {
        private readonly VCappContext _context;
        private readonly ISpecies _species;
        private readonly IBreed _breed;

        public SpeciesController(VCappContext context, ISpecies species, IBreed breed)
        {
            _context = context;
            _species = species;
            _breed = breed;
        }
        // GET: PetOwnerController
        public ActionResult Index()
        {
            IEnumerable<Species> species = _species.Species;
            var speciesVM = new SpeciesVM
            {
                species = species
            };
            return View(speciesVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id_Species,Name")] SpeciesVM speciesVm)
        {
            if (ModelState.IsValid)
            {
                var species = new Species
                {
                    Id_Species = speciesVm.Id_Species,
                    Name = speciesVm.Name
                };
                _context.Add(species);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var speciesVM = new SpeciesVM
            {
                species = _species.Species
            };
            return View(speciesVM);
        }

        // GET: PetOwnerController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Species species = _species.GetSpecies(id);
            if (species == null)
            {
                return NotFound();
            }

            var speciesVM = new BreedsVM
            {
                species =species,
                breeds = _breed.BreedsBySpeciesId(id)
            };


            return View(speciesVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, [Bind("Id_Breed, Id_Species, Name")] BreedsVM breedsVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            Species species = _species.GetSpecies(id);
            if (species == null)
            {
                return NotFound();
            }

            var breed = new Breed
            {
                Id_Species = id,
                Name = breedsVM.Name
            };
            _context.Add(breed);
            _context.SaveChanges();

            var speciesVM = new BreedsVM
            {
                species = species,
                breeds = _breed.BreedsBySpeciesId(id)
            };


            return View(speciesVM);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = _context.Species
                .FirstOrDefault(m => m.Id_Species == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var species = _context.Species.Find(id);
            _context.Species.Remove(species);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteBreed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = _context.Breeds
                .FirstOrDefault(m => m.Id_Breed == id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        [HttpPost, ActionName("DeleteBreed")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBreedConfirmed(int id)
        {
            var breed = _context.Breeds.Find(id);
            _context.Breeds.Remove(breed);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
