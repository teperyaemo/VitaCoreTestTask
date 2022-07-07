using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IRenderedService
    {
        public IEnumerable<RenderedServices> GetServicesByVisitLogId(int id);
    }
}
