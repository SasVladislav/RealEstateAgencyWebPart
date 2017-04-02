using RealEstateAgencyWebPart.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.EF
{
    public class RealEstateDbContext:DbContext
    {
        public RealEstateDbContext() : base("RealEstateConnectionString")
        {
            Database.SetInitializer<RealEstateDbContext>(new RealEstateDbInitializer());
        }

        public DbSet<PersonAbstract> Persons { get; set; }
        public DbSet<PersonAccessRole> AccessRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeDismiss> EmployeeDismisses { get; set; }
        public DbSet<EmployeeDismissState> EmployeeDismissStatuses { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstateClass> RealEstateClasses { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
        public DbSet<RealEstateState> RealEstateStates { get; set; }
        public DbSet<RealEstateTypeWall> RealEstateTypeWalls { get; set; }
        public DbSet<EmployeeRealEstate> EmployeesRealEstates { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalStateOrder> JournalStateOrders { get; set; }

        
    }
    
}
