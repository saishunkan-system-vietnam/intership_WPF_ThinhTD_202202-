using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(20)
                .HasColumnType("varchar");
            builder.Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(10);
            builder.HasOne(x => x.Title)
                .WithMany(x => x.Candidates)
                .HasForeignKey(x => x.TitleID);
            builder.HasOne(x => x.Position)
                .WithMany(x => x.Candidates)
                .HasForeignKey(x => x.PositionId);
            builder.HasOne(x => x.Presenter)
                .WithMany(x => x.Candidates)
                .HasForeignKey(x => x.PresenterId);
        }
    }
}
