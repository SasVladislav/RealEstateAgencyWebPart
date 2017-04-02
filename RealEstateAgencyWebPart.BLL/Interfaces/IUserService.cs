using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUserById(int idUser);
        IEnumerable<UserDTO> GetAllRecordsUserByExpression(Expression<Func<UserDTO, bool>> whereDTO = null);
        UserDTO GetUserByExpression(Expression<Func<UserDTO, bool>> whereDTO = null);
        List<UserDTO> FilterUsers(UserDTO user);
        int CreateUser(UserDTO employeeUserDto);
        bool UpdateUser(UserDTO employeeUserDto);
        bool DeleteUser(int idUser);
    }
}
