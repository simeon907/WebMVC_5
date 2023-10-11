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

        [Display(Name = "Номер")]
        [Range(1000, 9999, ErrorMessage = "Від 1000 до 9999")]
        public int Number { get; set; }

        [Display(Name = "Серія")]
        public string Series { get; set; }

        public virtual Student Student { get; set; }
    }
}