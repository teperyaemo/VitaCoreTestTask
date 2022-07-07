using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IService
    {
        public IEnumerable<Service> services { get; }
    }
}
