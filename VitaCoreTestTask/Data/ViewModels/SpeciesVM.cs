using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class SpeciesVM
    {
        public int Id_Species { get; set; }
        public string Name { get; set; }

        public IEnumerable<Species> species { get; set; }
    }
}
