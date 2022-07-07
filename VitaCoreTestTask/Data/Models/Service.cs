using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VitaCoreTestTask.Models
{
    public class Service
    {
        [Key]
        public int Id_Service { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public List<RenderedServices>? RenderedServices { get; set; }
    }
}