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
    public class TitleConfiguration : IEntityTypeConfiguration<Titles>
    {
        public void Configure(EntityTypeBuilder<Titles> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
