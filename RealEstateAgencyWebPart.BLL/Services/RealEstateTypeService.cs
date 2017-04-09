using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgencyWebPart.DAL.Models;
using RealEstateAgencyWebPart.DAL.RepositoryService;
using RealEstateAgencyWebPart.BLL.GenericService;
using System.Linq.Expressions;
using AutoMapper;
using RealEstateAgencyWebPart.BLL.Models;
using RealEstateAgencyWebPart.BLL.Interfaces;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class RealEstateTypeService:IRealEstateTypeService
    {
        GenericServiceEntity<RealEstateTypeOld> service = new GenericServiceEntity<RealEstateTypeOld>();
        public IEnumerable<RealEstateTypeDTO> GetAllRecordsRealEstateTypeByExpression(Expression<Func<RealEstateTypeDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeOld, RealEstateTypeDTO>());
            Expression<Func<RealEstateTypeOld, bool>> where = Mapper.Map<Expression<Func<RealEstateTypeOld, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeOld, RealEstateTypeDTO>());
            List<RealEstateTypeDTO> RealEstateTypes = Mapper.Map<List<RealEstateTypeOld>, List<RealEstateTypeDTO>>(service.FindAll(where).ToList());

            return RealEstateTypes;
        }

        public IEnumerable<RealEstateTypeDTO> GetAllRealEstateTypes()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeOld, RealEstateTypeDTO>());
            List<RealEstateTypeDTO> list = Mapper.Map<List<RealEstateTypeOld>, List<RealEstateTypeDTO>>(service.FindAll().ToList());

            return list;
        }
        public RealEstateTypeDTO GetRealEstateTypeByExpression(Expression<Func<RealEstateTypeDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeOld, RealEstateTypeDTO>());
            Expression<Func<RealEstateTypeOld, bool>> where = Mapper.Map<Expression<Func<RealEstateTypeOld, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeOld, RealEstateTypeDTO>());
            RealEstateTypeDTO realEstateType = Mapper.Map<RealEstateTypeOld, RealEstateTypeDTO>(service.FindOne(where));

            return realEstateType;
        }
        public RealEstateTypeDTO GetRealEstateTypeById(int idRealEstateType)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeOld, RealEstateTypeDTO>());
            RealEstateTypeDTO realEstateTypeObjectDto = Mapper.Map<RealEstateTypeOld, RealEstateTypeDTO>(service.FindById(idRealEstateType));

            return realEstateTypeObjectDto;
        }

        public List<RealEstateTypeDTO> FilterRealEstateTypes(RealEstateTypeDTO realEstateType)
        {
            List<RealEstateTypeDTO> list = Mapper.Map<List<RealEstateTypeOld>, List<RealEstateTypeDTO>>(service.FindAll().ToList());
            if (realEstateType.Id != 0) list = list.Where(x => x.Id == realEstateType.Id).ToList();
            if (realEstateType.RealEstateTypeName != null) list = list.Where(x => x.RealEstateTypeName == realEstateType.RealEstateTypeName).ToList();
            return list;
        }

        public int CreateRealEstateType(RealEstateTypeDTO realEstateTypeDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeDTO, RealEstateTypeOld>());
            RealEstateTypeOld realEstateType = Mapper.Map<RealEstateTypeDTO, RealEstateTypeOld>(realEstateTypeDto);

            return service.CreateItem(realEstateType, x => x.RealEstateTypeName == realEstateType.RealEstateTypeName).Id;
        }
        public bool UpdateRealEstateType(RealEstateTypeDTO realEstateTypeDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeDTO, RealEstateTypeOld>());
            RealEstateTypeOld realEstateType = Mapper.Map<RealEstateTypeDTO, RealEstateTypeOld>(realEstateTypeDto);

            return service.UpdateItem(realEstateType);
        }
        public bool DeleteRealEstateType(int idRealEstateType)
        {
            return service.DeleteItem(idRealEstateType);
        }
    }
}
