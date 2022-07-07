using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface ISpecies
    {
        public Species GetSpecies(int id);
        public IEnumerable<Species> Species { get; }
    }
}
