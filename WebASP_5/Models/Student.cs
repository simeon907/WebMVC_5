using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebASP_5.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public double? Grant { get; set; }
        public string PhotoFile { get; set; }

        //public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual StudentCard StudentCard { get; set; }

        public Student()
        {
            Subjects = new List<Subject>();
        }
    }
}