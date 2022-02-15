using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Candidate_Email
    {
        public int CandidateID { get; set; }
        public string Title { get; set; }
        public string ContentEmail { get; set; }
        public int? Status { get; set; }
        public int? Contactable { get; set; }
        public DateTime InterviewTime { get; set; }
        public string InterviewLocation { get; set; }
        public string? Note { get; set; }
        public int TestPoint { get; set; }
        public virtual Candidate Candidate { get; set; }
        [NotMapped]
        public string Contactable_Status { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
    }
}
