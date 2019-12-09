using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Text.RegularExpressions;
using HDipl_Hanna3.Models;

namespace HDipl_Hanna3.Controllers
{
    [RoutePrefix("api/ClientsAPI")]
    public class ClientsApi2Controller : ApiController
    {
        private ClientContext db = new ClientContext();
        // GET: api/ClientsApi2
        [Route("all/clients")]
        [HttpGet]
        public IHttpActionResult GetAllClients()
        {
            return Ok(db.Client.OrderByDescending(c => c.ID).ToList());

        }

        // GET: api/ClientsApi2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ClientsApi2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ClientsApi2/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        [HttpPut]
        public HttpResponseMessage Put(int id,[FromBody]Clients value)
        {


            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to find that Client");
            }
            var record =db.Client.SingleOrDefault(p => p.ID == id);
            if (record == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to find that Customer");
            }

            try
            {
                record.Name = value.Name;
                record.Surname = value.Surname;
                record.PhoneNumber = value.PhoneNumber;
                record.EmailAddress = value.EmailAddress;
                record.ServiceId = value.ServiceId;
                record.EmployeeId = value.EmployeeId;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Record updated");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Update operation failed with exception {0}", e.Message);
            }
        }

        // GET: api/ClientsApi2/ByClient/{name}
        [Route("ByClientName/{name}")]
        [HttpGet]
        public IEnumerable<string> GetByKeyWord(string name)
        {
            string clientName = db.Client.FirstOrDefault(p => p.Name.Equals(name)).Name;

            var results = db.Client.Where(p => p.Name.Equals(name));
            if (results == null)
            {
                return null;
            }

            List<string> ClientList = new List<string>();
            foreach (Clients d in results)
            {
                ClientList.Add(d.Name);
                ClientList.Add(d.Surname);
                ClientList.Add(d.PhoneNumber);
                ClientList.Add(d.EmailAddress);
                ClientList.Add(d.ServiceId);
                ClientList.Add(d.EmployeeId);

            }
            return ClientList;
        }

        // GET: api/ClientsApi2/ByClient/{id}
        [Route("ByClient/{id}")]
        [HttpGet]
        public IEnumerable<string> GetByID(int id)
        {
            int clientID = db.Client.FirstOrDefault(p => p.ID.Equals(id)).ID;

            var results = db.Client.Where(p => p.ID.Equals(clientID));
            if (results == null)
            {
                return null;
            }

            List<string> ClientList = new List<string>();
            foreach (Clients d in results)
            {
                
                ClientList.Add(d.Name);
                ClientList.Add(d.Surname);
                ClientList.Add(d.PhoneNumber);
                ClientList.Add(d.EmailAddress);
                ClientList.Add(d.ServiceId);
                ClientList.Add(d.EmployeeId);

            }
            return ClientList;

        }
        // DELETE: api/ClientsApi2/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var record = db.Client.FirstOrDefault(p => p.ID == id);

            if (record == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to find that Movie");
            }

            try
            {
                db.Client.Remove(record);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted");

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "DELETE operation failed with exception {0}", e.Message);
            }
        }
    }
}
