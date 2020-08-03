using HostelData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Domain.Entities
{
    public class Notice : BaseModel
    {
        public string UserName { get; set; }
        public string NoticeText { get; set; }
    }
}
