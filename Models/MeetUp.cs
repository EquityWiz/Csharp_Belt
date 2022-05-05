using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DojoMUC.Models
{
    public class MeetUp
    {
        [Key]
        public int MeetUpId { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date of meet up is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date and Time")]
        [FutureDate]
        public DateTime DateTime { get; set; }
        [Required]
        [DataType(DataType.Duration)]
        public string Duration {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Participant> Participation { get; set; }
        public int UserId { get; set; }
        public User Creator { get; set; }
    }
}