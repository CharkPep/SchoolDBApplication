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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var Context = new SchoolContext())
            {
                dataGridView1.DataSource = Context.StudentInfos.ToList();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var Context = new SchoolContext())
            {
                dataGridView2.DataSource = Context.Groups.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Form3 = new Form3();
            Form3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form4 = new Form4();
            Form4.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1 && dataGridView2.SelectedRows.Count == 1)
            {

            }
            else
            {
                MessageBox.Show("Select Student Parent`s information and Group");
            }
        }
    }
}
