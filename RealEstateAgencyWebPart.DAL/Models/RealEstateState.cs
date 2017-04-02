using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class RealEstateState
    {
        public int Id { get; set; }
        public string RealEstateStateName { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
