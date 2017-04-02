using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealEstateAgencyWebPart.BLL.Interfaces;
using RealEstateAgencyWebPart.BLL.Models;
using RealEstateAgencyWebPart.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.Test.ServicesTest
{
    [TestClass]
    public class TestPersonAccessRoleService
    {
        IPersonAccessRoleService service = new PersonAccessRoleService();
        static string CurrentRoleName { get; set; } = "EmployeeAccess";

        static PersonAccessRoleDTO CreateAccessRole()
        {
            return new PersonAccessRoleDTO()
            {
                PersonAccessRoleName = CurrentRoleName
            };
        }
        int SeedAccessRole() {
            int resultID = 0;
            //act
            if (service.GetAllPersonAccessesRoles().Count() == 0||
                service.GetPersonAccessRoleByExpression(x=>x.PersonAccessRoleName== CurrentRoleName)==null)
            {
                resultID = service.CreatePersonAccessRole(CreateAccessRole());
            }
            else
            {
                resultID = service.GetPersonAccessRoleByExpression(x => x.PersonAccessRoleName == CurrentRoleName).Id;
            }
            return resultID;
        }

        
        [TestMethod]
        public void TestPersonAccessRole_AccessRoleState_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedAccessRole();

            Assert.AreEqual(CurrentRoleName, service.GetPersonAccessRoleById(resultID).PersonAccessRoleName);
        }
        [TestMethod]
        public void TestPersonAccessRole_UpdateAccessRole_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedAccessRole();

            PersonAccessRoleDTO getPersonAccessRole = service.GetPersonAccessRoleById(resultID);

            getPersonAccessRole.PersonAccessRoleName = "Admin";
            service.UpdatePersonAccessRole(getPersonAccessRole);
            CurrentRoleName = "Admin";
            Assert.AreEqual(CurrentRoleName, service.GetPersonAccessRoleById(resultID).PersonAccessRoleName);
        }
        [TestMethod]
        public void TestPersonAccessRole_GetAccessRoleById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedAccessRole();

            Assert.AreEqual(CurrentRoleName, service.GetPersonAccessRoleById(resultID).PersonAccessRoleName);
        }
        [TestMethod]
        public void TestPersonAccessRole_GetAllAccessRoles_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedAccessRole();

            Assert.AreNotEqual(0, service.GetAllPersonAccessesRoles().ToList().Count);
        }
        [TestMethod]
        public void TestPersonAccessRole_DeleteAccessRole_CorrectResult()
        {
            //arrange  

            int resultID = 0;
            //act
            if (service.GetAllPersonAccessesRoles().Count() == 0)
                resultID = service.CreatePersonAccessRole(CreateAccessRole());
            else
                resultID = service.GetAllRecordsPersonAccessRoleByExpression(x => x.PersonAccessRoleName == CurrentRoleName).FirstOrDefault().Id;
            Assert.AreNotEqual(null, service.GetPersonAccessRoleByExpression(x => x.PersonAccessRoleName == CurrentRoleName));

            service.DeletePersonAccessRole(resultID);
            Assert.AreEqual(null, service.GetPersonAccessRoleByExpression(x => x.PersonAccessRoleName == CurrentRoleName));
        }
    }
}
