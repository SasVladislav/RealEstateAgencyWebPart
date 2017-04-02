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
    public class TestUserService
    {
        static string CurrentUserName { get; set; } = "UserName";
        IUserService service = new UserService();
        static UserDTO CreateUser()
        {
            int RoleId = new PersonAccessRoleService()
                                .CreatePersonAccessRole(
                    new PersonAccessRoleDTO()
                    {
                        PersonAccessRoleName = "User"
                    }
                                );
            return new UserDTO()
            {
                Name = CurrentUserName,
                Surname = "UserName",
                LastName = "UserName",
                PhoneNumber=08411488,
                PersonAccessRoleId= RoleId,
                Email = "UserName",
                Password = "UserName"
            };
        }
        int SeedUser()
        {
            int resultID = 0;
            //act
            if (service.GetAllUsers().Count() == 0 ||
                service.GetUserByExpression(x => x.Name == CurrentUserName) == null)
                resultID = service.CreateUser(CreateUser());
            else
                resultID = service.GetUserByExpression(x => x.Name == CurrentUserName).Id;
            return resultID;
        }
        

        [TestMethod]
        public void TestUser_CreateUserNamedHome_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedUser();
            Assert.AreEqual(CurrentUserName, service.GetUserById(resultID).Name);
        }
        [TestMethod]
        public void TestUser_UpdateUserNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedUser();

            UserDTO getUser = service.GetUserById(resultID);
            getUser.Name = "Concrete";
            service.UpdateUser(getUser);
            CurrentUserName = "Concrete";
            Assert.AreEqual(CurrentUserName, service.GetUserById(resultID).Name);
        }
        [TestMethod]
        public void TestUser_GetUserNamedHomeById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedUser();


            Assert.AreEqual(CurrentUserName, service.GetUserById(resultID).Name);
        }
        [TestMethod]
        public void TestUser_GetAllUseres_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedUser();

            Assert.AreNotEqual(0, service.GetAllUsers().ToList().Count);
        }
        [TestMethod]
        public void TestUser_DeleteUser_CorrectResult()
        {
            //arrange  

            //arrange  
            int resultID = 0;
            //act
            resultID = SeedUser();
            Assert.AreNotEqual(null, service.GetUserByExpression(x=>x.Name==CurrentUserName));

            service.DeleteUser(resultID);
            Assert.AreEqual(null, service.GetUserByExpression(x => x.Name == CurrentUserName));
        }
    }
}
