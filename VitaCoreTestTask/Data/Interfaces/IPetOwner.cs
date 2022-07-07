using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IPetOwner
    {
        IEnumerable<PetOwner> petOwners { get; }
        PetOwner GetPetOwner(int id);
    }
}
