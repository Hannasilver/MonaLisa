using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HDipl_Hanna3.Models;

namespace HDipl_Hanna3.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<Clients> Client { get; set; }
        public DbSet<Services> Service { get; set; }
        public DbSet<Employees> Employee { get; set; }
        public object Index()
        {
            throw new NotImplementedException();
        }

        public ClientContext() : base("ClientService")
        {

        }
      
    }
}