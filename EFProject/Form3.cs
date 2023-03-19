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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                context.Add(new StudentInfo() { FatherName = textBox1.Text, 
                    FatherSurname = textBox2.Text, 
                    MotherName = textBox3.Text, 
                    MotherSurname = textBox4.Text, 
                    FatherPhone = textBox5.Text, 
                    MotherPhone = textBox6.Text,
                    FatherEmail = textBox7.Text,
                    Address= textBox8.Text,
                });
            }
        }
    }
}
