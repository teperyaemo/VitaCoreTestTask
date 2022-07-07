using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Interfaces
{
    public interface IVisitLog
    {
        public VisitLog GetVisitLog(int id);
        public IEnumerable<VisitLog> visitLogs { get;}
    }
}
