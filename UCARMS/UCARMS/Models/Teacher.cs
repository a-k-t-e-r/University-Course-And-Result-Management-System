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
    [TableName("Teacher")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Teacher Name")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        [Column(TypeName = "varchar")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "@ allocate string range (2 to 100 charecters) @")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Teacher Address")]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 2)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It"), RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        [DisplayName("Email Address")]
        [Column(TypeName = "varchar")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "@ allocate string range (2 to 100 charecters) @")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Contact No.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "@ allocate string range (2 to 100 charecters) @")]
        [Column(TypeName = "varchar")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("$ Designation $")]
        public int DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Credit to be Taken")]
        [Range(4.5, 20.0, ErrorMessage = "@ the range must be in 4.5 to 20.0 @")]
        public decimal Credit { get; set; }
    }
}