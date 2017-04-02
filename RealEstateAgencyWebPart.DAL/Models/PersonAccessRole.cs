using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class PersonAccessRole
    {
        public int Id { get; set; }
        public string PersonAccessRoleName { get; set; }
        public virtual ICollection<PersonAbstract> PersonsAbstract { get; set; }
    }
}
