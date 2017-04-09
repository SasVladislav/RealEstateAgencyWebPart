using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class Flat:RealEstate
    {
        public LivingPlacementProperties LivingPlacement { get; set; }
        public int FlatNumber { get; set; }
        //public int AllFlatsId { get; set; }
        public virtual AllFlats AllFlats { get; set; }
    }
}
