using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetailsDesktop.Models
{
    public class User
    {
        [Column("userId")]
        public int UserId { get; set; }
        [Column("name")]
        public string UserName { get; set; }
        [Column("dob")]
        public DateTime DateOfBirth { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("isActive")]
        public int IsActive { get; set; }
    }
}
