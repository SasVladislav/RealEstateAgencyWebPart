using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealEstateAgencyWebPart.BLL.Interfaces;
using RealEstateAgencyWebPart.BLL.Models;
using RealEstateAgencyWebPart.View.Controllers;
using Moq;
using System.Collections.Generic;
using System.Linq;
using RealEstateAgencyWebPart.BLL.Services;

namespace RealEstateAgencyWebPart.Test
{
    [TestClass]
    public class TestEmployeeRealEstateService
    {
        EmployeeRealEstateDTO CreateEmployeeRealEstate()
        {
            int RoleId = new PersonAccessRoleService()
                                   .CreatePersonAccessRole(
                       new PersonAccessRoleDTO()
                       {
                           PersonAccessRoleName = "Employee"
                       });

            int EmployeeId= new EmployeeService().CreateEmployee( new EmployeeDTO()
            {
                Name = "EmployeeName",
                Surname = "EmployeeSurname",
                LastName = "EmployeeLastName",
                PhoneNumber = 15478511,
                Salary = 15487,
                PersonAccessRoleId = RoleId,
                Email = "EmployeeEmail",
                Password = "EmployeePassword"
            });
            CurrentEmployeeId = EmployeeId;
            int RoleNId = new PersonAccessRoleService()
                                   .CreatePersonAccessRole(
                       new PersonAccessRoleDTO()
                       {
                           PersonAccessRoleName = "EmployeeRealEstateNew"
                       });

            int EmployeeNId = new EmployeeService().CreateEmployee(new EmployeeDTO()
            {
                Name = "EmployeeRealEstateNameNew",
                Surname = "EmployeeRealEstateSurnameNew",
                LastName = "EmployeeRealEstateLastNameNew",
                PhoneNumber = 15478511,
                Salary = 15487,
                PersonAccessRoleId = RoleNId,
                Email = "EmployeeRealEstateEmailNew",
                Password = "EmployeeRealEstatePasswordNew"
            });
            CurrentEmployeeNewId = EmployeeNId;
            int resultClassId = new RealEstateClassService()
                                .CreateRealEstateClass(
                    new RealEstateClassDTO()
                    {
                        RealEstateClassName = "Home"
                    }
                                );
            int resultStateId = new RealEstateStateService()
                                .CreateRealEstateState(
                    new RealEstateStateDTO()
                    {
                        RealEstateStateName = "Free"
                    }
                                );
            int resultTypeId = new RealEstateTypeService()
                                .CreateRealEstateType(
                    new RealEstateTypeDTO()
                    {
                        RealEstateTypeName = "Business Center"
                    }
                                );
            int resultTypeWallId = new RealEstateTypeWallService()
                                .CreateRealEstateTypeWall(
                    new RealEstateTypeWallDTO()
                    {
                        RealEstateTypeWallName = "Brick"
                    }
                                );
            int RealEstateId = new RealEstateService()
                                .CreateRealEstate(new RealEstateDTO()
            {
              NumberOfRooms = 2,
              GrossArea = 265,
              Image = "/Image",
              Price = 26487,
              RealEstateClassId = resultClassId,
              RealEstateStateId = resultStateId,
              RealEstateTypeId = resultTypeId,
              RealEstateTypeWallId = resultTypeWallId
                                });
            CurrentRealEstateId = RealEstateId;
            return new EmployeeRealEstateDTO()
            {
                EmployeeId = EmployeeId,
                RealEstateId = RealEstateId
            };
        }
        int SeedEmployeeRealEstate()
        {
            int resultID = 0;
            //act
            if (service.GetAllEmployeesRealEstate().Count() == 0)
            {
                resultID = service.CreateEmployeesRealEstate(CreateEmployeeRealEstate());
            }
            else
            {
                resultID = service.GetAllEmployeesRealEstateByExpression(x=>x.RealEstateId==CurrentRealEstateId).LastOrDefault().Id;
            }
            return resultID;
        }
        static int CurrentEmployeeId { get; set; }
        static int CurrentEmployeeNewId { get; set; }
        static int CurrentRealEstateId { get; set; }

        IEmployeeRealEstateService service = new EmployeeRealEstateService();

        [TestMethod]
        public void TestEmployeeRealEstate_CreateEmployeeRealEstateNamedHome_CorrectResult()
        {
            //arrange  
            int resultID = SeedEmployeeRealEstate();

            Assert.AreEqual(CurrentRealEstateId, service.GetEmployeeRealEstateById(resultID).RealEstateId);
            service.DeleteEmployeeRealEstate(resultID);
        }
        [TestMethod]
        public void TestEmployeeRealEstate_UpdateEmployeeRealEstateNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = SeedEmployeeRealEstate();

            EmployeeRealEstateDTO getEmployeeRealEstate = service.GetEmployeeRealEstateById(resultID);
            getEmployeeRealEstate.EmployeeId = CurrentEmployeeNewId;
            service.UpdateEmployeeRealEstate(getEmployeeRealEstate);
            CurrentEmployeeId = CurrentEmployeeNewId;
            Assert.AreEqual(CurrentEmployeeNewId, service.GetEmployeeRealEstateById(resultID).EmployeeId);
            service.DeleteEmployeeRealEstate(resultID);
        }
        [TestMethod]
        public void TestEmployeeRealEstate_GetEmployeeRealEstateNamedHomeById_CorrectResult()
        {
            int resultID = SeedEmployeeRealEstate();

            Assert.AreEqual(CurrentEmployeeId, service.GetEmployeeRealEstateById(resultID).EmployeeId);
            service.DeleteEmployeeRealEstate(resultID);
        }
        [TestMethod]
        public void TestEmployeeRealEstate_GetAllEmployeeRealEstatees_CorrectResult()
        {
            int resultID = 0;

            if (service.GetAllEmployeesRealEstate().Count() == 0)
            {
                resultID = service.CreateEmployeesRealEstate(CreateEmployeeRealEstate());
            }         
            //act
            Assert.AreEqual(1, service.GetAllEmployeesRealEstate().ToList().Count);
            service.DeleteEmployeeRealEstate(resultID);
        }
    }
}
