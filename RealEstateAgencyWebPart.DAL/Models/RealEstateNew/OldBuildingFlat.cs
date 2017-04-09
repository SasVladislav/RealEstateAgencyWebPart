using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models.RealEstateNew
{
    public class OldBuildingFlat:LivingPlacementProperties
    {
        //public int AllFlatsId { get; set; }
        public virtual AllFlats AllFlats { get; set; }
    }
}
