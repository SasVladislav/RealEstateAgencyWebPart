using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgencyWebPart.DAL.Models;
using RealEstateAgencyWebPart.DAL.RepositoryService;
using RealEstateAgencyWebPart.BLL.GenericService;
using RealEstateAgencyWebPart.BLL.Interfaces;
using AutoMapper;
using RealEstateAgencyWebPart.BLL.Models;
using System.Linq.Expressions;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class EmployeeDismissStateService: IEmployeeDismissStateService
    {
        GenericServiceEntity<EmployeeDismissState> service = new GenericServiceEntity<EmployeeDismissState>();

        public IEnumerable<EmployeeDismissStateDTO> GetAllEmployeeDismissStateByExpression(Expression<Func<EmployeeDismissStateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissState, EmployeeDismissStateDTO>());
            Expression<Func<EmployeeDismissState, bool>> where = Mapper.Map<Expression<Func<EmployeeDismissState, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissStateDTO>());
            List<EmployeeDismissStateDTO> employeeDismissStates = Mapper.Map<List<EmployeeDismissState>, List<EmployeeDismissStateDTO>>(service.FindAll(where).ToList());

            return employeeDismissStates;
        }

        public IEnumerable<EmployeeDismissStateDTO> GetAllEmployeeDismissStates()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissState, EmployeeDismissStateDTO>());
            List<EmployeeDismissStateDTO> list = Mapper.Map<List<EmployeeDismissState>, List<EmployeeDismissStateDTO>>(service.FindAll().ToList());

            return list;
        }       

        public EmployeeDismissStateDTO GetEmployeeDismissStateByExpression(Expression<Func<EmployeeDismissStateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissState, EmployeeDismissStateDTO>());
            Expression<Func<EmployeeDismissState, bool>> where = Mapper.Map<Expression<Func<EmployeeDismissState, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissState, EmployeeDismissStateDTO>());
            EmployeeDismissStateDTO employeeDismissState = Mapper.Map<EmployeeDismissState, EmployeeDismissStateDTO>(service.FindOne(where));

            return employeeDismissState;
        }

        public EmployeeDismissStateDTO GetEmployeeDismissStateById(int idDismissState)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissState, EmployeeDismissStateDTO>());
            EmployeeDismissStateDTO employeeDismissStateDto = Mapper.Map<EmployeeDismissState, EmployeeDismissStateDTO>(service.FindById(idDismissState));

            return employeeDismissStateDto;
        }

        public List<EmployeeDismissStateDTO> FilterEmployeeDismissStates(EmployeeDismissStateDTO employeeDismissState)
        {
            List<EmployeeDismissStateDTO> list = Mapper.Map<List<EmployeeDismissState>, List<EmployeeDismissStateDTO>>(service.FindAll().ToList());
            if (employeeDismissState.Id != 0) list = list.Where(x => x.Id == employeeDismissState.Id).ToList();
            if (employeeDismissState.EmployeeDismissStateName != null) list = list.Where(x => x.EmployeeDismissStateName == employeeDismissState.EmployeeDismissStateName).ToList();            
            return list;
        }

        public int CreateEmployeeDismissState(EmployeeDismissStateDTO employeeDismissStateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissStateDTO, EmployeeDismissState>());
            EmployeeDismissState employeeDismissState = Mapper.Map<EmployeeDismissStateDTO, EmployeeDismissState>(employeeDismissStateDto);

            return service.CreateItem(employeeDismissState, x => x.EmployeeDismissStateName == employeeDismissState.EmployeeDismissStateName).Id;
        }
        public bool UpdateEmployeeDismissState(EmployeeDismissStateDTO employeeDismissStateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissStateDTO, EmployeeDismissState>());
            EmployeeDismissState employeeDismissState = Mapper.Map<EmployeeDismissStateDTO, EmployeeDismissState>(employeeDismissStateDto);

            return service.UpdateItem(employeeDismissState);
        }
        public bool DeleteEmployeeDismissState(int idDismissState)
        {
            return service.DeleteItem(idDismissState);
        }
    }
}
