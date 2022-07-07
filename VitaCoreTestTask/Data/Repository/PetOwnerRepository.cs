using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class PetOwnerRepository : IPetOwner
    {
        private readonly VCappContext _context;

        public PetOwnerRepository (VCappContext VCappContext)
        {
            _context = VCappContext;
        }
        public IEnumerable<PetOwner> petOwners => _context.PetOwners;

        public PetOwner GetPetOwner(int id) => _context.PetOwners.Find(id);
    }
}
