using EFProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace EFProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Add_Student()
        {
            using (var db = new SchoolContext())
            {
                // create a group
                var group1 = new Group { Name = "Class A", Year = 9 };
                var group2 = new Group { Name = "Class A", Year = 10 };
                var group3 = new Group { Name = "Class A", Year = 11 };

                db.Groups.AddRange(group1, group2, group3);

                // create some students and add them to the group
                var student1 = new Student { Name = "John", Surname = "Doe", Group = group1 };
                var student2 = new Student { Name = "Jane", Surname = "Doe", Group = group1 };
                
                db.Students.AddRange(student1, student2);

                // add student info for each student
                var studentInfo1 = new StudentInfo
                {
                    FatherName = "Jack",
                    FatherSurname = "Doe",
                    MotherName = "Jill",
                    MotherSurname = "Doe",
                    FatherPhone = "123456789",
                    MotherPhone = "987654321",
                    FatherEmail = "jack.doe@example.com",
                    Address = "123 Main St"
                };
                student1.StudentInfo = studentInfo1;

                var studentInfo2 = new StudentInfo
                {
                    FatherName = "Jim",
                    FatherSurname = "Doe",
                    MotherName = "Janet",
                    MotherSurname = "Doe",
                    FatherPhone = "555555555",
                    MotherPhone = "666666666",
                    FatherEmail = "jim.doe@example.com",
                    Address = "456 High St"
                };
                student2.StudentInfo = studentInfo2;

                // create some teachers
                var teacher1 = new Teacher { Name = "Mr. Smith", Surname = "Smithers", Salary = 50000 };
                var teacher2 = new Teacher { Name = "Ms. Johnson", Surname = "Johnsonson", Salary = 60000 };
                db.Teachers.AddRange(teacher1, teacher2);

                // create some subjects and assign them to teachers
                var subject1 = new Subject { Name = "Math", Teacher = teacher1 };
                var subject2 = new Subject { Name = "Science", Teacher = teacher2 };
                db.Subjects.AddRange(subject1, subject2);

                // add grades for each student
                var grade1 = new Grades { Students = student1, Subject = subject1, GradeValue = 80 };
                var grade2 = new Grades { Students = student1, Subject = subject2, GradeValue = 90 };
                var grade3 = new Grades { Students = student2, Subject = subject1, GradeValue = 70 };
                var grade4 = new Grades { Students = student2, Subject = subject2, GradeValue = 85 };
                db.Grades.AddRange(grade1, grade2, grade3, grade4);

                // save changes to the database
                db.SaveChanges();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Add_Student();
            using (var Context = new SchoolContext())
            {
                Context.Database.EnsureCreated();
                var time = new Stopwatch();
                time.Start();
                dataGridView1.DataSource = Context.Students.ToList();
                time.Stop();
                MessageBox.Show($"Query executed in {time.Elapsed}");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                //MessageBox.Show(Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value));
                using (var Context = new SchoolContext())
                {
                    var studentGrades = Context.Grades
                        .Where(grade => grade.StudentId == dataGridView1.SelectedRows[0].Cells[0].Value as int?)
                        .Join(Context.Subjects, grade => grade.SubjectId, subject => subject.Id, (grade, subject) => new { Grade = grade, Subject = subject })
                        .Join(Context.Teachers, gs => gs.Subject.TeacherId, teacher => teacher.Id, (gs, teacher) => new { SubjectName = gs.Subject.Name, GradeValue = gs.Grade.GradeValue, TeacherName = teacher.Name })
                        .Select(result => new { SubjectName = result.SubjectName, GradeValue = result.GradeValue, TeacherName = result.TeacherName });
                    var studentInfo = Context.Students
                        .Where(student => student.id == dataGridView1.SelectedRows[0].Cells[0].Value as int?)
                        .Select(student => student.StudentInfo);
                    try
                    {
                        dataGridView2.DataSource = studentInfo.ToList();
                        dataGridView3.DataSource = studentGrades.ToList();
                    }
                    catch
                    {
                        MessageBox.Show("Grades haven`t been found.");
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Grades");
                context.Database.ExecuteSqlRaw("DELETE FROM Students");
                context.Database.ExecuteSqlRaw("DELETE FROM Groups");
                context.Database.ExecuteSqlRaw("DELETE FROM Subjects");
                context.Database.ExecuteSqlRaw("DELETE FROM Teachers");
                context.Database.ExecuteSqlRaw("DELETE FROM StudentInfos");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                dataGridView1.DataSource = context.Students.Where(x => x.Name.StartsWith(textBox1.Text)).ToList();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form2 = new AddStudent();
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Student();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var context = new SchoolContext())
            {
                if(dataGridView1.SelectedRows.Count == 1)
                {
                    var student = context.Students.Include(s => s.Grades).SingleOrDefault(s => s.id == dataGridView1.SelectedRows[0].Cells[0].Value as int?);

                    if (student != null)
                    {
                        context.Grades.RemoveRange(student.Grades);

                        context.Students.Remove(student);

                        context.SaveChanges();
                    }
                    dataGridView1.DataSource = context.Students.ToList();
                }
                else
                {
                    MessageBox.Show("Select a student.");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var GradesEdit = new GradesEdit(dataGridView1.SelectedRows[0].Cells[0].Value as int?);
                GradesEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a student.");
            }
        }
    }
}