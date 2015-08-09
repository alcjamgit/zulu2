using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWealth.Web.Models
{
    public class StockTransactionVm
    {
        public DateTime TransactionDate { get; set; }
        public int SecurityId { get; set; }
        public string SecurityCode { get; set; }
        public string SignalName { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public double Brokerage { get; set; }
        public double Price { get; set; }
        public double TradeValue {
            get { return Quantity * Price; }
        }
    }
}