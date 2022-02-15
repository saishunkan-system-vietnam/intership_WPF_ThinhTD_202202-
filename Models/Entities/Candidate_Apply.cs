using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Models.Entities
{
    public class Candidate_Apply
    {
        public int CandidateId { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public virtual Candidate Candidate { get; set; }
        public Candidate_Apply()
        {

        }
        public Candidate_Apply(int candidateId, int status, string note)
        {
            CandidateId = candidateId;
            Status = status;
            Note = note;
        }
    }
}
