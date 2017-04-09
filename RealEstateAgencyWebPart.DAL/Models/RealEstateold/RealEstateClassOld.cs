using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class RealEstateClassOld
    {
        public int Id { get; set; }
        public string RealEstateClassName { get; set; }
        public virtual ICollection<RealEstateOld> RealEstates { get; set; }
    }
}
