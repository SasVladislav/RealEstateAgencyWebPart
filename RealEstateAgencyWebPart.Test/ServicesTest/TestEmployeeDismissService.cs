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
    public class TestEmployeeDismissService
    {

        IEmployeeDismissService service = new EmployeeDismissService();

        static int roleid = new PersonAccessRoleService().CreatePersonAccessRole(new PersonAccessRoleDTO()
        {
                PersonAccessRoleName = "Employee"
        });
        static int employeeId = new EmployeeService().CreateEmployee(new EmployeeDTO()
            {
                Name = "Employee1",
                Surname = "Employee1",
                LastName = "Employee1",
                Email = "Employee@gmail.com",
                Password = "Password",
                PhoneNumber = 123,
                PersonAccessRoleId = roleid,
                Salary = 123
            });
        static int dismissStateWorkingId = new EmployeeDismissStateService()
                                            .CreateEmployeeDismissState(
                new EmployeeDismissStateDTO()
                {
                    EmployeeDismissStateName = "Working"
                });
        static int dismissStateDismissingId = new EmployeeDismissStateService().CreateEmployeeDismissState(
                new EmployeeDismissStateDTO() { EmployeeDismissStateName = "Dismissing" });

       
            
        
        [TestMethod]
        public void TestEmployeeDismiss_CreateDismissEmployment_CorrectResult()
        {

            //arrange                                  
            bool result=false;
            var employeeDismiss = service
                            .GetEmployeeDismissByEmployeeId(employeeId)
                            .LastOrDefault();
             
            if (employeeDismiss.idEmployeeDismissState==1)           
                    service.DismissEmployee(employeeId);
            //act          
            result = service.EmploymentEmployee(employeeId); 
                      
            var employeeDismissTest = service
                            .GetEmployeeDismissByEmployeeId(employeeId)
                            .LastOrDefault();
           
            //assert

            Assert.AreEqual(result, true);
            Assert.AreEqual(employeeDismissTest.idEmployee, employeeId);
            Assert.AreEqual(employeeDismissTest.idEmployeeDismissState, dismissStateWorkingId);
            Assert.AreEqual(employeeDismissTest.EmploymentDate, DateTime.Now.ToShortDateString());
            Assert.AreEqual(employeeDismissTest.DismissDate, null);

        }
        [TestMethod]
        public void TestEmployeeDismiss_UpdateEmploymentToDismiss_CorrectResult()
        {
            //arrange 
            bool result = false;
            service.EmploymentEmployee(employeeId);
            
            //act

            result = service.DismissEmployee(employeeId);

            var employeeDismissTest = service
                            .GetEmployeeDismissByEmployeeId(employeeId)
                            .LastOrDefault();

            //assert
            Assert.AreEqual(result, true);
            Assert.AreEqual(employeeDismissTest.idEmployee, employeeId);
            Assert.AreEqual(employeeDismissTest.idEmployeeDismissState, dismissStateDismissingId);
            Assert.AreNotEqual(employeeDismissTest.DismissDate, null);
            Assert.AreEqual(employeeDismissTest.DismissDate, DateTime.Now.ToShortDateString());
        }
        [TestMethod]
        public void TestEmployeeDismiss_GetDismissByEmployeeId_CorrectResult()
        {
            var employeeDismiss = service
                             .GetEmployeeDismissByEmployeeId(employeeId)
                             .LastOrDefault();

             Assert.AreEqual(employeeDismiss.idEmployee, employeeId);
             Assert.AreNotEqual(employeeDismiss.EmploymentDate, null);
             Assert.AreNotEqual(employeeDismiss.idEmployeeDismissState, 0);
        }
        [TestMethod]
        public void TestEmployeeDismiss_GetAllDismisses_CorrectResult()
        {
            //arrange   
            service.EmploymentEmployee(employeeId);

            var result = service.GetAllEmployeesDismiss();           

            Assert.AreNotEqual(0, result.ToList().Count);
        }
    }
}
