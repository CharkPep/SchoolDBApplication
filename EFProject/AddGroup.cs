using EFProject.Models;
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
    public partial class AddGroup : Form
    {
        public AddGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                context.Add(new Group() { Name = textBox1.Text, Year = Convert.ToInt32(textBox2.Text) });
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
