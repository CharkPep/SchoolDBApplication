
namespace EFProject.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int GradeValue { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}