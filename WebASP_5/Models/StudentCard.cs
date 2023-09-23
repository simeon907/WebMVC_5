using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebASP_5.Models
{
    public class StudentCard
    {
        [Key]
        [ForeignKey("Student")]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Series { get; set; }

        public virtual Student Student { get; set; }
    }
}