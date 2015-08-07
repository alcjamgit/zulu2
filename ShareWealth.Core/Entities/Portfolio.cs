using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class Portfolio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public string Currency { get; set; }
        public string Exchange { get; set; }
        public string WatchlistName { get; set; }

        public string RiskOption { get; set; }
        public int MaxOpenPositions { get; set; }
        public double AllocationRisk { get; set; }
        public double MinBrokerage { get; set; }
        public double BrokeragePercentage { get; set; }
        public double BrokerageThreshold { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public virtual ICollection<PortfolioAdjustment> PortfolioAdjustments { get; set; }
    }
}
