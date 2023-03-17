namespace EFProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}