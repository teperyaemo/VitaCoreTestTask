using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class PetOwnerReviewVM
    {
        public PetOwner PetOwner { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
