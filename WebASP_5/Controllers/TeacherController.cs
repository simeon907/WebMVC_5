using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebASP_5.DbClasses;
using WebASP_5.Models;

namespace WebASP_5.Controllers
{
    public class TeacherController : Controller
    {
        private UniversityContext _context = new UniversityContext();

        // GET: Teacher
        public async Task<ActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        // GET: Teacher/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            ViewBag.Groups = _context.Groups.ToList();

            ViewBag.Subjects = _context.Subjects.ToList();

            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,BirthDate,Email,PhotoFile")] Teacher teacher,
            int[] subjects, int[] groups)
        {
            if (subjects != null && groups != null)
            {
                foreach (Subject subject in _context.Subjects.Where(s => subjects.Contains(s.Id)))
                {
                    (teacher.Subjects as List<Subject>).Add(subject);
                }

                foreach (Group group in _context.Groups.Where(g => groups.Contains(g.Id)))
                {
                    (teacher.Groups as List<Group>).Add(group);
                }

                if (_context.Teachers.Any(t => t.Email == teacher.Email))
                {
                    ModelState.AddModelError("Email", "Збіг елекронної адреси");
                }

                if ((DateTime.Today - teacher.BirthDate).TotalDays / 365.25 < 16)
                {
                    ModelState.AddModelError("BirthDate", "Несумісний вік");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (teacher.Groups == null || teacher.Subjects == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    Teacher t = new Teacher
                    {
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName,
                        BirthDate = teacher.BirthDate,
                        Email = teacher.Email,
                        Groups = new List<Group>(teacher.Groups),
                        Subjects = new List<Subject>(teacher.Subjects)
                    };

                    _context.Teachers.Add(t);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.ErrorMessage = "Помилка запису у базу даних";
                }
            }

            return View(teacher);
        }

        // GET: Teacher/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,BirthDate,Email,PhotoFile")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(teacher).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teacher/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Teacher teacher = await _context.Teachers.FindAsync(id);
            _context.Students.Load();
            _context.Groups.Load();
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
