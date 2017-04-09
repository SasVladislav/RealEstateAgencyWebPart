using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public abstract class BuildingsProperty:RealEstate
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public GrossArea MinRoomsGrossArea { get; set; }
        public GrossArea MaxRoomsGrossArea { get; set; }
        public bool Parking { get; set; }
        public bool Lift { get; set; }
        public string BuildingClass { get; set; }
    }
}
