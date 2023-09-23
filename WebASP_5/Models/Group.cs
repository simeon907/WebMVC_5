using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebASP_5.Models
{
    public class Group
    {
        public int Id { get; set; }
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