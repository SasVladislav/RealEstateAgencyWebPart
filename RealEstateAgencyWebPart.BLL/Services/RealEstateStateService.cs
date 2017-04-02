using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgencyWebPart.DAL.Models;
using RealEstateAgencyWebPart.DAL.RepositoryService;
using RealEstateAgencyWebPart.BLL.GenericService;
using System.Linq.Expressions;
using RealEstateAgencyWebPart.BLL.Interfaces;
using AutoMapper;
using RealEstateAgencyWebPart.BLL.Models;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class RealEstateStateService: IRealEstateStateService
    {
        GenericServiceEntity<RealEstateState> service = new GenericServiceEntity<RealEstateState>();
        public IEnumerable<RealEstateStateDTO> GetAllRecordsRealEstateStateByExpression(Expression<Func<RealEstateStateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateState, RealEstateStateDTO>());
            Expression<Func<RealEstateState, bool>> where = Mapper.Map<Expression<Func<RealEstateState, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateState, RealEstateStateDTO>());
            List<RealEstateStateDTO> RealEstateStates = Mapper.Map<List<RealEstateState>, List<RealEstateStateDTO>>(service.FindAll(where).ToList());

            return RealEstateStates;
        }

        public IEnumerable<RealEstateStateDTO> GetAllRealEstateStates()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateState, RealEstateStateDTO>());
            List<RealEstateStateDTO> list = Mapper.Map<List<RealEstateState>, List<RealEstateStateDTO>>(service.FindAll().ToList());

            return list;
        }
        public RealEstateStateDTO GetRealEstateStateByExpression(Expression<Func<RealEstateStateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateState, RealEstateStateDTO>());
            Expression<Func<RealEstateState, bool>> where = Mapper.Map<Expression<Func<RealEstateState, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateState, RealEstateStateDTO>());
            RealEstateStateDTO realEstateState = Mapper.Map<RealEstateState, RealEstateStateDTO>(service.FindOne(where));

            return realEstateState;
        }
        public RealEstateStateDTO GetRealEstateStateById(int idRealEstateState)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateState, RealEstateStateDTO>());
            RealEstateStateDTO realEstateStateObjectDto = Mapper.Map<RealEstateState, RealEstateStateDTO>(service.FindById(idRealEstateState));

            return realEstateStateObjectDto;
        }

        public List<RealEstateStateDTO> FilterRealEstateStates(RealEstateStateDTO realEstateState)
        {
            List<RealEstateStateDTO> list = Mapper.Map<List<RealEstateState>, List<RealEstateStateDTO>>(service.FindAll().ToList());
            if (realEstateState.Id != 0) list = list.Where(x => x.Id == realEstateState.Id).ToList();
            if (realEstateState.RealEstateStateName != null) list = list.Where(x => x.RealEstateStateName == realEstateState.RealEstateStateName).ToList();
            return list;
        }

        public int CreateRealEstateState(RealEstateStateDTO realEstateStateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateStateDTO, RealEstateState>());
            RealEstateState realEstateState = Mapper.Map<RealEstateStateDTO, RealEstateState>(realEstateStateDto);

            return service.CreateItem(realEstateState, x => x.RealEstateStateName == realEstateState.RealEstateStateName).Id;
        }
        public bool UpdateRealEstateState(RealEstateStateDTO realEstateStateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateStateDTO, RealEstateState>());
            RealEstateState realEstateState = Mapper.Map<RealEstateStateDTO, RealEstateState>(realEstateStateDto);

            return service.UpdateItem(realEstateState);
        }
        public bool DeleteRealEstateState(int idRealEstateState)
        {
            return service.DeleteItem(idRealEstateState);
        }
    }
}
