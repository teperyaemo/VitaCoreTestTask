using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class Species
    {
        [Key]
        public int Id_Species { get; set; }
        public string Name { get; set; }

        public List<Breed>? Breeds { get; set; }
        public List<Pet>? Pets { get; set; }
    }
}