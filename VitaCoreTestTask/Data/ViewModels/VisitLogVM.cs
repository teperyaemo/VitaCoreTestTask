using System.Collections.Generic;
using VitaCoreTestTask.Models;


namespace VitaCoreTestTask.Data.ViewModels
{
    public class VisitLogVM
    {
        public string SearchString { get; set; }
        public IEnumerable<VisitLog> visitLogs { get; set; }
    }
}
