using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models
{
    public class EmployeeRealEstateDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RealEstateId { get; set; }
    }
}
