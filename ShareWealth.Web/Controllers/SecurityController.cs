using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareWealth.Web.Models;
using ShareWealth.Web.Services;

namespace ShareWealth.Web.Controllers
{
    public class SecurityController : ApiController
    {

        private DataService _data;

        public SecurityController()
        {
            _data = new DataService();
        }

        // GET: api/Seurity
        public IEnumerable<Security> Get()
        {
            return _data.GetSecurities();
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
