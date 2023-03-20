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
    public partial class AddGrade : Form
    {
        int? studentId = null;
        public AddGrade()
        {
            InitializeComponent();
        }
        public AddGrade(int? studentId) : this()
        {
            this.studentId = studentId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var Context = new SchoolContext())
            {
                dataGridView1.DataSource = Context.Subjects.ToList();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var Context = new SchoolContext())
            {
                dataGridView2.DataSource = Context.Teachers.ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1 && dataGridView2.SelectedRows.Count == 1)
            {
                using(var Context = new SchoolContext())
                {
                    //Context.Add(new Subject() { Name = textBox1.Text, Teacher = Context.Teachers.Find(dataGridView1.SelectedRows[0].Cells[0]), Sub });

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                if(dataGridView2.SelectedRows.Count == 1)
                {
                    var subject = new Subject() { Name = textBox1.Text, Teacher = context.Teachers.Find(dataGridView2.SelectedRows[0].Cells[0].Value as int?) };
                    context.Add(subject);
                    //context.Add(new Grades() { Subject = subject, Students = context.Students.Find(studentId), GradeValue = Convert.ToInt32(textBox2.Text) });
                    context.SaveChanges();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                if (dataGridView2.SelectedRows.Count == 1)
                {
                    context.Grades.Remove(context.Grades.Find(dataGridView2.SelectedRows[0].Cells[0].Value as int?));
                    context.SaveChanges();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    context.Add(new Grades() { Subject = context.Subjects.Find(dataGridView1.SelectedRows[0].Cells[0].Value as int?), Students = context.Students.Find(studentId), GradeValue = Convert.ToInt32(textBox2.Text) });
                    context.SaveChanges();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                context.Add(new Teacher() { Name = textBox3.Text, Surname = textBox4.Text, Salary = Convert.ToInt32(textBox5.Text) });
                context.SaveChanges();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                context.Remove(context.Teachers.Find(dataGridView2.SelectedRows[0].Cells[0].Value as int?));
                context.SaveChanges();
            }
        }
    }
}
