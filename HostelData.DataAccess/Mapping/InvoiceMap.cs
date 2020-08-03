using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.DataAccess.Mapping
{
    public class InvoiceMap : BaseMap<Invoice>
    {
        public InvoiceMap()
        {
            ToTable("Invoices");
            Property(x => x.Electrical).HasColumnType("money").IsOptional();
            Property(x => x.Internet).HasColumnType("money").IsOptional();
            Property(x => x.Warm).HasColumnType("money").IsOptional();
            Property(x => x.Water).HasColumnType("money").IsOptional();
        }
    }
}
