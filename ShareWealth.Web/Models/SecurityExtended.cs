using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWealth.Web.Models
{
    public class SecurityExtended: Security
    {
        public string Type { get; set; }
        public string GicsSector { get; set; }
        public string IcbIndustry { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public DateTime LastDate { get; set; }
        public double MarketCap { get; set; }
    }
}