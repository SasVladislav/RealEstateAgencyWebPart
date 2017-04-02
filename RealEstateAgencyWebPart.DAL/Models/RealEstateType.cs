using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class RealEstateType
    {
        public int Id { get; set; }
        public string RealEstateTypeName { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
