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
    public class Interview_EmployeeConfiguration : IEntityTypeConfiguration<Interview_Employee>
    {
        public void Configure(EntityTypeBuilder<Interview_Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Interview)
                .WithMany(x => x.Interview_Employee)
                .HasForeignKey(x => x.InterViewId);
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Interview_Employee)
                .HasForeignKey(x => x.EmployeeId);
        }

    }
}
