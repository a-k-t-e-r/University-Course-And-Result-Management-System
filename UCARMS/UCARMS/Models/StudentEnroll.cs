using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UCARMS.Models
{
    public class StudentEnroll
    {
        [Key]
        public byte Id { get; set; }

        [DisplayName("Registration No.")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        public string StudentRegistrationNo { get; set; }

        [DisplayName("Student Name")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        public string StudentName { get; set; }

        [DisplayName("E-mail")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [DisplayName("Department")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        public string Department { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public int CourseId { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Date")]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}