using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShareWealth.Core.Entities;
using ShareWealth.Infrastructure.DataLayer;
using ShareWealth.Web.Filters;
using ShareWealth.Web.Models;

namespace ShareWealth.Web.Controllers
{
    public class WatchlistController : ApiController
    {

        private ApplicationDbContext _db;
        public WatchlistController()
        {
            _db = new ApplicationDbContext();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Watchlist
        public HttpResponseMessage Get()
        {
            var wl = from w in _db.Watchlists
                     select w;
            var response = Request.CreateResponse(HttpStatusCode.OK, wl.ToList());
            return response;


        }

        //http://stackoverflow.com/questions/10732644/best-practice-to-return-errors-in-asp-net-web-api
        [Route("api/watchlist/add")]
        public HttpResponseMessage Post([FromBody] WatchlistVm watchlist)
        {
            if (ModelState.IsValid)
            {
                var wl = new Watchlist
                {
                    Id = Guid.NewGuid(),
                    Name = watchlist.Name,
                    Type = watchlist.Type,
                };
            
                _db.Watchlists.Add(wl);
                _db.SaveChanges();
                watchlist.Id = wl.Id;
                return Request.CreateResponse(HttpStatusCode.Created, watchlist);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
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
