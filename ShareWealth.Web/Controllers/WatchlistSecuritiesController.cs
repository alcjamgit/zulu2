using ShareWealth.Web.Models;
using ShareWealth.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareWealth.Infrastructure.DataLayer;

namespace ShareWealth.Web.Controllers
{
    public class WatchlistSecuritiesController : ApiController
    {
        private DataService _data;
        public WatchlistSecuritiesController()
        {
            _data = new DataService();
            _db = new ApplicationDbContext();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        private ApplicationDbContext _db;

        // GET: api/WatchlistSecurities
        public HttpResponseMessage Get()
        {
            var sec = from ws in _db.WatchlistSecurities
                      select new WatchlistSecurities { 
                          Id = ws.Id,
                          SecurityId = ws.SecurityId,
                          SecurityCode = ws.Security.SecurityCode,
                          SecurityName = ws.Security.SecurityName,
                          WatchlistId = ws.WatchlistId,
                          Exchange = ws.Security.Exchange
                      };

            var response = Request.CreateResponse(HttpStatusCode.OK, sec.ToList());
            return response;
        }

        // GET: api/WatchlistSecurities/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WatchlistSecurities
        [Route("api/watchlists/add")]
        public HttpResponseMessage Post([FromBody]WatchlistVm wl)
        {
            return new HttpResponseMessage(HttpStatusCode.Created);
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
