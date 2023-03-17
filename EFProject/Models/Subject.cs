
namespace EFProject.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TeacherId { get; set; }

        public virtual ICollection<Grades> Grades { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}