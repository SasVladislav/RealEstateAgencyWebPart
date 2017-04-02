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
    public class TestRealEstateStateService
    {
        static string CurrentStateName { get; set; } = "Free";
        IRealEstateStateService service = new RealEstateStateService();
        static RealEstateStateDTO CreateRealEstateState()
        {
            return new RealEstateStateDTO()
            {
                RealEstateStateName = CurrentStateName
            };
        }
        
        int SeedRealEstateState()
        {
            int resultID = 0;
            //act
            if (service.GetAllRealEstateStates().Count() == 0||
                service.GetRealEstateStateByExpression(x=>x.RealEstateStateName==CurrentStateName)==null)
                resultID = service.CreateRealEstateState(CreateRealEstateState());
            else
                resultID = service.GetRealEstateStateByExpression(x => x.RealEstateStateName == CurrentStateName).Id;
            return resultID;
        }
        [TestMethod]
        public void TestEmployeeRealEstate_CreateStateNamedHome_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateState();

            Assert.AreEqual(CurrentStateName, service.GetRealEstateStateById(resultID).RealEstateStateName);
        }
        [TestMethod]
        public void TestRealEstateState_UpdateStateNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateState();

            RealEstateStateDTO getRealEstateState = service.GetRealEstateStateById(resultID);
            getRealEstateState.RealEstateStateName = "Office";
            service.UpdateRealEstateState(getRealEstateState);
            CurrentStateName = "Office";
            Assert.AreEqual(CurrentStateName, service.GetRealEstateStateById(resultID).RealEstateStateName);
        }
        [TestMethod]
        public void TestRealEstateState_GetStateNamedHomeById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateState();

            Assert.AreEqual(CurrentStateName, service.GetRealEstateStateById(resultID).RealEstateStateName);
        }
        [TestMethod]
        public void TestRealEstateState_GetAllStatees_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateState();

            Assert.AreNotEqual(0, service.GetAllRealEstateStates().ToList().Count);
        }
        [TestMethod]
        public void TestRealEstateState_DeleteRealEstateState_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedRealEstateState();
            Assert.AreNotEqual(null, service.GetRealEstateStateByExpression(x=>x.RealEstateStateName==CurrentStateName));

            service.DeleteRealEstateState(resultID);
            Assert.AreEqual(null, service.GetRealEstateStateByExpression(x => x.RealEstateStateName == CurrentStateName));
        }
    }
}
