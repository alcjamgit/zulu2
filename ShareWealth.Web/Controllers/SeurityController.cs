using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareWealth.Web.Models;

namespace ShareWealth.Web.Controllers
{
    public class SeurityController : ApiController
    {

        private IEnumerable<Security> _securities = new List<Security> { 
                new Security { Id = 1, SecurityCode = "BHP", SecurityName = "BHP Systems", Exchange = "XASX" },
                new Security { Id = 2, SecurityCode = "XAO", SecurityName = "BHP Systems", Exchange = "XASX" },
                new Security { Id = 3, SecurityCode = "EWW", SecurityName = "BHP Systems", Exchange = "XASX" },
                new Security { Id = 4, SecurityCode = "COMP", SecurityName = "BHP Systems", Exchange = "XASX" },
                new Security { Id = 5, SecurityCode = "NASDAQ", SecurityName = "BHP Systems", Exchange = "XASX" },
            };

        // GET: api/Seurity
        public IEnumerable<Security> Get()
        {
            return _securities;
        }

        // GET: api/Seurity/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Seurity
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Seurity/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Seurity/5
        public void Delete(int id)
        {
        }
    }
}
