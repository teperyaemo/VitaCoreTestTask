using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class Breed
    {
        [Key]
        public int Id_Breed { get; set; }
        public int Id_Species { get; set; }
        public string Name { get; set; }

        [ForeignKey("Id_Species")]
        public virtual Species? Species { get; set; }
        public List<Pet>? Pet { get; set; } 
    }
}