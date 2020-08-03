using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Core.Model
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
