using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWealth.Web.Models
{
    public class ScanResult
    {
        public string SecurityCode { get; set; }
        public DateTime SignalDate { get; set; }
        public DateTime ActionDate { get; set; }
        public string SignalName { get; set; }
        public string SignalType { get; set; }
        public double SignalPrice { get; set; }
    }
}