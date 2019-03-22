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
    [TableName("CourseAssign")]
    public class CourseAssign
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Taken Credit")]
        [Column(TypeName = "decimal")]
        public decimal CreditTaken { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Remain Credit")]
        [Column(TypeName = "decimal")]
        public decimal CreditRemain { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Course Code")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Course Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "@ allocate string range (2 to 100 charecters) @")]
        [Column(TypeName = "varchar")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "@ the range must be in 0.5 to 5.0 @")]
        [Column(TypeName = "decimal")]
        public decimal CourseCredit { get; set; }
    }
}