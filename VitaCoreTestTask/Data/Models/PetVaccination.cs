using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class PetVaccination
    {
        [Key]
        public int Id_PetVac { get; set; }
        public int Id_Pet { get; set; }
        public int Id_Vaccination { get; set; }
        public DateTime Date { get; set; }
        public int? Period { get; set; }

        public virtual Pet? Pet { get; set; }

        [ForeignKey("Id_Vaccination")]
        public virtual Vaccination? Vaccination { get; set; }
    }
}