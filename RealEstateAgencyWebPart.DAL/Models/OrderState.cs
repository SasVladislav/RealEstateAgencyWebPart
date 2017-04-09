using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class OrderState
    {
        public int Id { get; set; }
        public string JournalStateOrderName { get; set; }
        public virtual ICollection<Orders> Journals { get; set; }
    }
}
