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
using RealEstateAgencyWebPart.BLL.Models.ViewModels;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class EmployeeRealEstateService: IEmployeeRealEstateService
    {
        GenericServiceEntity<EmployeeRealEstate> service = new GenericServiceEntity<EmployeeRealEstate>();
        public IEnumerable<EmployeeRealEstateDTO> GetAllEmployeesRealEstateByExpression(Expression<Func<EmployeeRealEstateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstate, EmployeeRealEstateDTO>());
            Expression<Func<EmployeeRealEstate, bool>> where = Mapper.Map<Expression<Func<EmployeeRealEstate, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeRealEstateDTO>());
            List<EmployeeRealEstateDTO> employeeRealEstates = Mapper.Map<List<EmployeeRealEstate>, List<EmployeeRealEstateDTO>>(service.FindAll(where).ToList());

            return employeeRealEstates;
        }
        public EmployeeRealEstateView GetEmployeeAllRealEstatesView(Expression<Func<EmployeeRealEstateDTO, bool>> whereDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstate, EmployeeRealEstateDTO>());
            Expression<Func<EmployeeRealEstate, bool>> where = Mapper.Map<Expression<Func<EmployeeRealEstate, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstate, EmployeeRealEstateDTO>());
            List<EmployeeRealEstateDTO> employeeRealEstates = Mapper.Map<List<EmployeeRealEstate>, List<EmployeeRealEstateDTO>>(service.FindAll(where).ToList());

            List<RealEstateDTO> listRealEstate = new List<RealEstateDTO>();
            foreach (var item in employeeRealEstates)
            {
                listRealEstate.Add(new RealEstateService().GetRealEstateById(item.RealEstateId) );
            }
            
            return new EmployeeRealEstateView()
            {
                Employee = new EmployeeService().GetEmployeeById(employeeRealEstates.FirstOrDefault().EmployeeId),
             RealEstates = listRealEstate
             };
        }
        public IEnumerable<EmployeeRealEstateDTO> GetAllEmployeesRealEstate()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstate, EmployeeRealEstateDTO>());
            List<EmployeeRealEstateDTO> list = Mapper.Map<List<EmployeeRealEstate>, List<EmployeeRealEstateDTO>>(service.FindAll().ToList());

            return list;
        }

        public EmployeeRealEstateDTO GetEmployeesRealEstateByExpression(Expression<Func<EmployeeRealEstateDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstate, EmployeeRealEstateDTO>());
            Expression<Func<EmployeeRealEstate, bool>> where = Mapper.Map<Expression<Func<EmployeeRealEstate, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstate, EmployeeRealEstateDTO>());
            EmployeeRealEstateDTO employeeRealEstate = Mapper.Map<EmployeeRealEstate, EmployeeRealEstateDTO>(service.FindOne(where));

            return employeeRealEstate;
        }       

        public EmployeeRealEstateDTO GetEmployeeRealEstateById(int idRealEstateEmployee)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstate, EmployeeRealEstateDTO>());
            EmployeeRealEstateDTO employeeRealEstateObjectDto = Mapper.Map<EmployeeRealEstate, EmployeeRealEstateDTO>(service.FindById(idRealEstateEmployee));

            return employeeRealEstateObjectDto;
        }
        //----------------------------
        public EmployeeRealEstateView FilterEmployeeRealEstatesViewObject(EmployeeRealEstateDTO employeeRealEstate)
        {
            EmployeeRealEstateView viewObject = new EmployeeRealEstateView();
            if (employeeRealEstate.Id != 0) viewObject = this.GetEmployeeAllRealEstatesView(x => x.Id == employeeRealEstate.Id);
            if (employeeRealEstate.EmployeeId != 0) viewObject = this.GetEmployeeAllRealEstatesView(x => x.EmployeeId == employeeRealEstate.EmployeeId);
            if (employeeRealEstate.RealEstateId != 0) viewObject = this.GetEmployeeAllRealEstatesView(x => x.RealEstateId == employeeRealEstate.RealEstateId);
            return viewObject;
        }
        public List<EmployeeRealEstateDTO> FilterEmployeeRealEstatesList(EmployeeRealEstateDTO employeeRealEstate)
        {            
            List<EmployeeRealEstateDTO> list = Mapper.Map<List<EmployeeRealEstate>, List<EmployeeRealEstateDTO>>(service.FindAll().ToList());
            if (employeeRealEstate.Id != 0) list = list.Where(x => x.Id == employeeRealEstate.Id).ToList();
            if (employeeRealEstate.EmployeeId != 0) list = list.Where(x => x.EmployeeId == employeeRealEstate.EmployeeId).ToList();
            if (employeeRealEstate.RealEstateId != 0) list = list.Where(x => x.RealEstateId == employeeRealEstate.RealEstateId).ToList();
            return list;      
        }

        public int CreateEmployeesRealEstate(EmployeeRealEstateDTO employeeRealEstateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstateDTO, EmployeeRealEstate>());
            EmployeeRealEstate employeeRealEstate = Mapper.Map<EmployeeRealEstateDTO, EmployeeRealEstate>(employeeRealEstateDto);

            return service.CreateItem(employeeRealEstate, x => x.EmployeeId == employeeRealEstate.EmployeeId && x.RealEstateId == employeeRealEstate.RealEstateId).Id;
        }
        public bool UpdateEmployeeRealEstate(EmployeeRealEstateDTO employeeRealEstateDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeRealEstateDTO, EmployeeRealEstate>());
            EmployeeRealEstate employeeRealEstate = Mapper.Map<EmployeeRealEstateDTO, EmployeeRealEstate>(employeeRealEstateDto);

            return service.UpdateItem(employeeRealEstate);
        }
        public bool DeleteEmployeeRealEstate(int idEmployeeRealEstate)
        {
            return service.DeleteItem(idEmployeeRealEstate);
        }
    }
}
