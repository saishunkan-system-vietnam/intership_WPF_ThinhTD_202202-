using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for popAddCandidate.xaml
    /// </summary>
    public partial class popAddCandidate : Window
    {
        public Candidate candidate { get; set; }
        public popAddCandidate()
        {
            InitializeComponent();
        }
        public popAddCandidate(Candidate candidate)
        {
            this.candidate = candidate;
            InitializeComponent();
        }
    }
}
