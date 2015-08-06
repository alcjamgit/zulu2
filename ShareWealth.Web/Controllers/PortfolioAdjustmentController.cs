using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareWealth.Web.Models;

namespace ShareWealth.Web.Controllers
{
    public class PortfolioAdjustmentController : ApiController
    {
        // GET: api/Portfolio
        public IEnumerable<PortfolioAdjustment> Get(int id)
        {
            var allAdjustments = new List<PortfolioAdjustment> {
                new PortfolioAdjustment { Id = 1, Date = new DateTime(2004,6,30), PortfolioId = 1, Amount = 50000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = 2, Date = new DateTime(2006,12,22), PortfolioId = 1, Amount = 10000, Type = "Addition" },
                new PortfolioAdjustment { Id = 3, Date = new DateTime(2007,3,15), PortfolioId = 1, Amount = 2500, Type = "Withdrawal" },
                new PortfolioAdjustment { Id = 4, Date = new DateTime(2013,8,30), PortfolioId = 2, Amount = 75000, Type = "Initial Investment" },
                new PortfolioAdjustment { Id = 5, Date = new DateTime(2014,11,15), PortfolioId = 2, Amount = 3500, Type = "Addition" },
                new PortfolioAdjustment { Id = 6, Date = new DateTime(2014,4,12), PortfolioId = 2, Amount = 60800, Type = "Withdrawal" }
            };
            var adjustments = from a in allAdjustments
                              where a.PortfolioId == id
                              select a;
            return adjustments;
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
