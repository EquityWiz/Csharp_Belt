using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DojoMUC.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public MeetUp MeetUp { get; set; }
        public int MeetUpId { get; set; }
    }
}