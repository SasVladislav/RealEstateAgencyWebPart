using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        public int RealEstateClassId { get; set; }
        public int RealEstateTypeId { get; set; }
        public int RealEstateTypeWallId { get; set; }
        public int RealEstateStateId { get; set; }
        public double GrossArea { get; set; }
        public int NumberOfRooms { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public virtual RealEstateClass RealEstateClass { get; set; }
        public virtual RealEstateType RealEstateType { get; set; }
        public virtual RealEstateTypeWall RealEstateTypeWall { get; set; }
        public virtual RealEstateState RealEstateState { get; set; }
        public virtual ICollection<EmployeeRealEstate> EmployeeRealEstates { get; set; }
    }
}
