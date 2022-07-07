using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class BreedsVM
    {
        public Species species { get; set; }
        public IEnumerable<Breed> breeds { get; set; }

        public int Id_Breed { get; set; }
        public int Id_Species { get; set; }
        public string Name { get; set; }
    }
}
