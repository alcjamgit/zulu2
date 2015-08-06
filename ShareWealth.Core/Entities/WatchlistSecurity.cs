using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class WatchlistSecurity
    {
        public int Id { get; set; }
        public int WatchlistId { get; set; }
        public int SecurityId { get; set; }

        [ForeignKey("SecurityId")]
        public Security Security { get; set; }
        [ForeignKey("WatchlistId")]
        public Watchlist Watchlist { get; set; }
    }
}
