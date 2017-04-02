using AutoMapper;
using RealEstateAgencyWebPart.BLL.GenericService;
using RealEstateAgencyWebPart.BLL.Interfaces;
using RealEstateAgencyWebPart.BLL.Models;
using RealEstateAgencyWebPart.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class PersonAccessRoleService: IPersonAccessRoleService
    {
        GenericServiceEntity<PersonAccessRole> service = new GenericServiceEntity<PersonAccessRole>();
        public IEnumerable<PersonAccessRoleDTO> GetAllRecordsPersonAccessRoleByExpression(Expression<Func<PersonAccessRoleDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRole, PersonAccessRoleDTO>());
            Expression<Func<PersonAccessRole, bool>> where = Mapper.Map<Expression<Func<PersonAccessRole, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRole, PersonAccessRoleDTO>());
            List<PersonAccessRoleDTO> PersonAccessRoles = Mapper.Map<List<PersonAccessRole>, List<PersonAccessRoleDTO>>(service.FindAll(where).ToList());

            return PersonAccessRoles;
        }

        public IEnumerable<PersonAccessRoleDTO> GetAllPersonAccessesRoles()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRole, PersonAccessRoleDTO>());
            List<PersonAccessRoleDTO> list = Mapper.Map<List<PersonAccessRole>, List<PersonAccessRoleDTO>>(service.FindAll().ToList());

            return list;
        }
        public PersonAccessRoleDTO GetPersonAccessRoleByExpression(Expression<Func<PersonAccessRoleDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRole, PersonAccessRoleDTO>());
            Expression<Func<PersonAccessRole, bool>> where = Mapper.Map<Expression<Func<PersonAccessRole, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRole, PersonAccessRoleDTO>());
            PersonAccessRoleDTO personAccessRole = Mapper.Map<PersonAccessRole, PersonAccessRoleDTO>(service.FindOne(where));

            return personAccessRole;
        }
        public PersonAccessRoleDTO GetPersonAccessRoleById(int idPersonAccessRole)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRole, PersonAccessRoleDTO>());
            PersonAccessRoleDTO personAccessRoleObjectDto = Mapper.Map<PersonAccessRole, PersonAccessRoleDTO>(service.FindById(idPersonAccessRole));

            return personAccessRoleObjectDto;
        }

        public List<PersonAccessRoleDTO> FilterPersonAccessRoles(PersonAccessRoleDTO personAccessRole)
        {
            List<PersonAccessRoleDTO> list = Mapper.Map<List<PersonAccessRole>, List<PersonAccessRoleDTO>>(service.FindAll().ToList());
            if (personAccessRole.Id != 0) list = list.Where(x => x.Id == personAccessRole.Id).ToList();
            if (personAccessRole.PersonAccessRoleName != null) list = list.Where(x => x.PersonAccessRoleName == personAccessRole.PersonAccessRoleName).ToList();
            return list;
        }

        public int CreatePersonAccessRole(PersonAccessRoleDTO personAccessRoleDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRoleDTO, PersonAccessRole>());
            PersonAccessRole personAccessRole = Mapper.Map<PersonAccessRoleDTO, PersonAccessRole>(personAccessRoleDto);

            return service.CreateItem(personAccessRole, x => x.PersonAccessRoleName == personAccessRole.PersonAccessRoleName).Id;
        }
        public bool UpdatePersonAccessRole(PersonAccessRoleDTO personAccessRoleDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PersonAccessRoleDTO, PersonAccessRole>());
            PersonAccessRole personAccessRole = Mapper.Map<PersonAccessRoleDTO, PersonAccessRole>(personAccessRoleDto);

            return service.UpdateItem(personAccessRole);
        }
        public bool DeletePersonAccessRole(int idPersonAccessRole)
        {
            return service.DeleteItem(idPersonAccessRole);
        }
    }
}
