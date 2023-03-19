using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProject
{
    public partial class GradesEdit : Form
    {
        int? studentId = null;
        public GradesEdit()
        {
            InitializeComponent();
        }
        public GradesEdit(int? StundetId) : this()
        {
            studentId = StundetId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                //dataGridView1.DataSource = new List<int>() { };
            }
        }
    }
}
