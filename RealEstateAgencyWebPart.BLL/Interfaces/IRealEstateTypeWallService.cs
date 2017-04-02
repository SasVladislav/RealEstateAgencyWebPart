using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IRealEstateTypeWallService
    {
        IEnumerable<RealEstateTypeWallDTO> GetAllRealEstateTypesWall();
        RealEstateTypeWallDTO GetRealEstateTypeWallById(int idRealEstateTypeWall);
        List<RealEstateTypeWallDTO> GetAllRecordsRealEstateTypeWallByExpression(Expression<Func<RealEstateTypeWallDTO, bool>> whereDTO = null);
        RealEstateTypeWallDTO GetRealEstateTypeWallByExpression(Expression<Func<RealEstateTypeWallDTO, bool>> whereDTO = null);
        List<RealEstateTypeWallDTO> FilterRealEstateTypeWalls(RealEstateTypeWallDTO realEstateTypeWall);
        int CreateRealEstateTypeWall(RealEstateTypeWallDTO realEstateTypeWallDto);
        bool UpdateRealEstateTypeWall(RealEstateTypeWallDTO realEstateTypeWallDto);
        bool DeleteRealEstateTypeWall(int idRealEstateTypeWall);
    }
}
