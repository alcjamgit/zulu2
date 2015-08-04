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
    public class TransactionController : ApiController
    {
        private DataService _dataService;

        public TransactionController()
        {
            _dataService = new DataService();
        }
        // GET: api/Transaction
        [Route("api/stockTransactions")]
        public IEnumerable<StockTransaction> Get()
        {

            return _dataService.GetStockTransactions();
        }

        // GET: api/Transaction/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transaction
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Transaction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transaction/5
        public void Delete(int id)
        {
        }
    }
}
