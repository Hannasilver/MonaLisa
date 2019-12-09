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
    public class ClientsAPIbyClientIDControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            ClientContext clContext = new ClientContext();
            Clients clients = new Clients()
            {
                ID = 1,
                AppointmentDate = new
           DateTime(2020, 8, 1, 10, 00, 00),
                ServiceId = "HIFU",
                EmployeeId ="Amanda",
                Name = "Saroo",
                Surname =
           "Nann",
                PhoneNumber = "0855565521",
                EmailAddress = "sar@sar.ie.com"
            };

        }
        [TestMethod()]
        public void CreateTest()
        {

            ClientContext cl = new ClientContext();// object of db
            Services ser = new Services()
            {
                ServiceId = "7",
                ServiceDescritption =
           "Vampire Facelift",
                Price = 25
            };
            cl.Service.Add(ser);
            //adding service in order to book appointment
            cl.Client.Add(
            new Clients()
            {
                ID = 1,
                AppointmentDate = new
           DateTime(2020, 8, 1, 10, 00, 00),
                ServiceId = "HIFU",
                EmployeeId = "Amanda",
                Name = "Saroo",
                Surname ="Nann",
                PhoneNumber = "0855565521",
                EmailAddress = "sar@sar.ie.com"
            });
        }
    }
}