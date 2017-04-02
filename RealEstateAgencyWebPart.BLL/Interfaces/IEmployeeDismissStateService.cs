using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IEmployeeDismissStateService
    {
        IEnumerable<EmployeeDismissStateDTO> GetAllEmployeeDismissStates();
        EmployeeDismissStateDTO GetEmployeeDismissStateById(int idDismissState);
        IEnumerable<EmployeeDismissStateDTO> GetAllEmployeeDismissStateByExpression(Expression<Func<EmployeeDismissStateDTO, bool>> whereDTO = null);
        EmployeeDismissStateDTO GetEmployeeDismissStateByExpression(Expression<Func<EmployeeDismissStateDTO, bool>> whereDTO = null);
        List<EmployeeDismissStateDTO> FilterEmployeeDismissStates(EmployeeDismissStateDTO employeeDismissState);
        int CreateEmployeeDismissState(EmployeeDismissStateDTO employeeDismissStateDto);
        bool UpdateEmployeeDismissState(EmployeeDismissStateDTO employeeDismissStateDto);
        bool DeleteEmployeeDismissState(int idDismissState);
    }
}
