using EFProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProject
{
    public partial class AddParents : Form
    {
        public AddParents()
        {
            InitializeComponent();
        }
        public bool IsEmailValid(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Create a regular expression object
            Regex regex = new Regex(pattern);

            // Check if the email matches the pattern
            return regex.IsMatch(email);
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
                context.SaveChanges();
            }
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
