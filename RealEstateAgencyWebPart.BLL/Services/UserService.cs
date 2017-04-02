using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgencyWebPart.DAL.Models;
using RealEstateAgencyWebPart.DAL.RepositoryService;
using RealEstateAgencyWebPart.BLL.GenericService;
using System.Linq.Expressions;
using RealEstateAgencyWebPart.BLL.Interfaces;
using AutoMapper;
using RealEstateAgencyWebPart.BLL.Models;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class UserService: IUserService
    {
        GenericServiceEntity<User> service = new GenericServiceEntity<User>();

        public IEnumerable<UserDTO> GetAllRecordsUserByExpression(Expression<Func<UserDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            Expression<Func<User, bool>> where = Mapper.Map<Expression<Func<User, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            List<UserDTO> Users = Mapper.Map<List<User>, List<UserDTO>>(service.FindAll(where).ToList());

            return Users;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            List<UserDTO> list = Mapper.Map<List<User>, List<UserDTO>>(service.FindAll().ToList());

            return list;
        }

        public UserDTO GetUserByExpression(Expression<Func<UserDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            Expression<Func<User, bool>> where = Mapper.Map<Expression<Func<User, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            UserDTO user = Mapper.Map<User, UserDTO>(service.FindOne(where));

            return user;
        }

        public UserDTO GetUserById(int idUser)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            UserDTO employeeUserObjectDto = Mapper.Map<User, UserDTO>(service.FindById(idUser));

            return employeeUserObjectDto;
        }

        public List<UserDTO> FilterUsers(UserDTO user)
        {
            List<UserDTO> list = Mapper.Map<List<User>, List<UserDTO>>(service.FindAll().ToList());
            if (user.Id != 0) list = list.Where(x => x.Id == user.Id).ToList();
            if (user.Name != null) list = list.Where(x => x.Name == user.Name).ToList();
            if (user.LastName != null) list = list.Where(x => x.LastName == user.LastName).ToList();
            if (user.Surname != null) list = list.Where(x => x.Surname == user.Surname).ToList();
            return list;
        }

        public int CreateUser(UserDTO employeeUserDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
            User user = Mapper.Map<UserDTO, User>(employeeUserDto);

            return service.CreateItem(user, x => x.Name == user.Name && x.Surname == user.Surname &&
            x.LastName == user.LastName).Id;
        }
        public bool UpdateUser(UserDTO employeeUserDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
            User user = Mapper.Map<UserDTO, User>(employeeUserDto);

            return service.UpdateItem(user);
        }
        public bool DeleteUser(int idUser)
        {
            return service.DeleteItem(idUser);
        }
    }
}
