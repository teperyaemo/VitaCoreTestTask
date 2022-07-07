using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class PetVacRepository : IPetVac
    {
        private readonly VCappContext _context;

        public PetVacRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public IEnumerable<PetVaccination> GetPetVaccinationsByPetId(int id) => _context.PetVaccinations.Include(p => p.Vaccination).Where(u => u.Id_Pet == id);
        
    }
}
