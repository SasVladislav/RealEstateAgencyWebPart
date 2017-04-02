using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace RealEstateAgencyWebPart.BLL.Models
{
    public class EmployeeDismissDTO
    {
        public int Id { get; set; }
        public int idEmployee { get; set; }
        public string EmploymentDate { get; set; }
        public string DismissDate { get; set; }
        public int idEmployeeDismissState { get; set; }
    }
}
