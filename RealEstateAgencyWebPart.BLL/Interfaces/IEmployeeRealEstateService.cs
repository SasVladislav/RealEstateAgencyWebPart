using RealEstateAgencyWebPart.BLL.Models;
using RealEstateAgencyWebPart.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IEmployeeRealEstateService
    {
        IEnumerable<EmployeeRealEstateDTO> GetAllEmployeesRealEstate();
        IEnumerable<EmployeeRealEstateDTO> GetAllEmployeesRealEstateByExpression(Expression<Func<EmployeeRealEstateDTO, bool>> whereDTO = null);
        EmployeeRealEstateView GetEmployeeAllRealEstatesView(Expression<Func<EmployeeRealEstateDTO, bool>> whereDTO);
        EmployeeRealEstateDTO GetEmployeesRealEstateByExpression(Expression<Func<EmployeeRealEstateDTO, bool>> whereDTO = null);
        EmployeeRealEstateDTO GetEmployeeRealEstateById(int idRealEstateEmployee);
        List<EmployeeRealEstateDTO> FilterEmployeeRealEstatesList(EmployeeRealEstateDTO employeeRealEstate);
        EmployeeRealEstateView FilterEmployeeRealEstatesViewObject(EmployeeRealEstateDTO employeeRealEstate);
        int CreateEmployeesRealEstate(EmployeeRealEstateDTO employeeRealEstateDto);
        bool UpdateEmployeeRealEstate(EmployeeRealEstateDTO employeeRealEstateDto);
        bool DeleteEmployeeRealEstate(int idEmployeeRealEstate);
    }
}
