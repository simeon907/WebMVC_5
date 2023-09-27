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
    public class StudentController : Controller
    {
        private UniversityContext _context = new UniversityContext();

        // GET: Student
        public async Task<ActionResult> Index()
        {
            var students = _context.Students.Include(s => s.StudentCard);
            return View(await students.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.Groups = new SelectList(_context.Groups, "Id", "GroupName");

            ViewBag.Subjects = _context.Subjects.ToList();

            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,BirthDate,Email,Grant,PhotoFile")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_context.StudentCards, "Id", "Series", student.Id);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_context.StudentCards, "Id", "Series", student.Id);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,BirthDate,Email,Grant,PhotoFile")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(_context.StudentCards, "Id", "Series", student.Id);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await _context.Students.FindAsync(id);

            _context.StudentCards.Load();//чтобы студент удалился

            _context.Students.Remove(student);
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
