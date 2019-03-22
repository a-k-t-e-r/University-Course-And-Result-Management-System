using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace UCARMS.Models
{
    [TableName("StudentResult")]
    public class StudentResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Registration No.")]
        [Column(TypeName = "varchar")]
        public string StudentRegistrationNum { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Required]
        [DisplayName("Course")]
        public int CourseId { get; set; }

        [ForeignKey("GradeLetterId")]
        public GradeLetter GradeLetter { get; set; }

        [Required]
        [DisplayName("Grade Letter")]
        public int GradeLetterId { get; set; }
    }
}