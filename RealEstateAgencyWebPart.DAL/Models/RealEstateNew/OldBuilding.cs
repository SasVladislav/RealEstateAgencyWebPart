using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class OldBuilding:BuildingsProperty
    {
        public OldBuilding()
        {
            Flats = new List<OldBuildingFlat>();
        }
        public List<OldBuildingFlat> Flats { get; set; }
    }
}
