using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models.ViewModels
{
    public class JournalView
    {
        public UserDTO User { get; set; }
        public RealEstateDTO RealEstate { get; set; }
        public int MyProperty { get; set; }
    }
}
