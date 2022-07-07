using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask.Data.Repository
{
    public class RenderedServiceRepository : IRenderedService
    {
        private readonly VCappContext _context;

        public RenderedServiceRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public IEnumerable<RenderedServices> GetServicesByVisitLogId(int id) => _context.RenderedServices
            .Include(p=>p.Employee).Include(c=>c.Service).Where(u=>u.Id_VisitLog == id);
    }
}
