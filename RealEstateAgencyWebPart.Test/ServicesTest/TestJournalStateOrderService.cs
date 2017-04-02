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
    public class TestJournalStateOrderService
    {
        IJournalStateOrderService service = new JournalStateOrderService();
        static string CurrentStateName { get; set; } = "Unverified";

        JournalStateOrderDTO CreateStateOrder()
        {
            return new JournalStateOrderDTO(){
                      JournalStateOrderName = CurrentStateName
                        };
        }

            int SeedStateOrder()
        {
            int resultID = 0;
            //act
            if (service.GetAllJournalStateOrders().Count() == 0||
                service.GetJournalStateOrderByExpression(x=>x.JournalStateOrderName== CurrentStateName)==null)
            {
                resultID = service.CreateJournalStateOrder(CreateStateOrder());
            }
            else
            {
                resultID = service.GetJournalStateOrderByExpression(x => x.JournalStateOrderName == CurrentStateName).Id;
            }
            return resultID;
        }
            

        [TestMethod]
        public void TestJournalStateOrder_CreateDismissState_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            //act
            resultID = SeedStateOrder();
            //assert
            Assert.AreEqual(CurrentStateName, service.GetJournalStateOrderById(resultID).JournalStateOrderName);
        }
        [TestMethod]
        public void TestJournalStateOrder_UpdateDismissState_CorrectResult()
        {
            //arrange  
            int resultID = 0;          
            resultID = SeedStateOrder();

            //act
            JournalStateOrderDTO getJournalStateOrder = service.GetJournalStateOrderById(resultID);
            getJournalStateOrder.JournalStateOrderName = "Confirmed";
            service.UpdateJournalStateOrder(getJournalStateOrder);
            CurrentStateName = "Confirmed";
            //assert
            Assert.AreEqual(CurrentStateName, service.GetJournalStateOrderById(resultID).JournalStateOrderName);
        }
        [TestMethod]
        public void TestJournalStateOrder_GetDismissStateById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            resultID = SeedStateOrder();
            //assert
            Assert.AreEqual(CurrentStateName, service.GetJournalStateOrderById(resultID).JournalStateOrderName);
        }
        [TestMethod]
        public void TestJournalStateOrder_GetAllDismissStates_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            resultID = SeedStateOrder();
            //assert
            Assert.AreNotEqual(0, service.GetAllJournalStateOrders().ToList().Count);
        }
        [TestMethod]
        public void TestJournalStateOrder_DeleteDismissState_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            resultID = SeedStateOrder();

            Assert.AreNotEqual(null, service.GetJournalStateOrderById(resultID));

            service.DeleteJournalStateOrder(resultID);
            Assert.AreEqual(null, service.GetJournalStateOrderById(resultID));
        }
    }
}
