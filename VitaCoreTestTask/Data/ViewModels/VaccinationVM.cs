using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class VaccinationVM
    {
        public int Id_Vaccination { get; set; }
        public string Name { get; set; }
        public IEnumerable<Vaccination> vaccinations { get; set; }
    }
}
