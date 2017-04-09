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
    public class RealEstateService: IRealEstateService
    {
        GenericServiceEntity<RealEstateOld> service = new GenericServiceEntity<RealEstateOld>();

        public IEnumerable<RealEstateDTO> GetAllRecordsRealEstateByExpression(Expression<Func<RealEstateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateOld, RealEstateDTO>());
            Expression<Func<RealEstateOld, bool>> where = Mapper.Map<Expression<Func<RealEstateOld, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateOld, RealEstateDTO>());
            List<RealEstateDTO> RealEstates = Mapper.Map<List<RealEstateOld>, List<RealEstateDTO>>(service.FindAll(where).ToList());

            return RealEstates;
        }

        public IEnumerable<RealEstateDTO> GetAllRealEstates()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateOld, RealEstateDTO>());
            List<RealEstateDTO> list = Mapper.Map<List<RealEstateOld>, List<RealEstateDTO>>(service.FindAll().ToList());

            return list;
        }
        public RealEstateDTO GetRealEstateByExpression(Expression<Func<RealEstateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateOld, RealEstateDTO>());
            Expression<Func<RealEstateOld, bool>> where = Mapper.Map<Expression<Func<RealEstateOld, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateOld, RealEstateDTO>());
            RealEstateDTO realEstate = Mapper.Map<RealEstateOld, RealEstateDTO>(service.FindOne(where));

            return realEstate;
        }
        public RealEstateDTO GetRealEstateById(int idRealEstate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateOld, RealEstateDTO>());
            RealEstateDTO realEstateObjectDto = Mapper.Map<RealEstateOld, RealEstateDTO>(service.FindById(idRealEstate));

            return realEstateObjectDto;
        }

        public List<RealEstateDTO> FilterRealEstates(RealEstateDTO realEstate)
        {
            List<RealEstateDTO> list = Mapper.Map<List<RealEstateOld>, List<RealEstateDTO>>(service.FindAll().ToList());
            if (realEstate.Id != 0) list = list.Where(x => x.Id == realEstate.Id).ToList();
            if (realEstate.RealEstateClassId != 0) list = list.Where(x => x.RealEstateClassId == realEstate.RealEstateClassId).ToList();
            if (realEstate.RealEstateStateId != 0) list = list.Where(x => x.RealEstateStateId == realEstate.RealEstateStateId).ToList();
            if (realEstate.RealEstateTypeId != 0) list = list.Where(x => x.RealEstateTypeId == realEstate.RealEstateTypeId).ToList();
            if (realEstate.RealEstateTypeWallId != 0) list = list.Where(x => x.RealEstateTypeWallId == realEstate.RealEstateTypeWallId).ToList();
            return list;
        }

        public int CreateRealEstate(RealEstateDTO realEstateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateDTO, RealEstateOld>());
            RealEstateOld realEstate = Mapper.Map<RealEstateDTO, RealEstateOld>(realEstateDto);

            return service.CreateItem(realEstate, x => x.GrossArea == realEstate.GrossArea && x.NumberOfRooms == realEstate.NumberOfRooms &&
            x.RealEstateClassId == realEstate.RealEstateClassId && x.RealEstateTypeWallId == realEstate.RealEstateTypeWallId&&
            x.RealEstateTypeId == realEstate.RealEstateTypeId).Id;
        }
        public bool UpdateRealEstate(RealEstateDTO realEstateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateDTO, RealEstateOld>());
            RealEstateOld realEstate = Mapper.Map<RealEstateDTO, RealEstateOld>(realEstateDto);

            return service.UpdateItem(realEstate);
        }
        public bool DeleteRealEstate(int idRealEstate)
        {
            return service.DeleteItem(idRealEstate);
        }
    }
}
