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

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var Context = new SchoolContext())
            {
                dataGridView1.DataSource = Context.Grades
                        .Where(grade => grade.StudentId == studentId)
                        .Join(Context.Subjects, grade => grade.SubjectId, subject => subject.Id, (grade, subject) => new { Grade = grade, Subject = subject })
                        .Join(Context.Teachers, gs => gs.Subject.TeacherId, teacher => teacher.Id, (gs, teacher) => new { SubjectName = gs.Subject.Name, GradeValue = gs.Grade.GradeValue, TeacherName = teacher.Name })
                        .Select(result => new { SubjectName = result.SubjectName, GradeValue = result.GradeValue, TeacherName = result.TeacherName }).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var AddGrade = new AddGrade(studentId);
            AddGrade.ShowDialog();
        }
    }
}
