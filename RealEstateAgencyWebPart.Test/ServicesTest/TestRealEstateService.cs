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
    public class TestRealEstateService
    {
        IRealEstateService service = new RealEstateService();
        static double Price { get; set; }
        RealEstateDTO CreateRealEstate()
        {
            int resultClassId = new RealEstateClassService()
                                .CreateRealEstateClass(
                    new RealEstateClassDTO() {
                        RealEstateClassName ="Home"}
                                );
            int resultStateId = new RealEstateStateService()
                                .CreateRealEstateState(
                    new RealEstateStateDTO() {
                        RealEstateStateName = "Free" }
                                );
            int resultTypeId = new RealEstateTypeService()
                                .CreateRealEstateType(
                    new RealEstateTypeDTO() {
                        RealEstateTypeName = "Business Center"
                    }
                                );
            int resultTypeWallId = new RealEstateTypeWallService()
                                .CreateRealEstateTypeWall(
                    new RealEstateTypeWallDTO() {
                        RealEstateTypeWallName = "Brick" }
                                );
            Price = 26487;
            return new RealEstateDTO()
            {
                NumberOfRooms = 2,
                GrossArea = 265,
                Image = "/Image",
                Price = Price,
                RealEstateClassId = resultClassId,
                RealEstateStateId = resultStateId,
                RealEstateTypeId = resultTypeId,
                RealEstateTypeWallId=resultTypeWallId
            };
        }
        int SeedRealEstateType()
        {
            int resultID = 0;
            //act
            if (service.GetAllRealEstates().Count() == 0 ||
                service.GetRealEstateByExpression(x => x.Price == Price) == null)
                resultID = service.CreateRealEstate(CreateRealEstate());
            else
                resultID = service.GetRealEstateByExpression(x => x.Price == Price).Id;
            return resultID;
        }
            

        [TestMethod]
        public void TestRealEstate_CreateRealEstate_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();
            Assert.AreEqual(Price, service.GetRealEstateById(resultID).Price);

        }
        [TestMethod]
        public void TestRealEstate_UpdateRealEstate_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();

            RealEstateDTO getRealEstate = service.GetRealEstateById(resultID);

            getRealEstate.Price = 250000;
            service.UpdateRealEstate(getRealEstate);
            Price = 250000;
            Assert.AreEqual(Price, service.GetRealEstateById(resultID).Price);
        }
        [TestMethod]
        public void TestRealEstate_GetRealEstateById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();

            Assert.AreEqual(Price, service.GetRealEstateById(resultID).Price);
        }
        [TestMethod]
        public void TestRealEstate_GetAllRealEstates_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();


            Assert.AreNotEqual(0, service.GetAllRealEstates().ToList().Count);
        }
        [TestMethod]
        public void TestRealEstate_DeleteRealEstate_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateType();
            Assert.AreNotEqual(null, service.GetRealEstateByExpression(x=>x.Price==Price));

            service.DeleteRealEstate(resultID);
            Assert.AreEqual(null, service.GetRealEstateByExpression(x => x.Price == Price));
        }
    }
}
