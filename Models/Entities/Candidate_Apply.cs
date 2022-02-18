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
        [NotMapped]
        public int SortNumber { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
        public int CandidateId { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public string? Title { get; set; }
        public string? ContentEmail { get; set; }
        public bool? IsAccept { get; set; }
        public bool? CanBeContacted { get; set; }
        public byte[]? Attachment { get; set; }
        public int? TestPoint { get; set; }
        public string? Attachment_Name { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual List<Interview> Interview { get; set; }
        [NotMapped]
        public Interview Inter { get; set; }
        [NotMapped]
        public Interview GetInterView { get; set; }
        [NotMapped]
        public ICommand ViewEmail { get; set; }
        [NotMapped]
        public ICommand AcceptInterView { get; set; }
        [NotMapped] 
        public ICommand RefuseInterView { get; set; }
        [NotMapped] 
        public ICommand AddInterview { get; set; }
        [NotMapped]
        public ICommand EditInterview { get; set; }
        [NotMapped]
        public ICommand PassInterview { get; set; }
        [NotMapped]
        public ICommand DeleteInterview { get; set; }
        [NotMapped]
        public ICommand AddPoint { get; set; }
        [NotMapped]
        public string Accecpt_Name { get; set; }
        [NotMapped]
        public string Status_Name { get; set; }
        [NotMapped]
        public bool Preview { get; set; }
        [NotMapped]
        public bool EnableAddInter { get; set; }
        [NotMapped]
        public bool EnableEditInter { get; set; }
        [NotMapped]
        public bool enablePointButton { get; set; }
        public Candidate_Apply()
        {

        }
        public Candidate_Apply(int candidateId, int status, string note, string title, string contentEmail, bool isAccept, byte[] attachment, string attachment_Name)
        {
            CandidateId = candidateId;
            Status = status;
            Note = note;
            Title = title;
            ContentEmail = contentEmail;
            Attachment = attachment;
            Attachment_Name = attachment_Name;
        }
    }
}
