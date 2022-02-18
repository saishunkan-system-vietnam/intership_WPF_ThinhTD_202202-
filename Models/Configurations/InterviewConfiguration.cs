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
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Candidate_Apply)
                .WithMany(x => x.Interview)
                .HasForeignKey(x => x.Candidate_ApplyId);
            builder.Property(x => x.Status)
                .IsRequired(false);
            builder.Property(x => x.Contactable)
                .IsRequired(false);
            builder.Property(x => x.Note)
                .IsRequired(false);
            builder.Property(x => x.InterviewLocation)
                .IsRequired(false);
            builder.Property(x => x.IsPass)
                .IsRequired(false);
            builder.Property(x => x.InterviewTime);
            builder.Property(x => x.Attachment)
                .IsRequired(false);
            builder.Property(x => x.Attachment_Name)
                .IsRequired(false);
            builder.Property(x => x.Title)
                .IsRequired(false);
            builder.Property(x => x.ContentEmail)
                .IsRequired(false);
            builder.Property(x => x.MeetingRoom)
                .IsRequired(false);
        }

    }
}
