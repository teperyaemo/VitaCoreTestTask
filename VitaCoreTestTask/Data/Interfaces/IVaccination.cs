using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IVaccination
    {
        public IEnumerable<Vaccination> vaccinations { get; }
    }
}
