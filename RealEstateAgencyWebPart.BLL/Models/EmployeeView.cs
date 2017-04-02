using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PersonAccessRoleName { get; set; }
        public string EmploymentDate { get; set; }
        public string DismissDate { get; set; }
        public string EmployeeDismissStateName { get; set; }
    }
}
