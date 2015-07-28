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
    public class WatchlistSecuritiesController : ApiController
    {
        private DataService _data;
        public WatchlistSecuritiesController()
        {
            _data = new DataService();
        }
        // GET: api/WatchlistSecurities
        public IEnumerable<WatchlistSecurities> Get()
        {
            return _data.GetWatchlistSecurities();
        }

        // GET: api/WatchlistSecurities/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WatchlistSecurities
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WatchlistSecurities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WatchlistSecurities/5
        public void Delete(int id)
        {
        }
    }
}
