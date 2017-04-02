using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IRealEstateClassService
    {
        IEnumerable<RealEstateClassDTO> GetAllRealEstateClasses();
        RealEstateClassDTO GetRealEstateClassById(int idRealEstateClass);
        IEnumerable<RealEstateClassDTO> GetAllRecordsRealEstateClassByExpression(Expression<Func<RealEstateClassDTO, bool>> whereDTO = null);
        RealEstateClassDTO GetRealEstateClassByExpression(Expression<Func<RealEstateClassDTO, bool>> whereDTO = null);
        List<RealEstateClassDTO> FilterRealEstateClasses(RealEstateClassDTO realEstateClass);
        int CreateRealEstateClass(RealEstateClassDTO realEstateClassDto);
        bool UpdateRealEstateClass(RealEstateClassDTO realEstateClassDto);
        bool DeleteRealEstateClass(int idrealEstateClass);
    }
}
