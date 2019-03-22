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
    [TableName("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Course Code")]
        [Column(TypeName = "varchar")]
        [StringLength(11, MinimumLength = 3, ErrorMessage = "Minimum length must be 3 and Maximum will be 11")]
        public string Code { get; set; }

        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [Column(TypeName = "varchar")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Minimum character is 2 and max 30")]
        public string Name { get; set; }

        [DisplayName("Course Credit")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [Range(0.5, 5.0, ErrorMessage = "@ the range must be in 0.5 to 5.0 @")]
        [Column(TypeName = "decimal")]
        public decimal Credit { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "@ allocate string range (2 to 30 charecters) @")]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Semester")]
        public int SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }
}