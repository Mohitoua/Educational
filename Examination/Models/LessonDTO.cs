using System.ComponentModel.DataAnnotations;

namespace Examination.Models
{
    public class LessonDTO
    {
        [Required, MaxLength(3)]
        public string? LCode { get; set; }
        [Required, MaxLength(30)]
        public string? LName { get; set; }
        [Required]
        public int LGrade { get; set; }
        [Required, MaxLength(20)]
        public string? LTeacherName { get; set; }
        [MaxLength(20)]
        public string? LTeacherSurname { get; set; }
    }
}
