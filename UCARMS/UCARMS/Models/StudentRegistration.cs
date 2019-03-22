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
    [TableName("StudentRegistration")]
    public class StudentRegistration
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Registration No.")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [Column(TypeName = "varchar")]
        public string StuRegNo { get; set; }

        [DisplayName("Student Name")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3)]
        public string StuName { get; set; }

        [DisplayName("E-mail")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Contact Number")]
        [Column(TypeName = "varchar")]
        [StringLength(11, ErrorMessage = "Put Contact Which Have At Least 11 Number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Registration Date")]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Student Address")]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum Length Must Be 5 & Maximux 50")]
        public string Address { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}