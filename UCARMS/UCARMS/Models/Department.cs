using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UCARMS.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [StringLength(11, MinimumLength = 2, ErrorMessage = "@ allocate string range (2 to 11 charecters) @")]
        [Column(TypeName = "varchar")]
        [DisplayName("Department Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "@ allocate string range (2 to 100 charecters) @")]
        [Column(TypeName = "varchar")]
        [DisplayName("Department Name")]
        public string Name { get; set; }
    }
}