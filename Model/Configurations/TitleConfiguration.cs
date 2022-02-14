using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Titles>
    {
        public void Configure(EntityTypeBuilder<Titles> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
