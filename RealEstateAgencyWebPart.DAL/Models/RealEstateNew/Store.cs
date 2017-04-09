using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class Store:RealEstate
    {
        public PlacementTerritoryProperties PlacementTerritory { get; set; }
        public string Type { get; set; }
    }
}
