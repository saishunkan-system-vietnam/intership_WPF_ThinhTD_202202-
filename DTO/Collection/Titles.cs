﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Titles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Candidate> Candidates { get; set; }
    }
}
