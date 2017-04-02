using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class EmployeeDismiss
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int idEmployee { get; set; }
        public string EmploymentDate { get; set; }
        public string DismissDate { get; set; }
        public int idEmployeeDismissState { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual EmployeeDismissState EmployeeDismissState { get; set; }
    }
}
