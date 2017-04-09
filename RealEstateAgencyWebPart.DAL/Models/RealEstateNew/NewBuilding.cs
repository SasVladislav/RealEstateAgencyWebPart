using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class NewBuilding:BuildingsProperty
    {
        public NewBuilding()
        {
            Flats = new List<NewBuildingFlat>();
        }
        public string Deadline { get; set; }
        public List<NewBuildingFlat> Flats { get; set; }
    }
}
