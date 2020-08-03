using HostelData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Domain.Entities
{
    public class Invoice : BaseModel
    {
        public decimal Electrical { get; set; }
        public decimal Water { get; set; }
        public decimal Warm { get; set; }
        public decimal Internet { get; set; }
        public decimal TotalElectrical { get; set; }
        public decimal TotalWater { get; set; }
        public decimal TotalWarm { get; set; }
        public decimal TotalInternet { get; set; }
    }
}
