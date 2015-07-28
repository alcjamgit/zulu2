using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWealth.Web.Models
{
    public class Security
    {
        public int Id { get; set; }
        public string SecurityCode { get; set; }
        public string SecurityName { get; set; }
        public string Exchange { get; set; }
        public string Symbol { 
            get{
                var firstLetter = this.SecurityCode[0].ToString();
                return firstLetter == "$" || firstLetter == "#" ? this.SecurityCode[1].ToString() : firstLetter;
            }
        }
    }
}