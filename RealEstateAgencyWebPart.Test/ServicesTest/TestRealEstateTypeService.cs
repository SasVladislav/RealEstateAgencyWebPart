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
    public class TestRealEstateTypeService
    {
        static string CurrentTypeName { get; set; } = "Business Center";
        IRealEstateTypeService service = new RealEstateTypeService();

        static RealEstateTypeDTO CreateRealEstateType()
        {
            return new RealEstateTypeDTO()
            {
                RealEstateTypeName = CurrentTypeName
            };
        }
        int SeedRealEstateType()
        {
            int resultID = 0;
            //act
            if (service.GetAllRealEstateTypes().Count() == 0 ||
                service.GetRealEstateTypeByExpression(x => x.RealEstateTypeName == CurrentTypeName) == null)
                resultID = service.CreateRealEstateType(CreateRealEstateType());
            else
                resultID = service.GetRealEstateTypeByExpression(x => x.RealEstateTypeName == CurrentTypeName).Id;
            return resultID;
        }
           

        [TestMethod]
        public void TestRealEstateType_CreateTypeNamedHome_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();
            Assert.AreEqual(CurrentTypeName, service.GetRealEstateTypeById(resultID).RealEstateTypeName);
        }
        [TestMethod]
        public void TestRealEstateType_UpdateTypeNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();

            RealEstateTypeDTO getRealEstateType = service.GetRealEstateTypeById(resultID);
            getRealEstateType.RealEstateTypeName = "House";
            service.UpdateRealEstateType(getRealEstateType);
            CurrentTypeName = "House";
            Assert.AreEqual(CurrentTypeName, service.GetRealEstateTypeById(resultID).RealEstateTypeName);
        }
        [TestMethod]
        public void TestRealEstateType_GetTypeNamedHomeById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();

            Assert.AreEqual(CurrentTypeName, service.GetRealEstateTypeById(resultID).RealEstateTypeName);
        }
        [TestMethod]
        public void TestRealEstateType_GetAllTypees_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();

            Assert.AreNotEqual(0, service.GetAllRealEstateTypes().ToList().Count);
        }
        [TestMethod]
        public void TestRealEstateType_DeleteRealEstateType_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();

            Assert.AreNotEqual(null, service.GetRealEstateTypeByExpression(x=>x.RealEstateTypeName==CurrentTypeName));

            service.DeleteRealEstateType(resultID);
            Assert.AreEqual(null, service.GetRealEstateTypeByExpression(x => x.RealEstateTypeName == CurrentTypeName));
        }
    }
}
