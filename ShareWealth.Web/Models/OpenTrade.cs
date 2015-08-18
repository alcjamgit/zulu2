using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWealth.Web.Models
{
    public class OpenTrade
    {
        public string SecurityCode { get; set; }
        public string SecurityName { get; set; }
        public double MarketValue { get; set; }
    }
}