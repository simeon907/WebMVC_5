using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebASP_5.Models;

namespace WebASP_5.DbClasses
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("University")
        {
            
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<StudentCard> StudentCards { get; set; }

        public System.Data.Entity.DbSet<WebASP_5.Models.ViewModels.Person> People { get; set; }
    }
}