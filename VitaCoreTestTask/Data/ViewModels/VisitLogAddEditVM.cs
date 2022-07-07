using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class VisitLogAddEditVM
    {

        public List<SelectListItem>? PetOwnerList { get; set; }
        public List<SelectListItem>? PetList { get; set; }

        [Key]
        public int Id_VisitLog { get; set; }
        public DateTime Date { get; set; }
        public int Id_PetOwner { get; set; }
        public int Id_Pet { get; set; }
    }
}
