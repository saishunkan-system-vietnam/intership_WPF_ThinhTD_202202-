using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName);
            builder.Property(x => x.Email)
                .HasMaxLength(200)
                .HasColumnType("varchar");
            builder.Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(12);
        }
    }
}
