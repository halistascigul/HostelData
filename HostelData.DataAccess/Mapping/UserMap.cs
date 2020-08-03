using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.DataAccess.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            ToTable("Users");
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(6).IsRequired();
        }
    }
}
