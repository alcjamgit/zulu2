using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class StockTransaction
    {
        public Guid Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int SecurityId { get; set; }
        public string SignalName { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("SecurityId")]
        public virtual Security Security { get; set; }
    }
}
