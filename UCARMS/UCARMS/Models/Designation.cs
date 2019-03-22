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
    [TableName("Designation")]
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Think, You Forgot It")]
        [DisplayName("Teacher Designation")]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }
    }
}