using Microsoft.EntityFrameworkCore;
using VitaCoreTestTask.Models;

namespace VitaCoreTestTask
{
    public class VCappContext : DbContext
    {
        public VCappContext(DbContextOptions<VCappContext> options) : base(options)
        { }

        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<PetVaccination> PetVaccinations { get; set; }
        public DbSet<RenderedServices> RenderedServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VisitLog> VisitLogs { get; set; }
    }
}