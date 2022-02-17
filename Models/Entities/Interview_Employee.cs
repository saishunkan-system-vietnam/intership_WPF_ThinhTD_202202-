using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Interview_Employee
    {
        public int Id { get; set; }
        public int InterViewId { get; set; }
        public virtual Interview Interview { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
