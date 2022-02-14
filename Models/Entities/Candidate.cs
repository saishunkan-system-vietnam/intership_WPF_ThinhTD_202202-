using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;

namespace Models.Entities
{
    public class Candidate
    {
        [NotMapped]
        public int SortNumber { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public int TitleID { get; set; }
        public byte[] CVFile { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PositionId { get; set; }
        public int PresenterId { get; set; }
        public virtual Position Position { get; set; }
        public virtual Presenter Presenter { get; set; }
        public virtual Titles Title { get; set; }
        [NotMapped]
        public ICommand Edit { get; set; }
        [NotMapped]
        public ICommand Delete { get; set; }
        [NotMapped]
        public ICommand ViewCV { get; set; }
    }
}