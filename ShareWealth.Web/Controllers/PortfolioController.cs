using ShareWealth.Core.Entities;
using ShareWealth.Infrastructure.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShareWealth.Web.Controllers
{
    public class PortfolioController : ApiController
    {
        private ApplicationDbContext _db;
        public PortfolioController()
        {
            _db = new ApplicationDbContext();
            _db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Portfolio
        [Route("api/portfolios")]
        public IEnumerable<Portfolio> Get()
        {
            var portfolios = from p in _db.Portfolios
                             select p;
            return portfolios;
        }

        [Route("api/portfolios/{id}")]
        public Portfolio Get(Guid id)
        {
            var portfolio = (from p in _db.Portfolios
                             where p.Id == id
                             select p).FirstOrDefault();
            return portfolio;
        }
        // GET: api/Portfolio/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Portfolio
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Portfolio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Portfolio/5
        public void Delete(int id)
        {
        }
    }
}
