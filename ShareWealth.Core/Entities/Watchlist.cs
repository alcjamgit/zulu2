using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class Watchlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<WatchlistSecurity> WatchlistSecurities { get; set; }
    }
}
