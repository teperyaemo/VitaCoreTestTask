using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class VisitLog
    {
        [Key]
        public int Id_VisitLog { get; set; }
        public DateTime Date { get; set; }
        public int Id_PetOwner { get; set; }
        public int Id_Pet { get; set; }

        [ForeignKey("Id_PetOwner")]
        public virtual PetOwner? PetOwner { get; set; }
        [ForeignKey("Id_Pet")]
        public virtual Pet? Pet { get; set; }

        public List<RenderedServices>? RenderedServices { get; set; }
    }
}