using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class RealEstateClass
    {
        public int Id { get; set; }
        public string RealEstateClassName { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
