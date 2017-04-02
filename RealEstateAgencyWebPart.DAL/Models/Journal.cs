using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.DAL.Models
{
    public class Journal
    {
        public int Id { get; set; }
        
        public int PersonId { get; set; }
        public int RealEstateId { get; set; }
        public DateTime DateViewRealEstate { get; set; }
        public int JournalStateOrderId { get; set; }
        public DateTime DateRecord { get; set; }
        //[ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual RealEstate RealEstate { get; set; }
        public virtual JournalStateOrder JournalStateOrder { get; set; }
    }
}
