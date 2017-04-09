using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public abstract class RealEstate
    {
        public int RealestateId { get; set; }
        public string ReferencePoint { get; set; }
        public int Levels { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
