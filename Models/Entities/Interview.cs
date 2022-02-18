using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Interview
    {
        public int Id { get; set; }
        public int Candidate_ApplyId { get; set; }
        public DateTime InterviewTime { get; set; }
        public string? InterviewLocation { get; set; }
        public string? Note { get; set; }
        public bool? IsPass { get; set; }
        public string? Title { get; set; }
        public string? ContentEmail { get; set; }
        public int? Contactable { get; set; }
        public int? Status { get; set; }
        public byte[]? Attachment { get; set; }
        public string? Attachment_Name { get; set; }
        public string? MeetingRoom { get; set; }
        [NotMapped]
        public string Contactable_Name { get; set; }
        [NotMapped]
        public string Status_Name { get; set; }
        [NotMapped]
        public virtual Candidate_Apply Candidate_Apply { get; set; }
        public virtual List<Interview_Employee> Interview_Employee { get; set; }
    }
}
