using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class Security
    {
        public int Id { get; set; }
        public string SecurityCode { get; set; }
        public string SecurityName { get; set; }
        public string Exchange { get; set; }

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

        public virtual ICollection<StockPrice> StockPrices { get; set; }
        public virtual ICollection<WatchlistSecurity> WatchlistSecurities { get; set; }
    }
}
