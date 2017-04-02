using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class EmployeeDismissState
    {
        public int Id { get; set; }
        public string EmployeeDismissStateName { get; set; }
        public virtual ICollection<EmployeeDismiss> EmployeeDismisses { get; set; }
    }
}
