using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Models
{
    public class RealEstateView
    {
        public int Id { get; set; }
        public string RealEstateClassName { get; set; }
        public string RealEstateTypeName { get; set; }
        public string RealEstateTypeWallName { get; set; }
        public string RealEstateStateName { get; set; }
        public double GrossArea { get; set; }
        public int NumberOfRooms { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
