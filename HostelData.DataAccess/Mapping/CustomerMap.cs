using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelData.DataAccess.Mapping
{
    public class CustomerMap : BaseMap<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customers");
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.Surname).HasMaxLength(50).IsRequired();
            Property(x => x.Phone).HasMaxLength(30);
            Property(x => x.Email).HasMaxLength(100);
            HasIndex(x => x.Email).IsUnique();
            Property(x => x.IdentityNumber).IsRequired();
            HasIndex(x => x.IdentityNumber).IsUnique();
            Property(x => x.Pay).HasColumnType("money");
            Property(x => x.EntryDate).HasColumnType("datetime2");
            Property(x => x.ReleaseDate).HasColumnType("datetime2");
            Property(x => x.Gender).HasColumnType("nvarchar");
            Property(x => x.RoomNumber).IsRequired();
            Property(x => x.SoldCola).IsOptional();
            Property(x => x.SoldFanta).IsOptional();
            Property(x => x.SoldSoda).IsOptional();
            Property(x => x.SoldToast).IsOptional();
            Property(x => x.SoldHamburger).IsOptional();
            Property(x => x.SoldChips).IsOptional();
            Property(x => x.TotalAmount).HasColumnType("money").IsOptional();

            HasMany(x => x.Rooms)
                .WithMany(x => x.Customers)
                .Map(x => x.MapLeftKey("Rooms").MapRightKey("Customers").ToTable("RoomsCustomers"));
        }
    }
}
