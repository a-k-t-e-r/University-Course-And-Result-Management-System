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
    [TableName("Semester")]
    public class Semester
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Semester")]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "Think, You Forgot It")]
        public string Name { get; set; }
    }
}