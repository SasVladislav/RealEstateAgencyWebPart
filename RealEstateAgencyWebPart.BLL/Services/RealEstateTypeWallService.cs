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
    public class RealEstateTypeWallService: IRealEstateTypeWallService
    {
        GenericServiceEntity<RealEstateTypeWall> service = new GenericServiceEntity<RealEstateTypeWall>();
        public List<RealEstateTypeWallDTO> GetAllRecordsRealEstateTypeWallByExpression(Expression<Func<RealEstateTypeWallDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWall, RealEstateTypeWallDTO>());
            Expression<Func<RealEstateTypeWall, bool>> where = Mapper.Map<Expression<Func<RealEstateTypeWall, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWall, RealEstateTypeWallDTO>());
            List<RealEstateTypeWallDTO> RealEstateTypeWalls = Mapper.Map<List<RealEstateTypeWall>, List<RealEstateTypeWallDTO>>(service.FindAll(where).ToList());

            return RealEstateTypeWalls;
        }

        public IEnumerable<RealEstateTypeWallDTO> GetAllRealEstateTypesWall()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWall, RealEstateTypeWallDTO>());
            List<RealEstateTypeWallDTO> list = Mapper.Map<List<RealEstateTypeWall>, List<RealEstateTypeWallDTO>>(service.FindAll().ToList());

            return list;
        }
        public RealEstateTypeWallDTO GetRealEstateTypeWallByExpression(Expression<Func<RealEstateTypeWallDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWall, RealEstateTypeWallDTO>());
            Expression<Func<RealEstateTypeWall, bool>> where = Mapper.Map<Expression<Func<RealEstateTypeWall, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWall, RealEstateTypeWallDTO>());
            RealEstateTypeWallDTO realEstateTypeWall = Mapper.Map<RealEstateTypeWall, RealEstateTypeWallDTO>(service.FindOne(where));

            return realEstateTypeWall;
        }
        public RealEstateTypeWallDTO GetRealEstateTypeWallById(int idRealEstateTypeWall)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWall, RealEstateTypeWallDTO>());
            RealEstateTypeWallDTO employeeRealEstateObjectDto = Mapper.Map<RealEstateTypeWall, RealEstateTypeWallDTO>(service.FindById(idRealEstateTypeWall));

            return employeeRealEstateObjectDto;
        }

        public List<RealEstateTypeWallDTO> FilterRealEstateTypeWalls(RealEstateTypeWallDTO realEstateTypeWall)
        {
            List<RealEstateTypeWallDTO> list = Mapper.Map<List<RealEstateTypeWall>, List<RealEstateTypeWallDTO>>(service.FindAll().ToList());
            if (realEstateTypeWall.Id != 0) list = list.Where(x => x.Id == realEstateTypeWall.Id).ToList();
            if (realEstateTypeWall.RealEstateTypeWallName != null) list = list.Where(x => x.RealEstateTypeWallName == realEstateTypeWall.RealEstateTypeWallName).ToList();
            return list;
        }

        public int CreateRealEstateTypeWall(RealEstateTypeWallDTO realEstateTypeWallDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWallDTO, RealEstateTypeWall>());
            RealEstateTypeWall realEstateTypeWall = Mapper.Map<RealEstateTypeWallDTO, RealEstateTypeWall>(realEstateTypeWallDto);

            return service.CreateItem(realEstateTypeWall, x => x.RealEstateTypeWallName == realEstateTypeWall.RealEstateTypeWallName).Id;
        }
        public bool UpdateRealEstateTypeWall(RealEstateTypeWallDTO realEstateTypeWallDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateTypeWallDTO, RealEstateTypeWall>());
            RealEstateTypeWall realEstateTypeWall = Mapper.Map<RealEstateTypeWallDTO, RealEstateTypeWall>(realEstateTypeWallDto);

            return service.UpdateItem(realEstateTypeWall);
        }
        public bool DeleteRealEstateTypeWall(int idRealEstateTypeWall)
        {
            return service.DeleteItem(idRealEstateTypeWall);
        }
    }
}
