using System.ComponentModel.DataAnnotations;

namespace Examination.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        [MaxLength(3)]
        public string? LCode { get; set; }
        [MaxLength(30)]
        public string? LName { get; set; }
        public int LGrade { get; set; }
        [MaxLength(20)]
        public string? LTeacherName { get; set; }
        [MaxLength(20)]
        public string? LTeacherSurname { get; set; }
    }
}
