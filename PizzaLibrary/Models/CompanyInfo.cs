using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public sealed class CompanyInfo
    {
        public string Vat { get; set; }
        public string Cvr { get; set; }
        public string Name { get; set; }
        public int ClubDiscount { get; set; }
        public CompanyInfo(string vat, string cvr, string name, int clubDiscount)
        {
            Vat = vat;
            Cvr = cvr;
            Name = name;
            ClubDiscount = clubDiscount;
            
        }
    }
}
