using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareWealth.Web.Models;

namespace ShareWealth.Web.Controllers
{
    public class WatchlistController : ApiController
    {
        private IEnumerable<Watchlist> _watchlistData = new List<Watchlist> {
            new Watchlist { Id=1 , Name = "ETF Watch List" , Type = "System" },
            new Watchlist { Id=2 , Name = "SPA3 Watch List" , Type = "System" },
            new Watchlist { Id=3 , Name = "Open Trades" , Type = "Portfolio" },
            new Watchlist { Id=4 , Name = "Prospect Watch List" , Type = "User Defined" },
            new Watchlist { Id=5 , Name = "All Ordinaries" , Type = "Industry" },
            new Watchlist { Id=6 , Name = "ASX Dividend Paying Securities" , Type = "Industry" },
            new Watchlist { Id=7 , Name = "ASX Franked Dividend Paying Securities" , Type = "Industry" },
            new Watchlist { Id=8 , Name = "ASX Fully Paid Ordinary" , Type = "Industry" },
            new Watchlist { Id=9 , Name = "ASX Positive PE Ratio Securities" , Type = "Industry" },
            new Watchlist { Id=10 , Name = "Dow Jones Composite Average" , Type = "Industry" },
            new Watchlist { Id=11 , Name = "Dow Jones Industrial Average" , Type = "Industry" },
            new Watchlist { Id=12 , Name = "Dow Jones Transportation Average" , Type = "Industry" },
            new Watchlist { Id=13 , Name = "Dow Jones US Index" , Type = "Industry" },
            new Watchlist { Id=14 , Name = "Dow Jones Utility Average" , Type = "Industry" },
            new Watchlist { Id=15 , Name = "IG Markets ASX Share CFDs" , Type = "Industry" },
            new Watchlist { Id=16 , Name = "IG Markets ASX Share CFDs Shortable" , Type = "Industry" },
            new Watchlist { Id=17 , Name = "IG Markets US Share CFDs" , Type = "Industry" },
            new Watchlist { Id=18 , Name = "IG Markets US Share CFDs Shortable" , Type = "Industry" },
            new Watchlist { Id=19 , Name = "NASDAQ 100" , Type = "Industry" },
            new Watchlist { Id=20 , Name = "NASDAQ Bank" , Type = "Industry" },
            new Watchlist { Id=21 , Name = "NASDAQ Biotechnology" , Type = "Industry" },
            new Watchlist { Id=22 , Name = "NASDAQ Common Shares" , Type = "Industry" },
            new Watchlist { Id=23 , Name = "NASDAQ Computer" , Type = "Industry" },
            new Watchlist { Id=24 , Name = "NASDAQ Financial 100" , Type = "Industry" },
            new Watchlist { Id=25 , Name = "NASDAQ Industrial" , Type = "Industry" },
            new Watchlist { Id=26 , Name = "NASDAQ Insurance" , Type = "Industry" },
            new Watchlist { Id=27 , Name = "NASDAQ Other Finance" , Type = "Industry" },
            new Watchlist { Id=28 , Name = "NASDAQ Telecommunications" , Type = "Industry" },
            new Watchlist { Id=29 , Name = "NASDAQ Transportation" , Type = "Industry" },
            new Watchlist { Id=30 , Name = "Russell 1000" , Type = "Industry" },
            new Watchlist { Id=31 , Name = "Russell 2000" , Type = "Industry" },
            new Watchlist { Id=32 , Name = "Russell 3000" , Type = "Industry" },
            new Watchlist { Id=33 , Name = "Russell Micro Cap" , Type = "Industry" },
            new Watchlist { Id=34 , Name = "Russell Mid Cap" , Type = "Industry" },
            new Watchlist { Id=35 , Name = "S&P 100" , Type = "Industry" },
            new Watchlist { Id=36 , Name = "S&P 500" , Type = "Industry" },
            new Watchlist { Id=37 , Name = "S&P ASX100" , Type = "Industry" },
            new Watchlist { Id=38 , Name = "S&P ASX20" , Type = "Industry" },
            new Watchlist { Id=39 , Name = "S&P ASX200" , Type = "Industry" },
            new Watchlist { Id=40 , Name = "S&P ASX300" , Type = "Industry" },
            new Watchlist { Id=41 , Name = "S&P ASX50" , Type = "Industry" },
            new Watchlist { Id=42 , Name = "S&P Composite 1500" , Type = "Industry" },
            new Watchlist { Id=43 , Name = "S&P MidCap 400" , Type = "Industry" },
            new Watchlist { Id=44 , Name = "S&P SmallCap 600" , Type = "Industry" },
            new Watchlist { Id=45 , Name = "S&P/ASX Emerging Companies" , Type = "Industry" },
            new Watchlist { Id=46 , Name = "S&P/ASX MidCap 50" , Type = "Industry" },
            new Watchlist { Id=47 , Name = "S&P/ASX MidCap 50 Industrials" , Type = "Industry" },
            new Watchlist { Id=48 , Name = "S&P/ASX MidCap 50 Resources" , Type = "Industry" },
            new Watchlist { Id=49 , Name = "S&P/ASX Small Industrials" , Type = "Industry" },
            new Watchlist { Id=50 , Name = "S&P/ASX Small Ordinaries" , Type = "Industry" },
            new Watchlist { Id=51 , Name = "S&P/ASX Small Resources" , Type = "Industry" },
            new Watchlist { Id=52 , Name = "Saxo Capital Markets ASX Share CFDs" , Type = "Industry" },
            new Watchlist { Id=53 , Name = "Saxo Capital Markets ASX Share CFDs Shortable" , Type = "Industry" },
            new Watchlist { Id=54 , Name = "Saxo Capital Markets US Share CFDs" , Type = "Industry" },
            new Watchlist { Id=55 , Name = "Saxo Capital Markets US Share CFDs Shortable" , Type = "Industry" },
            new Watchlist { Id=56 , Name = "USA - Closed-End Fund Share" , Type = "Industry" },
            new Watchlist { Id=57 , Name = "USA - Common" , Type = "Industry" },
            new Watchlist { Id=58 , Name = "USA - Exchange Traded Fund" , Type = "Industry" },
            new Watchlist { Id=59 , Name = "USA - Exchange Traded Note" , Type = "Industry" },
            new Watchlist { Id=60 , Name = "USA - OTCBB" , Type = "Industry" },
            new Watchlist { Id=61 , Name = "USA - Other OTC" , Type = "Industry" },
            new Watchlist { Id=62 , Name = "USA - Pink OTC Markets" , Type = "Industry" },
            new Watchlist { Id=63 , Name = "USA - Preference" , Type = "Industry" }
        };
        // GET: api/Watchlist
        public IEnumerable<Watchlist> Get()
        {
            return _watchlistData;
        }

        [Route("api/watchlist/add")]
        public HttpResponseMessage Post([FromBody] Watchlist watchlist)
        {
            watchlist.Id = 66;
            //watchlist.Name = "Changed in the server";
            var response = Request.CreateResponse(HttpStatusCode.Created, watchlist);
            return response;
        }

        // POST: api/Watchlist
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Watchlist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Watchlist/5
        public void Delete(int id)
        {
        }
    }
}
