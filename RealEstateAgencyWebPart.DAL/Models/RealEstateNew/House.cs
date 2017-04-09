using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class House:RealEstate
    {
        public LivingPlacementProperties LivingPlacement { get; set; }
        public string WCPresence { get; set; }
    }
}
