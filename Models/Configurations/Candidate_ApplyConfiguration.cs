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
    public class Candidate_ApplyConfiguration : IEntityTypeConfiguration<Candidate_Apply>
    {
        public void Configure(EntityTypeBuilder<Candidate_Apply> builder)
        {
            builder.HasKey(x => x.CandidateId);
            builder.HasOne(x => x.Candidate)
                .WithOne(x => x.CandiDate_Apply);
            builder.Property(x => x.Status)
                .IsRequired(false);
            builder.Property(x => x.Note)
                .IsRequired(false);
        }

    }
}
