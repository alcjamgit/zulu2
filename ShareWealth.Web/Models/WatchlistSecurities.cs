using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWealth.Web.Models
{
    public class WatchlistSecurities
    {
        public Guid Id { get; set; }
        public int SecurityId { get; set; }
        public string SecurityCode { get; set; }
        public string SecurityName { get; set; }
        public string Exchange { get; set; }
        public Guid WatchlistId { get; set; }
    }
}