using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UCARMS.Models
{
    public class ClassAllocation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Class Room")]
        public int ClassRoomId { get; set; }

        [ForeignKey("ClassRoomId")]
        public virtual ClassRoom ClassRoom { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Day")]
        public int DayId { get; set; }

        [ForeignKey("DayId")]
        public virtual Day Day { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Date From")]
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Date To")]
        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }
    }
}