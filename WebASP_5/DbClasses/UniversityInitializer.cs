using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebASP_5.Models;
using System.Data.Entity.Infrastructure;

namespace WebASP_5.DbClasses
{
    public class UniversityInitializer : DropCreateDatabaseAlways<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            try
            {
                Student student = new Student
                {
                    FirstName = "Боб",
                    LastName = "Марлі",
                    BirthDate = new DateTime(2000, 12, 12),
                    Email = "bobmarley@gmail.com",
                    Grant = 2000.0,
                    PhotoFile = "bob.jpg"
                };
                context.Students.Add(student);

                StudentCard studentCard = new StudentCard
                {
                    Id = student.Id,
                    Number = 4592,
                    Series = "ФН"
                };
                context.StudentCards.Add(studentCard);

                Group group = new Group
                {
                    GroupName = "39ПР31",
                    Students = new List<Student> { student }
                };
                context.Groups.Add(group);
                context.Groups.Add(new Group { GroupName = "ПВ217" });

                Subject subject = new Subject
                {
                    SubjectName = "ASP.NET"
                };
                subject.Students.Add(student);
                subject.Teachers.Add(new Teacher
                {
                    LastName = "Сімпсон",
                    FirstName = "Гомер",
                    BirthDate = new DateTime(1984, 10, 18),
                    Email = "homersimpson999@gmail.com"
                });
                context.Subjects.Add(subject);
                context.Subjects.Add(new Subject
                {
                    SubjectName = "JavaScript"
                });

                context.SaveChanges();
            }
            catch
            {

                throw;
            }

            base.Seed(context);
        }
    }
}