
namespace EFProject.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}