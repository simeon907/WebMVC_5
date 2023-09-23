using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP_5.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
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