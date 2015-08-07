using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWealth.Core.Entities
{
    public class ScanProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public bool Locked { get; set; }

        public string ScanType { get; set; }
        public string Parameters { get; set; }
        public string ChartOptions { get; set; }
        public bool Entry { get; set; }
        public bool Exit { get; set; }
        public bool Pyramid { get; set; }
        public bool Lighten { get; set; }

        public string TimeFrameType { get; set; }
        public int Period { get; set; }
        public string PeriodType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public virtual ICollection<ScanResult> ScanResults { get; set; }
    }
}
