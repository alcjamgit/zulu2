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
    public class ScanController : ApiController
    {
        private DataService _data;


        public ScanController()
        {
            _data = new DataService();
        }

        // GET: api/Scan
        [Route("api/scan")]
        public IEnumerable<ScanProfile> Get()
        {
            return _data.GetScanProfiles();
        }

        // GET: api/Scan/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Scan
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Scan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Scan/5
        public void Delete(int id)
        {
        }
    }
}
