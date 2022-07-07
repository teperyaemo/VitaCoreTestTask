using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class RenderedServices
    {
        [Key]
        public int Id_RenderedServ { get; set; }
        public int Id_VisitLog { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Service { get; set; }
        public int ServiceCount { get; set; }

        [ForeignKey("Id_VisitLog")]
        public virtual VisitLog? VisitLog { get; set; }

        [ForeignKey("Id_Employee")]
        public virtual Employee? Employee { get; set; }

        [ForeignKey("Id_Service")]
        public virtual Service? Service { get; set; }
    }
}