using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgencyWebPart.BLL.Interfaces;
using RealEstateAgencyWebPart.BLL.Models;

namespace RealEstateAgencyWebPart.View.Controllers
{
    public class RealEstateClassController
    {
        IRealEstateClassService classService;
        public RealEstateClassController(IRealEstateClassService _classService)
        {
            classService = _classService;
        }

        public void CreateClass(RealEstateClassDTO classEntity)
        {
            classService.CreateRealEstateClass(classEntity);
        }
    }
}
