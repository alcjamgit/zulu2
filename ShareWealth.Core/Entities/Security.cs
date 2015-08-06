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

        public virtual ICollection<StockPrice> StockPrices { get; set; }
        public virtual ICollection<WatchlistSecurity> WatchlistSecurities { get; set; }
    }
}
