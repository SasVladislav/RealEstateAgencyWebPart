using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models
{
    public class EmployeeDTO : PersonAbstractDTO
    {
        public double Salary { get; set; }
        public List<EmployeeDismissDTO> ListDismiss { get; set; }
    }
}
