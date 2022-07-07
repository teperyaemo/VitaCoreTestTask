using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class PetVacVM
    {
        public List<SelectListItem>? VaccinationsList { get; set; }

        public int Id_PetVac { get; set; }
        public int Id_Pet { get; set; }
        public int Id_Vaccination { get; set; }
        public DateTime Date { get; set; }
        public int? Period { get; set; }
    }
}
