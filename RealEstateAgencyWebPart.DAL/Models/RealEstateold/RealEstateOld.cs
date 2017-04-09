using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class RealEstateOld
    {
        public int Id { get; set; }
        public int RealEstateClassId { get; set; }
        public int RealEstateTypeId { get; set; }
        public int RealEstateTypeWallId { get; set; }
        public int RealEstateStateId { get; set; }
        public double GrossArea { get; set; }
        public int NumberOfRooms { get; set; }
        public int EmployeeId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public virtual RealEstateClassOld RealEstateClass { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual RealEstateTypeOld RealEstateType { get; set; }
        public virtual RealEstateTypeWallOld RealEstateTypeWall { get; set; }
        public virtual RealEstateStateOld RealEstateState { get; set; }
    }
}
