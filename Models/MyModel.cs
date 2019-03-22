using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace exam.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Must be at least 8 Chars")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Password must contain 1 letter, 1 number and 1 special character and MUST be 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<RSVP> UserRSVP { get; set; }
    }
    public class Login
    {
        public int LogId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
    public class Activityclass
    {
        [Key]
        public int ActivityId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Must be at least two chars")]
        public string Act { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Musts be at last ten chars")]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [RegularExpression(@"\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))", ErrorMessage = "Time must be in hh/mm AM or PM")]
        public String Time { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<RSVP> ActRSVP { get; set; }
        public int UserId { get; set; }
        public User Coordinator { get; set; }

    }
    public class RSVP
    {
        [Key]
        public int RSVPId { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public User RSVPUser { get; set; }
        public Activityclass RSVPAct { get; set; }
    }
}