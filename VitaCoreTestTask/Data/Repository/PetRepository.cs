using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class PetRepository : IPet
    {
        private readonly VCappContext _context;

        public PetRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public IEnumerable<Pet> pets => _context.Pets;

        public Pet GetPet(int id)=> _context.Pets.Include(p=>p.Species).Include(c=>c.Breed).Include(d=>d.PetOwner).First(d=> d.Id_Pet == id);

        public IEnumerable<Pet> GetPetsByOwnerId(int id) => _context.Pets.Include(c => c.Species).Include(p => p.Breed).Where(f => f.Id_PetOwner == id);
    }
}
