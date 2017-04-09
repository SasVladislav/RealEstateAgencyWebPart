using RealEstateAgencyWebPart.DAL;
using RealEstateAgencyWebPart.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RealEstateAgencyWebPart.BLL.Services;
using RealEstateAgencyWebPart.BLL.Models;

namespace RealEstateAgencyWebPart.View
{
    class Program
    {
        static RealEstateStateDTO CreateRealEstateState()
        {

            return new RealEstateStateDTO()
            {
                RealEstateStateName = "Free"
            };
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());


           // Console.WriteLine(new RealEstateClassService().GetAllRecordsRealEstateClassByExpression(x => x.RealEstateClassName == "Okey").FirstOrDefault().RealEstateClassName);
            using (var ctx = new RealEstateDbContext())
            {
                using (var writer = new XmlTextWriter($@"{AppDomain.CurrentDomain.BaseDirectory}\RealEstateAgencyModel.edmx", Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }
            Console.WriteLine(new TestDb().ClassName());
            //int stateid = new RealEstateStateService().CreateRealEstateState(CreateRealEstateState());
            //Console.WriteLine(new RealEstateStateService().GetRealEstateStateById(stateid).RealEstateStateName);
            //new RealEstateStateService().DeleteRealEstateState(stateid);
            //var item = new RealEstateStateService().GetRealEstateStateById(stateid);
            //Console.WriteLine(item == null?"Объект удален": item.RealEstateStateName);
            Console.ReadKey();
        }
    }
}
