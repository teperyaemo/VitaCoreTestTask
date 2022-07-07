using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class PetAddEditVM
    {
        public List<SelectListItem>? SpeciesList { get; set; }
        public List<SelectListItem>? BreedList { get; set; }

        [Key]
        public int Id_Pet { get; set; }
        public int Id_PetOwner { get; set; }
        public int Id_Species { get; set; }
        public int Id_Breed { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Color { get; set; }
        public string? Other { get; set; }

        [ForeignKey("Id_PetOwner")]
        public virtual PetOwner PetOwner { get; set; }

        [ForeignKey("Id_Species")]
        public virtual Species Species { get; set; }

        [ForeignKey("Id_Breed")]
        public virtual Breed Breed { get; set; }

        public List<PetVaccination>? PetVaccinations { get; set; }
        public List<VisitLog>? VisitLogs { get; set; }
    }
}
