using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IRealEstateService
    {
        IEnumerable<RealEstateDTO> GetAllRealEstates();
        RealEstateDTO GetRealEstateById(int idRealEstate);
        IEnumerable<RealEstateDTO> GetAllRecordsRealEstateByExpression(Expression<Func<RealEstateDTO, bool>> whereDTO = null);
        RealEstateDTO GetRealEstateByExpression(Expression<Func<RealEstateDTO, bool>> whereDTO = null);
        List<RealEstateDTO> FilterRealEstates(RealEstateDTO realEstate);
        int CreateRealEstate(RealEstateDTO realEstateDto);
        bool UpdateRealEstate(RealEstateDTO realEstateDto);
        bool DeleteRealEstate(int idRealEstate);
    }
}
