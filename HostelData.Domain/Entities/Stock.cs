using HostelData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Domain.Entities
{
    public class Stock : BaseModel
    {
        public decimal Toast { get; set; }
        public decimal Hamburger { get; set; }
        public decimal Chips { get; set; }
        public decimal Cola { get; set; }
        public decimal Fanta { get; set; }
        public decimal Soda { get; set; }
        public decimal TotalBeverage { get; set; }
        public decimal TotalFood { get; set; }
    }
}
