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
    public class TestEmployeeService
    {
        static string CurrentEmployeeLastName { get; set; } = "EmployeeLastName";

        IEmployeeService service = new EmployeeService();
        EmployeeDTO CreateEmployee()
        {
            int RoleId = new PersonAccessRoleService()
                                   .CreatePersonAccessRole(
                       new PersonAccessRoleDTO()
                       {
                           PersonAccessRoleName = "Employee"
                       });
   
            return new EmployeeDTO()
            {
                Name = "EmployeeName",
                Surname = "EmployeeSurname",
                LastName = "EmployeeLastName",
                PhoneNumber=15478511,
                Salary=15487,
                PersonAccessRoleId= RoleId,
                Email = "EmployeeEmail",
                Password = "EmployeePassword"
            };
        }
        int SeedDismissState()
        {
            int resultID = 0;
            //act
            if (service.GetAllEmployees().Count() == 0||
                service.GetEmployeeByExpression(x=>x.LastName==CurrentEmployeeLastName)==null)
            {
                resultID = service.CreateEmployee(CreateEmployee());
            }
            else
            {
                resultID = service.GetAllRecordsEmployeeByExpression(x => x.LastName == CurrentEmployeeLastName).LastOrDefault().Id;
            }
            return resultID;
        }
            

        [TestMethod]
        public void TestEmployee_CreateEmployeeNamedHome_CorrectResult()
        {
            //arrange 
            int resultID = 0;
            //act 
            resultID = SeedDismissState();

            var employeeDismissTest = new EmployeeDismissService()
                            .GetEmployeeDismissByEmployeeId(resultID)
                            .LastOrDefault();
            //assert
            Assert.AreEqual(CurrentEmployeeLastName, service.GetEmployeeById(resultID).LastName);
            Assert.AreEqual(employeeDismissTest.idEmployee, resultID);
            Assert.AreEqual(employeeDismissTest.idEmployeeDismissState, 1);
            Assert.AreEqual(employeeDismissTest.EmploymentDate, DateTime.Now.ToShortDateString());
            Assert.AreEqual(employeeDismissTest.DismissDate, null);
        }
        [TestMethod]
        public void TestEmployee_UpdateEmployeeNamedHomeToOffice_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            resultID = SeedDismissState();
            //act
            EmployeeDTO getEmployee = service.GetEmployeeById(resultID);
            getEmployee.LastName = "Sumsonov";
            service.UpdateEmployee(getEmployee);
            CurrentEmployeeLastName = "Sumsonov";
            //assert
            Assert.AreEqual(CurrentEmployeeLastName, service.GetEmployeeById(resultID).LastName);
        }
        [TestMethod]
        public void TestEmployee_GetEmployeeNamedHomeById_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            resultID = SeedDismissState();

            Assert.AreEqual(CurrentEmployeeLastName, service.GetEmployeeById(resultID).LastName);
        }
        [TestMethod]
        public void TestEmployee_GetAllEmployeees_CorrectResult()
        {
            //arrange  
            int resultID = 0;
            resultID = SeedDismissState();
            //act

            Assert.AreNotEqual(0, service.GetAllEmployees().ToList().Count);

        }
    }
}
