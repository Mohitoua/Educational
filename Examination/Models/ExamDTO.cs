using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Examination.Models
{
    public class ExamDTO
    {
        [Required, MaxLength(3)]
        public string? LCode { get; set; }
        [Required]
        public int PCode { get; set; }
        public DateTime EDate { get; set; }
        [Precision(5,2)]
        public decimal EPrice { get; set; }
    }
}
