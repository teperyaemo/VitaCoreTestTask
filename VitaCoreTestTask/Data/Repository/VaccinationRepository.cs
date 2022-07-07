using System.Collections.Generic;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class VaccinationRepository : IVaccination
    {
        private readonly VCappContext _context;

        public VaccinationRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }
        public IEnumerable<Vaccination> vaccinations => _context.Vaccinations;
    }
}
