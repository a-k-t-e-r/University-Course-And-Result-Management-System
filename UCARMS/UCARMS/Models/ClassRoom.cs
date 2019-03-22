using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UCARMS.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Room Number")]
        [Column(TypeName = "varchar")]
        public string RoomNumber { get; set; }
    }
}