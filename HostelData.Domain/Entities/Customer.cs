using HostelData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.Domain.Entities
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long IdentityNumber { get; set; }
        public List<Room> Rooms { get; set; }
        public int RoomNumber { get; set; }
        public decimal Pay { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal TotalPay { get; set; }
        public byte SoldCola { get; set; }
        public byte SoldFanta { get; set; }
        public byte SoldSoda { get; set; }
        public byte SoldToast { get; set; }
        public byte SoldHamburger { get; set; }
        public byte SoldChips { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
