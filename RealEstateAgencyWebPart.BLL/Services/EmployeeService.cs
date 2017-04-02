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
    public class EmployeeService: IEmployeeService
    {
        GenericServiceEntity<Employee> service = new GenericServiceEntity<Employee>();

        public IEnumerable<EmployeeDTO> GetAllRecordsEmployeeByExpression(Expression<Func<EmployeeDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            Expression<Func<Employee, bool>> where = Mapper.Map<Expression<Func<Employee, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            List<EmployeeDTO> employees = Mapper.Map<List<Employee>, List<EmployeeDTO>>(service.FindAll(where).ToList());

            return employees;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            List<EmployeeDTO> list = Mapper.Map<List<Employee>, List<EmployeeDTO>>(service.FindAll().ToList());

            EmployeeDTO emp = new EmployeeDTO();
            List<EmployeeDTO> listView = new List<EmployeeDTO>();
            foreach (var item in list)
            {
                emp = item;
                emp.ListDismiss = new EmployeeDismissService().GetAllRecordsEmployeeDismissByExpression(x => x.idEmployee == item.Id).ToList();
                listView.Add(emp);
            }
            return listView;
        }
        public EmployeeDTO GetEmployeeByExpression(Expression<Func<EmployeeDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            Expression<Func<Employee, bool>> where = Mapper.Map<Expression<Func<Employee, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            EmployeeDTO employee = Mapper.Map<Employee, EmployeeDTO>(service.FindOne(where));

            EmployeeDTO emp = new EmployeeDTO();

            emp = employee;
            emp.ListDismiss = new EmployeeDismissService().GetAllRecordsEmployeeDismissByExpression(x => x.idEmployee == employee.Id).ToList();
         
            return emp;
        }
        public EmployeeDTO GetEmployeeById(int idEmployee)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());
            EmployeeDTO employee = Mapper.Map<Employee, EmployeeDTO>(service.FindById(idEmployee));

            EmployeeDTO emp = new EmployeeDTO();

            emp = employee;
            emp.ListDismiss = new EmployeeDismissService().GetAllRecordsEmployeeDismissByExpression(x => x.idEmployee == employee.Id).ToList();

            return emp;
        }
        //Get All Employeess by Role there
        public List<EmployeeDTO> FilterEmployees(EmployeeDTO employee)
        {
            List<EmployeeDTO> list = Mapper.Map<List<Employee>, List<EmployeeDTO>>(service.FindAll().ToList());
            if (employee.Id != 0) list = list.Where(x => x.Id == employee.Id).ToList();
            if (employee.Name != null) list = list.Where(x => x.Name == employee.Name).ToList();
            if (employee.Surname != null) list = list.Where(x => x.Surname == employee.Surname).ToList();
            if (employee.LastName != null) list = list.Where(x => x.LastName == employee.LastName).ToList();
            if (employee.PersonAccessRoleId != 0) list = list.Where(x => x.PersonAccessRoleId == employee.PersonAccessRoleId).ToList();
            return list;
        }

        
        public int CreateEmployee(EmployeeDTO employeeDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDTO, Employee>());
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDto);

            int employeeId = service.CreateItem(employee, x => x.Name == employeeDto.Name && x.Surname == employeeDto.Surname &&
            x.LastName == employeeDto.LastName).Id;
            new EmployeeDismissService().EmploymentEmployee(employeeId);
            return employeeId;
        }
        public bool UpdateEmployee(EmployeeDTO employeeDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<EmployeeDTO, Employee>());
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDto);

            return service.UpdateItem(employee);
        }
        public bool DeleteEmployee(int idEmployee)
        {
            return service.DeleteItem(idEmployee);
        }
    }
}
