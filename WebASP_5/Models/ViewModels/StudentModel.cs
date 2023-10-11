using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebASP_5.Models.ViewModels
{
    public class StudentModel
    {
        [System.Web.Mvc.HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "від 2 до 30")]
        [RegularExpression("[А-ЯІЇҐЄ][^ЭЫЪЁ]{1}[а-яіїґє'][^ыэъё]{1,29}", ErrorMessage = "Некоректно")]
        public string LastName { get; set; }

        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "від 2 до 20")]
        //[RegularExpression("[А-ЯІЇҐЄ][^ЭЫЪЁ]{1}[а-яіїґє'][^ыэъё]{1,29}", ErrorMessage = "Некоректно")]
        public string FirstName { get; set; }


        [Display(Name = "Дата народження")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Пошта")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(100)]
        [RegularExpression(@"(?<name>[\w.]+)\@(?<domain>\w+\.\w+)(\.\w+)?", ErrorMessage = "Некоректна адреса")]
        //[DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Display(Name = "Стипендія")]
        [Range(2000, 2750, ErrorMessage = "Від 2000 до 2750")]
        public double? Grant { get; set; }

        [Display(Name = "Фото")]
        public string PhotoFile { get; set; }



        [Display(Name = "Номер картки")]
        [Range(1000, 9999, ErrorMessage = "Від 1000 до 9999")]
        public int Number { get; set; }

        [Display(Name = "Підтвердження номеру картки")]
        [Compare("Number", ErrorMessage = "Значення не збігаються")]
        public int NumberConfirm { get; set; }

        [Display(Name = "Серія картки")]
        [System.Web.Mvc.Remote("RemoteSeries", "Student", HttpMethod = "post", ErrorMessage = "Неприпустима")]
        public string Series { get; set; }



        [Display(Name = "Група")]
        [Required(ErrorMessage = "Поле має бути заповнено")]
        [StringLength(20)]
        [Index(IsUnique = true)]
        //[RegularExpression("^[А-Я0-9][^ЭЫЪЁ]{1,19}$")]
        public string GroupName { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }
    }
}