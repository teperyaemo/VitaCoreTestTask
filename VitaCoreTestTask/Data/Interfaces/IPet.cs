using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IPet
    {
        public IEnumerable<Pet> pets { get; }
        public IEnumerable<Pet> GetPetsByOwnerId(int id);
        public Pet GetPet(int id);
    }
}
