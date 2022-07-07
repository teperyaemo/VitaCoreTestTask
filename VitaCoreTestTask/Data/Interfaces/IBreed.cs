using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IBreed
    {
        public IEnumerable<Breed> Breeds { get; }
        public IEnumerable<Breed> BreedsBySpeciesId(int id);
    }
}
