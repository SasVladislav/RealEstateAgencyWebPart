using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models
{
    public class JournalDTO
    {
        public int Id { get; set; }
        
        public int PersonId { get; set; }
        public int EmployeeRealEstateId { get; set; }
        public DateTime DateViewRealEstate { get; set; }
        public int JournalStateOrderId { get; set; }
        public DateTime DateRecord { get; set; }

        public int? RealEstateId { get; set; }
        public UserDTO UserDto { get; set; }
        public RealEstateDTO RealEstateDto { get; set; }
    }
}
