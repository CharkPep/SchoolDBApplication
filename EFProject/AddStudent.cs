using EFProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EFProject
{
    public partial class AddStudent : Form
    {
        System.Drawing.Image image = null!;
        public AddStudent()
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
            var Form4 = new AddGroup();
            Form4.ShowDialog();
            dataGridView2.DataSource = (new SchoolContext()).Groups.ToList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var Form3 = new AddParents();
            Form3.ShowDialog();
            dataGridView1.DataSource = (new SchoolContext()).StudentInfos.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1 && dataGridView2.SelectedRows.Count == 1)
            {
                byte[] byteArray = null!;
                if(image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, image.RawFormat);
                        byteArray = ms.ToArray();
                    }

                }
                using (var context = new SchoolContext())
                {
                    var student = new Student()
                    {
                        Name = textBox1.Text,
                        Surname = textBox2.Text,
                        Phone = textBox3.Text,
                        Email = textBox4.Text,
                        Image = null,
                        Group = context.Groups.Find(dataGridView2.SelectedRows[0].Cells[0].Value as int?),
                        StudentInfo = context.StudentInfos.Find(dataGridView1.SelectedRows[0].Cells[0].Value as int?)
                    };
                    context.Add(student);
                    context.SaveChanges();

                }
            }
            else
            {
                MessageBox.Show("Select Student Parent`s information and Group");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                var rowToDelete = context.StudentInfos.Find(dataGridView1.SelectedRows[0].Cells[0].Value as int?);
                context.StudentInfos.Remove(rowToDelete);
                context.SaveChanges();
                dataGridView1.DataSource = context.StudentInfos.ToList();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                var rowToDelete = context.Groups.Find(dataGridView2.SelectedRows[0].Cells[0].Value as int?);
                context.Groups.Remove(rowToDelete);
                context.SaveChanges();
                dataGridView2.DataSource = context.Groups.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.DataSource == null)
            {
                dataGridView1.DataSource = (new SchoolContext()).StudentInfos.ToList();
            }
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                selectedRow.Selected = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(dataGridView2.DataSource == null)
            {
                dataGridView2.DataSource = (new SchoolContext()).Groups.ToList();
            }
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                selectedRow.Selected = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
            }
        }
    }
}
