using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class PetReviewVM
    {
        public Pet pet { get; set; }
        public IEnumerable<PetVaccination> petVaccinations { get; set; }
    }
}
