using System.ComponentModel.DataAnnotations;

namespace Examination.Models
{
    public class PupilDTO
    {
        [Required]
        public int PCode { get; set; }
        [Required, MaxLength(20)]
        public string? PName { get; set; }
        [MaxLength(20)]
        public string? PSurname { get; set; }
        [Required]
        public int PGrade { get; set; }   
    }
}
