using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class Student
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public byte[]? Image { get; set; }

        public int GradeId { get; set; }
        public int GroupId { get; set; }

        public virtual Grades Grade { get; set; }
        public virtual Group Group { get; set; }

        public virtual StudentInfo StudentInfo { get; set; }

    }
}
