using System.Data.Entity;

namespace RealEstateAgencyWebPart.DAL.EF
{
    internal class RealEstateDbInitializer : DropCreateDatabaseAlways<RealEstateDbContext>
    {
        protected override void Seed(RealEstateDbContext context)
        {
            base.Seed(context);
        }
    }
}