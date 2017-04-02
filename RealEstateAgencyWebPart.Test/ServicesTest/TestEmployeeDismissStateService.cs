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
    public class TestEmployeeDismissStateService
    {

        IEmployeeDismissStateService service = new EmployeeDismissStateService();
        static string CurrentStateName { get; set; } = "Working";

        EmployeeDismissStateDTO CreateDismissState()
        {
            return new EmployeeDismissStateDTO() {
                EmployeeDismissStateName = CurrentStateName
            };
        }

        int SeedDismissState() {
            int resultID = 0;
            //act
            if (service.GetAllEmployeeDismissStates().Count() == 0 ||
                service.GetEmployeeDismissStateByExpression(x=>x.EmployeeDismissStateName== CurrentStateName)==null)
            {
                resultID = service.CreateEmployeeDismissState(CreateDismissState());

            }
            else
            {
                resultID = service.GetEmployeeDismissStateByExpression(x => x.EmployeeDismissStateName == CurrentStateName).Id;
            }
            return resultID;
        }

        
        [TestMethod]
        public void TestEmployeeDismissState_CreateDismissState_CorrectResult()
        {
            //arrange  
            int resultID = SeedDismissState();

            Assert.AreEqual(CurrentStateName, service.GetEmployeeDismissStateById(resultID).EmployeeDismissStateName);

        }
        [TestMethod]
        public void TestEmployeeDismissState_UpdateDismissState_CorrectResult()
        {
            int resultID = SeedDismissState();

            EmployeeDismissStateDTO getEmployeeDismissState = service.GetEmployeeDismissStateById(resultID);

            getEmployeeDismissState.EmployeeDismissStateName = "Dismissing";
            service.UpdateEmployeeDismissState(getEmployeeDismissState);
            CurrentStateName = "Dismissing";
            Assert.AreEqual(CurrentStateName, service.GetEmployeeDismissStateById(resultID).EmployeeDismissStateName);
        }
        [TestMethod]
        public void TestEmployeeDismissState_GetDismissStateById_CorrectResult()
        {
            //arrange  

            int resultID = SeedDismissState();

            Assert.AreEqual(CurrentStateName, service.GetEmployeeDismissStateById(resultID).EmployeeDismissStateName);
        }
        [TestMethod]
        public void TestEmployeeDismissState_GetAllDismissStates_CorrectResult()
        {
            int resultID = SeedDismissState();

            Assert.AreNotEqual(0, service.GetAllEmployeeDismissStates().ToList().Count);
        }
        [TestMethod]
        public void TestEmployeeDismissState_DeleteDismissState_CorrectResult()
        {
            //arrange  

            int resultID = SeedDismissState();

            Assert.AreNotEqual(null, service.GetEmployeeDismissStateById(resultID));

            service.DeleteEmployeeDismissState(resultID);
            Assert.AreEqual(null, service.GetEmployeeDismissStateById(resultID));
        }
    }
}
