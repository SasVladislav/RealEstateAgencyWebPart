using AutoMapper;
using RealEstateAgencyWebPart.BLL.GenericService;
using RealEstateAgencyWebPart.BLL.Interfaces;
using RealEstateAgencyWebPart.BLL.Models;
using RealEstateAgencyWebPart.DAL.Models;
using RealEstateAgencyWebPart.DAL.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class EmployeeDismissService: IEmployeeDismissService
    {
        GenericServiceEntity<EmployeeDismiss> service = new GenericServiceEntity<EmployeeDismiss>();
        public IEnumerable<EmployeeDismissDTO> GetAllRecordsEmployeeDismissByExpression(Expression<Func<EmployeeDismissDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissDTO>());
            Expression<Func<EmployeeDismiss, bool>> where = Mapper.Map<Expression<Func<EmployeeDismiss, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissDTO>());
            List<EmployeeDismissDTO> employeeDismisses = Mapper.Map<List<EmployeeDismiss>, List<EmployeeDismissDTO>>(service.FindAll(where).ToList());

            return employeeDismisses;
        }

        public IEnumerable<EmployeeDismissDTO> GetAllEmployeesDismiss()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissDTO>());
            List<EmployeeDismissDTO> list = Mapper.Map<List<EmployeeDismiss>, List<EmployeeDismissDTO>>(service.FindAll().ToList());

            return list;
        }        

        public EmployeeDismissDTO GetEmployeeDismissByExpression(Expression<Func<EmployeeDismissDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissDTO>());
            Expression<Func<EmployeeDismiss, bool>> where = Mapper.Map<Expression<Func<EmployeeDismiss, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissDTO>());
            EmployeeDismissDTO employeeDismiss = Mapper.Map<EmployeeDismiss, EmployeeDismissDTO>(service.FindOne(where));

            return employeeDismiss;
        }
        public EmployeeDismissDTO GetEmployeeDismissById(int idDismiss)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissDTO>());
            EmployeeDismissDTO employeeDismissDto = Mapper.Map<EmployeeDismiss, EmployeeDismissDTO>(service.FindById(idDismiss));

            return employeeDismissDto;
        }
        public List<EmployeeDismissDTO> FilterEmployeeDismisses(EmployeeDismissDTO dismiss)
        {
            List<EmployeeDismissDTO> list = Mapper.Map<List<EmployeeDismiss>, List<EmployeeDismissDTO>>(service.FindAll().ToList());
            if (dismiss.Id != 0) list = list.Where(x=>x.Id==dismiss.Id).ToList();
            if (dismiss.idEmployee != 0) list = list.Where(x => x.idEmployee == dismiss.idEmployee).ToList();
            if (dismiss.idEmployeeDismissState != 0) list = list.Where(x => x.idEmployeeDismissState == dismiss.idEmployeeDismissState).ToList();
            if (dismiss.EmploymentDate != null) list = list.Where(x => x.EmploymentDate == dismiss.EmploymentDate).ToList();
            if (dismiss.DismissDate != null) list = list.Where(x => x.DismissDate == dismiss.DismissDate).ToList();
            return list;
        }

        public IEnumerable<EmployeeDismissDTO> GetEmployeeDismissByEmployeeId(int idEmployee)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismiss, EmployeeDismissDTO>());            
            List<EmployeeDismissDTO> employeeDismisses = Mapper.Map<List<EmployeeDismiss>, List<EmployeeDismissDTO>>(service.FindAll(x => x.idEmployee == idEmployee).ToList()); ;
            
            return employeeDismisses;
        }
        public int CreateEmployeeDismiss(EmployeeDismissDTO employeeDismissDto)
        {
            
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissDTO, EmployeeDismiss>());           
            EmployeeDismiss employeeDismiss = Mapper.Map<EmployeeDismissDTO, EmployeeDismiss>(employeeDismissDto);

            return service.CreateItem(employeeDismiss, x=>x.idEmployee== employeeDismiss.idEmployee&&x.EmploymentDate== employeeDismiss.EmploymentDate&&
            x.DismissDate== employeeDismiss.DismissDate&&x.idEmployeeDismissState== employeeDismiss.idEmployeeDismissState).Id;
        }
        public bool UpdateEmployeeDismiss(EmployeeDismissDTO employeeDismissDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDismissDTO, EmployeeDismiss>());
            EmployeeDismiss employeeDismiss = Mapper.Map<EmployeeDismissDTO, EmployeeDismiss>(employeeDismissDto);

            return service.UpdateItem(employeeDismiss);
        }
        public bool DeleteEmployeeDismiss(int idDismiss)
        {
            return service.DeleteItem(idDismiss);
        }

        public bool DismissEmployee(int idEmployee)
        {
            if (idEmployee != 0)
            {
                EmployeeDismiss employee = service.FindAll(x => x.idEmployee == idEmployee).LastOrDefault();
                if (employee == null || employee.idEmployeeDismissState == 1 && employee.DismissDate == null)
                {
                    employee.DismissDate = DateTime.Now.ToShortDateString();
                    employee.idEmployeeDismissState = 2;
                    service.UpdateItem(employee);
                    return true;
                }
            }
            return false;
            
        }

        public bool EmploymentEmployee(int idEmployee)
        {
            if (idEmployee != 0)
            {
                EmployeeDismiss employee = service.FindAll(x => x.idEmployee == idEmployee).LastOrDefault();
                if (employee == null || employee.idEmployeeDismissState == 2 && employee.DismissDate != null)
                {
                    this.CreateEmployeeDismiss(new EmployeeDismissDTO()
                    {
                        idEmployee = idEmployee,
                        EmploymentDate = DateTime.Now.ToShortDateString(),
                        idEmployeeDismissState = 1
                    });
                    return true;
                }
            }
            return false;
        }
    }
}
