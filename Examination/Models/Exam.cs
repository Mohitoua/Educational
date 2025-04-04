using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Examination.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [MaxLength(3)]
        public string? LCode { get; set; }
        public int PCode { get; set; }
        public DateTime EDate { get; set; }
        [Precision(5,2)]
        public decimal EPrice { get; set; }
    }
}
