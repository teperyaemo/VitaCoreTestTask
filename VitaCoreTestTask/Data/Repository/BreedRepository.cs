using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class BreedRepository : IBreed
    {
        private readonly VCappContext _context;

        public BreedRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public IEnumerable<Breed> Breeds => _context.Breeds;

        public IEnumerable<Breed> BreedsBySpeciesId(int id)
        {
            return _context.Breeds.Include(c => c.Species).Where(p => p.Id_Species == id);
        }
    }
}
