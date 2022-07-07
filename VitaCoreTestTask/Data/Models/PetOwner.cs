using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class PetOwner
    {
        [Key]
        public int Id_PetOwner { get; set; }
        public string Fullname { get; set; }
        public int PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Other { get; set; }

        public List<Pet>? Pets { get; set; }
        public List<VisitLog>? VisitLogs { get; set; }
    }
}