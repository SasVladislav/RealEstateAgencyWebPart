using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class PlacementTerritoryProperties
    {
        public int Id { get; set; }
        public GrossArea Area { get; set; }
        public string TypeWall { get; set; }
        public double Price { get; set; }
        public double PriceForM2 { get; set; }
    }
}
