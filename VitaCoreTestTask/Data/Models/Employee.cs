using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class Employee
    {
        [Key]
        public int Id_Emloyee { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string JobTitle { get; set; } 

        public List<RenderedServices>? RenderedServices { get; set; } 
    }
}