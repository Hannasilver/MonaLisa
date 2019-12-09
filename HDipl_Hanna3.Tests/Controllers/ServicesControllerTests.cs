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
    public class ServicesControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            ClientContext servicesContext = new ClientContext();
            Assert.IsNotNull(servicesContext.Service);
        }
        [TestMethod()]
        public void CreateTest()
        {
            {
                ClientContext cl = new ClientContext();
                Services services = new Services()
                {
                    ServiceId = "8",
                    ServiceDescritption =
               "TCA",
                    Price = 150
                };
                cl.Service.Add(services);

            }
        }
    }
}