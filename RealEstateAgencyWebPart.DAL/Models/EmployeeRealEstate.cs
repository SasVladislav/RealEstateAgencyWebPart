using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class EmployeeRealEstate
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public int RealEstateId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual RealEstate RealEstate { get; set; }

    }
}
