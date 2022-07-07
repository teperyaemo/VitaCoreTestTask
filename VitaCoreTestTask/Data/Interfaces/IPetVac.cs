using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IPetVac
    {
        public IEnumerable<PetVaccination> GetPetVaccinationsByPetId(int id);
    }
}
