using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IRealEstateStateService
    {
        IEnumerable<RealEstateStateDTO> GetAllRealEstateStates();
        RealEstateStateDTO GetRealEstateStateById(int idRealEstateState);
        IEnumerable<RealEstateStateDTO> GetAllRecordsRealEstateStateByExpression(Expression<Func<RealEstateStateDTO, bool>> whereDTO = null);
        RealEstateStateDTO GetRealEstateStateByExpression(Expression<Func<RealEstateStateDTO, bool>> whereDTO = null);
        List<RealEstateStateDTO> FilterRealEstateStates(RealEstateStateDTO realEstateState);
        int CreateRealEstateState(RealEstateStateDTO realEstateStateDto);
        bool UpdateRealEstateState(RealEstateStateDTO realEstateStateDto);
        bool DeleteRealEstateState(int idRealEstateState);
    }
}
