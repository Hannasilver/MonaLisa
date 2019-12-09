using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDipl_Hanna3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDipl_Hanna3.Models;
using System.Web.Mvc;

namespace HDipl_Hanna3.Controllers.Tests
{
    [TestClass()]
    public class EmployeesControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            ClientContext employeesContext = new ClientContext();
            Assert.IsNotNull(employeesContext.Service);
        }
        [TestMethod()]
        public void CreateTest()
        {
            {
                ClientContext cl = new ClientContext();
                Employees employees = new Employees()
                {
                    EmployeeId = "3",
                    FirstName ="Adam",
                    Surname = "Braun"
                };
                cl.Employee.Add(employees);

            }
        }
    }
}