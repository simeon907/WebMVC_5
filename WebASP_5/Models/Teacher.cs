using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebASP_5.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "від 2 до 30")]
        [RegularExpression("[А-ЯІЇҐЄ][^ЭЫЪЁ]{1}[а-яіїґє'][^ыэъё]{1,29}", ErrorMessage = "Некоректно")]
        public string FirstName { get; set; }

        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "від 2 до 20")]
        [RegularExpression("[А-ЯІЇҐЄ][^ЭЫЪЁ]{1}[а-яіїґє'][^ыэъё]{1,29}", ErrorMessage = "Некоректно")]
        public string LastName { get; set; }

        [Display(Name = "Дата народження")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Пошта")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(100)]
        [RegularExpression(@"(?<name>[\w.]+)\@(?<domain>\w+\.\w+)(\.\w+)?", ErrorMessage = "Некоректна адреса")]
        [DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Display(Name = "Фото")]
        public string PhotoFile { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

        public Teacher()
        {
            Subjects = new List<Subject>();
            Groups = new List<Group>();
        }
    }
}