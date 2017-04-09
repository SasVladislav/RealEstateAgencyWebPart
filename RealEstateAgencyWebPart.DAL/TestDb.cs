using RealEstateAgencyWebPart.DAL.EF;
using RealEstateAgencyWebPart.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL
{
    public class TestDb
    {
        public TestDb()
        {
            using (var dbConnection = new RealEstateDbContext())
            {
                dbConnection.OrderStates.Add(new OrderState() { JournalStateOrderName="Okey"});
                dbConnection.SaveChanges();

            }
        }
        public string ClassName()
        {
            using (var dbConnection = new RealEstateDbContext())
            {
                return dbConnection.OrderStates.FirstOrDefault().JournalStateOrderName;

            }
        }
    }
}
