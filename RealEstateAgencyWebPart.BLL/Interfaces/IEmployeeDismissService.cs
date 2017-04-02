using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IEmployeeDismissService
    {
        IEnumerable<EmployeeDismissDTO> GetAllEmployeesDismiss();
        IEnumerable<EmployeeDismissDTO> GetEmployeeDismissByEmployeeId(int idEmployee);
        bool DismissEmployee(int idEmployee);
        bool EmploymentEmployee(int idEmployee);
        IEnumerable<EmployeeDismissDTO> GetAllRecordsEmployeeDismissByExpression(Expression<Func<EmployeeDismissDTO, bool>> whereDTO = null);
        List<EmployeeDismissDTO> FilterEmployeeDismisses(EmployeeDismissDTO dismiss);
        EmployeeDismissDTO GetEmployeeDismissByExpression(Expression<Func<EmployeeDismissDTO, bool>> whereDTO = null);
        EmployeeDismissDTO GetEmployeeDismissById(int idDismiss);       
        int CreateEmployeeDismiss(EmployeeDismissDTO employeeDismissDto);
        bool UpdateEmployeeDismiss(EmployeeDismissDTO employeeDismissDto);
        bool DeleteEmployeeDismiss(int idDismiss);
    }
}
