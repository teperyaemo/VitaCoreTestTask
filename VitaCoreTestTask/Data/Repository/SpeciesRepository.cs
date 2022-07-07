using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class SpeciesRepository : ISpecies
    {
        private readonly VCappContext _context;

        public SpeciesRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public Species GetSpecies(int id) => _context.Species.Find(id);

        public IEnumerable<Species> Species => _context.Species;
    }
}
