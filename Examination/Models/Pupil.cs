using System.ComponentModel.DataAnnotations;

namespace Examination.Models
{
    public class Pupil
    {
        public int Id { get; set; }
        public int PCode { get; set; }
        [MaxLength(20)]
        public string? PName { get; set; }
        [MaxLength(20)]
        public string? PSurname { get; set; }
        public int PGrade { get; set; }
    }
}
