
namespace EFProject.Models
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string FatherName { get; set; } = null!;
        public string FatherSurname { get; set; } = null!;
        public string MotherName { get; set; } = null!;
        public string MotherSurname { get; set; } = null!;
        public string FatherPhone { get; set; } = null!;
        public string MotherPhone { get; set; } = null!;
        public string FatherEmail { get; set; } = null!;
        public string Address { get; set; } = null!;

    }
}