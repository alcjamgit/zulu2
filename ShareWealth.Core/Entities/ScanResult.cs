using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class ScanResult
    {
        public int Id { get; set; }
        public string SecurityCode { get; set; }
        public DateTime SignalDate { get; set; }
        public DateTime ActionDate { get; set; }
        public string SignalName { get; set; }
        public string SignalType { get; set; }
        public double SignalPrice { get; set; }
        public int ScanProfileId { get; set; }

        [ForeignKey("ScanProfileId")]
        public ScanProfile ScanProfile { get; set; }
    }
}
