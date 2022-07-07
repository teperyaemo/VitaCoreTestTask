using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class PetOwnerVM
    {
        public IEnumerable<PetOwner> petOwners { get; set; }
        public string SearchString { get; set; }

    }
}
