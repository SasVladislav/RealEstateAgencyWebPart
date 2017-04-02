using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class Employee:PersonAbstract
    {
        public double Salary { get; set; }
        public virtual ICollection<EmployeeDismiss> EmployeeDismisses { get; set; }
    }
}
