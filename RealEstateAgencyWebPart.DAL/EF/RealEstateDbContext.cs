using RealEstateAgencyWebPart.DAL.Models;
using RealEstateAgencyWebPart.DAL.Models.RealEstateNew;
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
        //public DbSet<RealEstateOld> RealEstates { get; set; }
        //public DbSet<RealEstateClassOld> RealEstateClasses { get; set; }
        //public DbSet<RealEstateTypeOld> RealEstateTypes { get; set; }
        //public DbSet<RealEstateStateOld> RealEstateStates { get; set; }
        //public DbSet<RealEstateTypeWallOld> RealEstateTypeWalls { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        
        public DbSet<AllFlats> AllFlats { get; set; }
        public DbSet<BuildingsProperty> BuildingsProperties { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<GrossArea> GrossAreas { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<LivingPlacementProperties> LivingPlacementProperties { get; set; }
        public DbSet<NewBuilding> NewBuildings { get; set; }
        public DbSet<NewBuildingFlat> NewBuildingFlats { get; set; }
        public DbSet<OldBuilding> OldBuildings { get; set; }
        public DbSet<OldBuildingFlat> OldBuildingFlats { get; set; }
        //public DbSet<PlacementTerritoryProperties> PlacementTerritoryProperties { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Store> Stores { get; set; }

    }
    
}
