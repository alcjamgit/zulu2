using ShareWealth.Web.Models;
using ShareWealth.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShareWealth.Web.Controllers
{
    public class SecurityExtendedController : ApiController
    {
        private DataService _data;
        public SecurityExtendedController()
        {
            _data = new DataService();
        }
        // GET: api/SecurityExtended

        public IEnumerable<SecurityExtended> Get()
        {
            return _data.GetSecuritiesExtended();
        }

        // GET: api/SecurityExtended/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SecurityExtended
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SecurityExtended/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SecurityExtended/5
        public void Delete(int id)
        {
        }
    }
}
