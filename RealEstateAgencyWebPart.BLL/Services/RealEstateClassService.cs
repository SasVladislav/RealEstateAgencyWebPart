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
    public class RealEstateClassService: IRealEstateClassService
    {
        GenericServiceEntity<RealEstateClassOld> service;
        public RealEstateClassService()
        {
            service = new GenericServiceEntity<RealEstateClassOld>();
        }
        public IEnumerable<RealEstateClassDTO> GetAllRecordsRealEstateClassByExpression(Expression<Func<RealEstateClassDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassOld, RealEstateClassDTO>());
            Expression<Func<RealEstateClassOld, bool>> where = Mapper.Map<Expression<Func<RealEstateClassOld, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassOld, RealEstateClassDTO>());
            List<RealEstateClassDTO> RealEstateClasses = Mapper.Map<List<RealEstateClassOld>, List<RealEstateClassDTO>>(service.FindAll(where).ToList());

            return RealEstateClasses;
        }

        public IEnumerable<RealEstateClassDTO> GetAllRealEstateClasses()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassOld, RealEstateClassDTO>());
            List<RealEstateClassDTO> list = Mapper.Map<List<RealEstateClassOld>, List<RealEstateClassDTO>>(service.FindAll().ToList());

            return list;
        }
        public RealEstateClassDTO GetRealEstateClassByExpression(Expression<Func<RealEstateClassDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassOld, RealEstateClassDTO>());
            Expression<Func<RealEstateClassOld, bool>> where = Mapper.Map<Expression<Func<RealEstateClassOld, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassOld, RealEstateClassDTO>());
            RealEstateClassDTO realEstateClass = Mapper.Map<RealEstateClassOld, RealEstateClassDTO>(service.FindOne(where));

            return realEstateClass;
        }
        public RealEstateClassDTO GetRealEstateClassById(int idRealEstateClass)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassOld, RealEstateClassDTO>());
            RealEstateClassDTO realEstateClassObjectDto = Mapper.Map<RealEstateClassOld, RealEstateClassDTO>(service.FindById(idRealEstateClass));

            return realEstateClassObjectDto;
        }

        public List<RealEstateClassDTO> FilterRealEstateClasses(RealEstateClassDTO realEstateClass)
        {
            List<RealEstateClassDTO> list = Mapper.Map<List<RealEstateClassOld>, List<RealEstateClassDTO>>(service.FindAll().ToList());
            if (realEstateClass.Id != 0) list = list.Where(x => x.Id == realEstateClass.Id).ToList();
            if (realEstateClass.RealEstateClassName != null) list = list.Where(x => x.RealEstateClassName == realEstateClass.RealEstateClassName).ToList();
            return list;
        }

        public int CreateRealEstateClass(RealEstateClassDTO realEstateClassDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassDTO, RealEstateClassOld>());
            RealEstateClassOld realEstateClass = Mapper.Map<RealEstateClassDTO, RealEstateClassOld>(realEstateClassDto);
            return service.CreateItem(realEstateClass, x => x.RealEstateClassName == realEstateClass.RealEstateClassName).Id;          
        }
        public bool UpdateRealEstateClass(RealEstateClassDTO realEstateClassDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RealEstateClassDTO, RealEstateClassOld>());
            RealEstateClassOld realEstateClass = Mapper.Map<RealEstateClassDTO, RealEstateClassOld>(realEstateClassDto);

            return service.UpdateItem(realEstateClass);
        }
        public bool DeleteRealEstateClass(int idrealEstateClass)
        {
            return service.DeleteItem(idrealEstateClass);
        }
}
}
