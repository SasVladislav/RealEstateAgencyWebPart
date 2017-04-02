using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models.ViewModels
{
    public class EmployeeRealEstateView
    {
        public EmployeeDTO Employee { get; set; }
        public List<RealEstateDTO> RealEstates { get; set; }
    }
}
