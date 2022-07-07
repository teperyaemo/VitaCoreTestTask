using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class Vaccination
    {
        [Key]
        public int Id_Vaccination { get; set; }
        public string Name { get; set; }

        public List<PetVaccination>? PetVaccinations { get; set; }
    }
}