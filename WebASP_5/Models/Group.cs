using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace WebASP_5.Models
{
    public class Group
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Група")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(20)]
        [Index(IsUnique = true)]
        [RegularExpression("^[А-Я0-9][^ЭЫЪЁ]{1,19}$", ErrorMessage = "Некоректно")]
        public string GroupName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public Group()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }
    }
}