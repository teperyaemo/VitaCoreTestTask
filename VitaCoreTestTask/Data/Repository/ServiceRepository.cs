using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;


namespace VitaCoreTestTask.Data.Repository
{
    public class ServiceRepository : IService
    {
        private readonly VCappContext _context;

        public ServiceRepository(VCappContext VCappContext)
        {
            _context = VCappContext;
        }

        public IEnumerable<Service> services => _context.Services;
    }
}
