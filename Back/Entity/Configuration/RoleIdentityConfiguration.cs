using Entity.Core.authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Configuration
{
    class RoleIdentityConfiguration : IEntityTypeConfiguration<roleIdentity>
    {
        public void Configure(EntityTypeBuilder<roleIdentity> builder)
        {
            builder.HasData(
                new roleIdentity
                {
                    Id = 1,
                    Name = "SystemAdmin",
                    NormalizedName = "SystemAdmin".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }, new roleIdentity
                {
                    Id = 2,
                    Name = "Supplier",
                    NormalizedName = "Supplier".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }, new roleIdentity
                {
                    Id = 3,
                    Name = "Member",
                    NormalizedName = "Member".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );
        }
    }
}
