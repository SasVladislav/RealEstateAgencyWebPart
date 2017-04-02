using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        IEnumerable<EmployeeDTO> GetAllRecordsEmployeeByExpression(Expression<Func<EmployeeDTO, bool>> whereDTO = null);
        EmployeeDTO GetEmployeeById(int idEmployee);
        EmployeeDTO GetEmployeeByExpression(Expression<Func<EmployeeDTO, bool>> whereDTO = null);
        List<EmployeeDTO> FilterEmployees(EmployeeDTO employee);
        int CreateEmployee(EmployeeDTO employeeDto);
        bool UpdateEmployee(EmployeeDTO employeeDto);
        bool DeleteEmployee(int idEmployee);
    }
}
