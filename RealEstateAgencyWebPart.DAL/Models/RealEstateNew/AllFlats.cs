using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class AllFlats
    {
        public AllFlats()
        {
            OldBuilFlat = new List<OldBuildingFlat>();
            NewBuilFlat = new List<NewBuildingFlat>();
            BuilFlat = new List<Flat>();
        }
        public int Id { get; set; }
        public List<OldBuildingFlat> OldBuilFlat { get; set; }
        public List<NewBuildingFlat> NewBuilFlat { get; set; }
        public List<Flat> BuilFlat { get; set; }
    }
}
