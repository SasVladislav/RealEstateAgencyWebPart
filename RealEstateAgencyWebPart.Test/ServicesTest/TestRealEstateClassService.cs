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
    public class TestRealEstateClassService
    {
        static string CurrentClassName { get; set; } = "Home";
        IRealEstateClassService service = new RealEstateClassService();

        RealEstateClassDTO CreateRealEstateClass()
        {
            return new RealEstateClassDTO()
            {
                RealEstateClassName = CurrentClassName
            };
        }
        int SeedRealEstateClass()
        {
            int resultID = 0;
            //act
            if (service.GetAllRealEstateClasses().Count() == 0||
                service.GetRealEstateClassByExpression(x=>x.RealEstateClassName==CurrentClassName)==null)
            {
                resultID = service.CreateRealEstateClass(CreateRealEstateClass());
            }
            else
            {
                resultID = service.GetRealEstateClassByExpression(x => x.RealEstateClassName == CurrentClassName).Id;
            }
            return resultID;
        }
        

        [TestMethod]
        public void TestRealEstateClass_CreateClassNamedHome_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateClass();
            //assert
            Assert.AreEqual(CurrentClassName, service.GetRealEstateClassById(resultID).RealEstateClassName);
        }
        [TestMethod]
        public void TestRealEstateClass_UpdateClassNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateClass();

            RealEstateClassDTO getRealEstateClass = service.GetRealEstateClassById(resultID);
            getRealEstateClass.RealEstateClassName = "Office";
            service.UpdateRealEstateClass(getRealEstateClass);
            CurrentClassName = "Office";
            Assert.AreEqual(CurrentClassName, service.GetRealEstateClassById(resultID).RealEstateClassName);
        }
        [TestMethod]
        public void TestRealEstateClass_GetClassNamedHomeById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateClass();

            Assert.AreEqual(CurrentClassName, service.GetRealEstateClassById(resultID).RealEstateClassName);
        }
        [TestMethod]
        public void TestRealEstateClass_GetAllClasses_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateClass();

            Assert.AreNotEqual(0, service.GetAllRealEstateClasses().ToList().Count);
        }
        [TestMethod]
        public void TestRealEstateClass_DeleteRealEstateClass_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateClass();

            Assert.AreNotEqual(null, service.GetRealEstateClassByExpression(x=>x.RealEstateClassName==CurrentClassName));

            service.DeleteRealEstateClass(resultID);
            Assert.AreEqual(null, service.GetRealEstateClassByExpression(x => x.RealEstateClassName == CurrentClassName));
        }
    }
}
