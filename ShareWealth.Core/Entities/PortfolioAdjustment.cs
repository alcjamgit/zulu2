using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class PortfolioAdjustment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public Guid PortfolioId { get; set; }
        public double Amount { get; set; }

        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolio { get; set; }
    }
}
