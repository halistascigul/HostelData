using HostelData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Domain.Entities
{
    public class Room : BaseModel
    {
        public int RoomNumber { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
