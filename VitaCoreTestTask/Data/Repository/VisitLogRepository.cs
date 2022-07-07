using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class VisitLogRepository : IVisitLog
    {
        private readonly VCappContext _context;

        public VisitLogRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public IEnumerable<VisitLog> visitLogs => _context.VisitLogs.Include(c => c.PetOwner).Include(u => u.Pet);

        public VisitLog GetVisitLog(int id) => _context.VisitLogs.Include(c => c.PetOwner).Include(u => u.Pet).First(p => p.Id_VisitLog == id);
    }
}
