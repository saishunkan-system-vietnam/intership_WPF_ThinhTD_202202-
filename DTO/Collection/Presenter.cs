using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Presenter
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual List<CandidateToAdd> Candidates { get; set; }
    }
}
