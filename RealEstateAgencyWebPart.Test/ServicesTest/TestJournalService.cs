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
    public class TestJournalService
    {
        static int CurrentUserId { get; set; }
        static int CurrentRealEstateNewId { get; set; }
        static int CurrentRealEstateId { get; set; }

        IJournalService service = new JournalService();

        JournalDTO CreateJournal()
        {
            int RoleId = new PersonAccessRoleService()
                                   .CreatePersonAccessRole(
                       new PersonAccessRoleDTO()
                       {
                           PersonAccessRoleName = "Employee"
                       });

            int EmployeeId = new EmployeeService().CreateEmployee(new EmployeeDTO()
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
            int RoleNId = new PersonAccessRoleService()
                                   .CreatePersonAccessRole(
                       new PersonAccessRoleDTO()
                       {
                           PersonAccessRoleName = "EmployeeNew"
                       });

            int EmployeeNId = new EmployeeService().CreateEmployee(new EmployeeDTO()
            {
                Name = "JournalNameNew",
                Surname = "JournalSurnameNew",
                LastName = "JournalLastNameNew",
                PhoneNumber = 15478511,
                Salary = 15487,
                PersonAccessRoleId = RoleNId,
                Email = "JournalEmailNew",
                Password = "JournalPasswordNew"
            });
            
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
                                    RealEstateTypeWallId = resultTypeWallId,
                                    EmployeeId= EmployeeId
                                });

            int RealEstateNId = new RealEstateService()
                                .CreateRealEstate(new RealEstateDTO()
                                {
                                    NumberOfRooms = 3,
                                    GrossArea = 26554,
                                    Image = "/Image12",
                                    Price = 26482547,
                                    RealEstateClassId = resultClassId,
                                    RealEstateStateId = resultStateId,
                                    RealEstateTypeId = resultTypeId,
                                    RealEstateTypeWallId = resultTypeWallId,
                                    EmployeeId = EmployeeNId
                                });


            CurrentRealEstateId = RealEstateId;

            CurrentRealEstateNewId = RealEstateNId;
            int OrderId = new JournalStateOrderService().CreateJournalStateOrder(
                new JournalStateOrderDTO()
            {
                JournalStateOrderName = "Unverified"
            });
            int RoleUId = new PersonAccessRoleService()
                                .CreatePersonAccessRole(
                    new PersonAccessRoleDTO()
                    {
                        PersonAccessRoleName = "User"
                    }
                                );
            int UserId= new UserService().CreateUser(new UserDTO()
            {
                Name = "UserName",
                Surname = "UserName",
                LastName = "UserName",
                PhoneNumber = 08411488,
                PersonAccessRoleId = RoleId,
                Email = "UserName",
                Password = "UserName"
            });
            CurrentUserId = UserId;
            return new JournalDTO() {
                RealEstateId= RealEstateId,
                DateRecord = DateTime.Now,
                DateViewRealEstate= DateTime.Now,
                JournalStateOrderId= OrderId,
                PersonId= UserId
            };
        }
        int SeedJournal()
        {
            //arrange  
            int resultID = 0;
            //act
            if (service.GetAllJournal().Count() == 0||
                service.GetJournalByExpression(x=>x.RealEstateId==CurrentRealEstateId)==null)
            {
                resultID = service.CreateJournal(CreateJournal());
            }
            else
            {
                resultID = service.GetJournalByExpression(x => x.RealEstateId == CurrentRealEstateId).Id;
            }
            return resultID;
        }
        

        [TestMethod]
        public void TestJournal_CreateJournalNamedHome_CorrectResult()
        {

            //arrange  
            int resultID = 0;
            //act
            resultID = SeedJournal();

            Assert.AreEqual(CurrentRealEstateId, service.GetJournalById(resultID).RealEstateId);
        }
        [TestMethod]
        public void TestJournal_UpdateJournalNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedJournal();

            JournalDTO getJournal = service.GetJournalById(resultID);
            getJournal.RealEstateId = CurrentRealEstateNewId;
            service.UpdateJournal(getJournal);
            CurrentRealEstateId = CurrentRealEstateNewId;
            Assert.AreEqual(CurrentRealEstateId, service.GetJournalById(resultID).RealEstateId);
        }
        [TestMethod]
        public void TestJournal_GetJournalNamedHomeById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedJournal();

            Assert.AreEqual(CurrentRealEstateId, service.GetJournalById(resultID).RealEstateId);
        }
        [TestMethod]
        public void TestJournal_GetAllJournales_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedJournal();

            Assert.AreNotEqual(0, service.GetAllJournal().ToList().Count);
        }
        [TestMethod]
        public void TestJournal_DeleteJournale_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedJournal();

            Assert.AreNotEqual(null, service.GetJournalByExpression(x => x.RealEstateId == CurrentRealEstateId));

            service.DeleteJournal(resultID);
            Assert.AreEqual(null, service.GetJournalByExpression(x => x.RealEstateId == CurrentRealEstateId));
        }
    }
}
