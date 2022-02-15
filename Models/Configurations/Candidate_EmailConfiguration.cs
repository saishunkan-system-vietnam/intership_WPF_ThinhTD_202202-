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
    public class Candidate_EmailConfiguration : IEntityTypeConfiguration<Candidate_Email>
    {
        public void Configure(EntityTypeBuilder<Candidate_Email> builder)
        {
            builder.HasKey(x => x.CandidateID);
            builder.HasOne(x => x.Candidate)
                .WithOne(x => x.Candidate_Email);
            builder.Property(x => x.Status)
                .IsRequired(false);
            builder.Property(x => x.Contactable)
                .IsRequired(false);
            builder.Property(x => x.Note)
                .IsRequired(false);
        }

    }
}
