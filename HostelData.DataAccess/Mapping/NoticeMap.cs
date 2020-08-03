using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.DataAccess.Mapping
{
    public class NoticeMap : BaseMap<Notice>
    {
        public NoticeMap()
        {
            ToTable("Notices");
            Property(x => x.NoticeText).HasMaxLength(500).IsRequired();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();

        }
    }
}
