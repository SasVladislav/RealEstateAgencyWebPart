using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IPersonAccessRoleService
    {
        IEnumerable<PersonAccessRoleDTO> GetAllRecordsPersonAccessRoleByExpression(Expression<Func<PersonAccessRoleDTO, bool>> whereDTO = null);
        IEnumerable<PersonAccessRoleDTO> GetAllPersonAccessesRoles();
        PersonAccessRoleDTO GetPersonAccessRoleByExpression(Expression<Func<PersonAccessRoleDTO, bool>> whereDTO = null);
        PersonAccessRoleDTO GetPersonAccessRoleById(int idPersonAccessRole);
        List<PersonAccessRoleDTO> FilterPersonAccessRoles(PersonAccessRoleDTO personAccessRole);
        int CreatePersonAccessRole(PersonAccessRoleDTO personAccessRoleDto);
        bool UpdatePersonAccessRole(PersonAccessRoleDTO personAccessRoleDto);
        bool DeletePersonAccessRole(int idPersonAccessRole);
    }
}
