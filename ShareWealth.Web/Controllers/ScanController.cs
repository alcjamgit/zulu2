using ShareWealth.Web.Models;
using ShareWealth.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ShareWealth.Infrastructure.DataLayer;

namespace ShareWealth.Web.Controllers
{
    public class ScanController : ApiController
    {
        private ApplicationDbContext _db;
        private DataService _data;

        public ScanController()
        {
            _data = new DataService();
            _db = new ApplicationDbContext();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        

        [Route("api/scanprofiles")]
        public IEnumerable<ScanProfile> GetScanProfiles()
        {
            return _data.GetScanProfiles();
        }

        [Route("api/scanprofiles/add")]
        public HttpResponseMessage PostScanProfiles([FromBody] ScanProfile scanProfile)
        {
            scanProfile.Id = 75;
            return Request.CreateResponse(HttpStatusCode.Created, scanProfile);

        }

        [Route("api/scanresults")]
        public HttpResponseMessage GetScanResults()
        {
            var scans = from s in _db.ScanResults
                        select s;
            return Request.CreateResponse(HttpStatusCode.OK, scans);

            //return _data.GetScanResults();
        }

        [Route("api/scans/{id}")]
        public HttpResponseMessage GetScanItem(Guid id)
        {
            var scanItem = (from s in _db.ScanResults
                        where s.Id == id
                        select s).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, scanItem);

            //return _data.GetScanResults();
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
