using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using System.Text.RegularExpressions;
using HDipl_Hanna3.Models;


namespace HDipl_Hanna3.Controllers
{
    //[RoutePrefix("api/ClientsAPI")]
    public class ClientsApiController : ApiController
    {
        private readonly ClientContext db = new ClientContext();

        // GET: ClientsApi
        //[Route("all/clients")]
        [HttpGet]

        public IHttpActionResult GetAllClients()
        {
            return Ok(db.Client.OrderByDescending(c => c.ID).ToList());

        }

        // GET: ClientsApi/Details/5
        [Route("ByClient/{name}")]
        [HttpGet]
        public IEnumerable<string> GetByKeyWord(string name)
        {
            int clientID = db.Client.FirstOrDefault(p => p.Name.Equals(name)).ID;

            var results = db.Client.Where(p => p.ID.Equals(clientID));
            if (results == null)
            {
                return null;
            }

            List<string> ClientList = new List<string>();
            foreach (Clients d in results)
            {
                ClientList.Add(d.PhoneNumber);
                ClientList.Add(d.Name);
                ClientList.Add(d.Surname);

            }
            return ClientList;

        }
    }
}

