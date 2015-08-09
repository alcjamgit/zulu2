using ShareWealth.Web.Models;
using ShareWealth.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareWealth.Infrastructure.DataLayer;
using ShareWealth.Core.Entities;

namespace ShareWealth.Web.Controllers
{
    public class TransactionController : ApiController
    {
        private DataService _dataService;
        private ApplicationDbContext _db;

        public TransactionController()
        {
            _dataService = new DataService();
            _db = new ApplicationDbContext();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Transaction
        [Route("api/stockTransactions")]
        public HttpResponseMessage Get()
        {
            var transactions = from t in _db.StockTransactions
                               select new StockTransactionVm {
                                   TransactionDate = t.TransactionDate,
                                   Price = t.Price,
                                   Quantity = t.Quantity,
                                   SecurityId = t.SecurityId,
                                   SecurityCode = t.Security.SecurityCode,
                                   SignalName = t.SignalName,
                                   Brokerage = 30,
                                   TransactionType = t.TransactionType
                               };
            return Request.CreateResponse(HttpStatusCode.OK, transactions);
            //return _dataService.GetStockTransactions();
        }

        [HttpPost]
        [Route("api/addStockTransaction")]
        public HttpResponseMessage Post([FromBody]StockTransactionVm transactionVm)
        {
            var id = Guid.NewGuid();
            var entity = new StockTransaction {
                Id = id,
                TransactionDate = transactionVm.TransactionDate,
                Quantity = transactionVm.Quantity,
                SignalName = transactionVm.SignalName,
                Price = transactionVm.Price
            };
            _db.StockTransactions.Add(entity);
            _db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, transactionVm);
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
