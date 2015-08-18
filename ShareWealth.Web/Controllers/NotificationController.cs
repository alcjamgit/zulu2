using ShareWealth.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShareWealth.Web.Controllers
{
    public class NotificationController : ApiController
    {
        private IEnumerable<Notification> _notifications = new List<Notification> { 
                new Notification { Id = 1, Message = "Buy XAO Stocks", Type = "Scans", Symbol = "B" },
                new Notification { Id = 2, Message = "Exit BHP Stocks", Type = "Scans", Symbol = "S" },
                new Notification { Id = 3, Message = "Upcoming Dividends for $COMP", Type = "Dividends", Symbol = "D" },
                new Notification { Id = 4, Message = "Exit EWH Stocks", Type = "Scans", Symbol = "S" },
                new Notification { Id = 5, Message = "Pyramid for DJI", Type = "Scans", Symbol = "P" },
            };

        private IEnumerable<OpenTrade> _openTrades = new List<OpenTrade> { 
                new OpenTrade { SecurityCode = "SLF", SecurityName = "SPDR S&P/ASX200 Listed Fund", MarketValue = 1563.63 },
                new OpenTrade { SecurityCode = "SFY", SecurityName = "SPDR S&P/ASX50 Fund", MarketValue = 214.28 },
                new OpenTrade { SecurityCode = "STW", SecurityName = "SPDR S&P/ASX200 Fund", MarketValue = 1438.92 },
                new OpenTrade { SecurityCode = "BHP", SecurityName = "BHP Billiton Ltd", MarketValue = 2713.54 },
        };

        // GET: api/Notification
        [Route("api/Notification")]
        public IEnumerable<Notification> Get()
        {
            return _notifications;
        }

        // GET: api/Notification
        [Route("api/OpenTrades")]
        public IEnumerable<OpenTrade> GetOpenTrades()
        {
            return _openTrades;
        }

        // GET: api/Notification/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Notification
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Notification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Notification/5
        public void Delete(int id)
        {
        }
    }
}
