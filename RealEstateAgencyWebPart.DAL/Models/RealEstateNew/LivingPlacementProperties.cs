using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public abstract class LivingPlacementProperties:PlacementTerritoryProperties
    {
        public int RoomsCount { get; set; }
        public string Repairs { get; set; }
        public string WCType { get; set; }
    }
}
