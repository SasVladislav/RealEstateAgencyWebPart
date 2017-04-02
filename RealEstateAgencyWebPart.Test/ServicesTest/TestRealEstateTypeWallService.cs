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
    public class TestRealEstateTypeWallService
    {
        static string CurrentTypeWallName { get; set; } = "Brick";
        IRealEstateTypeWallService service = new RealEstateTypeWallService();

        static RealEstateTypeWallDTO CreateRealEstateTypeWall()
        {
            return new RealEstateTypeWallDTO()
            {
                RealEstateTypeWallName = CurrentTypeWallName
            };
        }
        int SeedRealEstateTypeWall()
        {
            int resultID = 0;
            //act
            if (service.GetAllRealEstateTypesWall().Count() == 0 ||
                service.GetRealEstateTypeWallByExpression(x => x.RealEstateTypeWallName == CurrentTypeWallName) == null)
                resultID = service.CreateRealEstateTypeWall(CreateRealEstateTypeWall());
            else
                resultID = service.GetRealEstateTypeWallByExpression(x => x.RealEstateTypeWallName == CurrentTypeWallName).Id;
            return resultID;
        }
            
        [TestMethod]
        public void TestRealEstateTypeWall_CreateTypeWallNamedHome_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateTypeWall();
            Assert.AreEqual(CurrentTypeWallName, service.GetRealEstateTypeWallById(resultID).RealEstateTypeWallName);
        }
        [TestMethod]
        public void TestRealEstateTypeWall_UpdateTypeWallNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateTypeWall();

            RealEstateTypeWallDTO getRealEstateTypeWall = service.GetRealEstateTypeWallById(resultID);
            getRealEstateTypeWall.RealEstateTypeWallName = "Concrete";
            service.UpdateRealEstateTypeWall(getRealEstateTypeWall);
            CurrentTypeWallName = "Concrete";
            Assert.AreEqual(CurrentTypeWallName, service.GetRealEstateTypeWallById(resultID).RealEstateTypeWallName);
        }
        [TestMethod]
        public void TestRealEstateTypeWall_GetTypeWallNamedHomeById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateTypeWall();

            Assert.AreEqual(CurrentTypeWallName, service.GetRealEstateTypeWallById(resultID).RealEstateTypeWallName);
        }
        [TestMethod]
        public void TestRealEstateTypeWall_GetAllTypeWalles_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateTypeWall();

            Assert.AreNotEqual(0, service.GetAllRealEstateTypesWall().ToList().Count);
        }
        [TestMethod]
        public void TestRealEstateTypeWall_DeleteRealEstateTypeWall_CorrectResult()
        {
            //arrange  

            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateTypeWall();
            Assert.AreNotEqual(null, service.GetRealEstateTypeWallByExpression(x=>x.RealEstateTypeWallName==CurrentTypeWallName));

            service.DeleteRealEstateTypeWall(resultID);
            Assert.AreEqual(null, service.GetRealEstateTypeWallByExpression(x => x.RealEstateTypeWallName == CurrentTypeWallName));
        }
    }
}
