using System.Collections.Generic;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.ViewModels
{
    public class VisitLogReviewVM
    {
        public VisitLog VisitLog { get; set; }
        public IEnumerable<RenderedServices> RenderedServices { get; set; }
    }
}
