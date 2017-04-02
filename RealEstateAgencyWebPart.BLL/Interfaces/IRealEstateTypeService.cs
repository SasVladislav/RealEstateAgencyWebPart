using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IRealEstateTypeService
    {
        IEnumerable<RealEstateTypeDTO> GetAllRealEstateTypes();
        RealEstateTypeDTO GetRealEstateTypeById(int idRealEstateType);
        IEnumerable<RealEstateTypeDTO> GetAllRecordsRealEstateTypeByExpression(Expression<Func<RealEstateTypeDTO, bool>> whereDTO = null);
        RealEstateTypeDTO GetRealEstateTypeByExpression(Expression<Func<RealEstateTypeDTO, bool>> whereDTO = null);
        List<RealEstateTypeDTO> FilterRealEstateTypes(RealEstateTypeDTO realEstateType);
        int CreateRealEstateType(RealEstateTypeDTO realEstateTypeDto);
        bool UpdateRealEstateType(RealEstateTypeDTO realEstateTypeDto);
        bool DeleteRealEstateType(int idRealEstateType);
    }
}
