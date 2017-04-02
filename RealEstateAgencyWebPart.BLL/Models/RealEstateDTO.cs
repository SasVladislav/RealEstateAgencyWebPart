using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models
{
    public class RealEstateDTO
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
    }
}
