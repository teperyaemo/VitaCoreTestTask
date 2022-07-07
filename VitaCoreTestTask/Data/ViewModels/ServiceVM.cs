using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class ServiceVM
    {
        public int Id_Service { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public IEnumerable<Service> services { get; set; }
    }
}
