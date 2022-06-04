using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mentoring.Models;
using System.Text;

namespace Mentoring.Controllers
{
    public class MentorsController : Controller
    {
        private readonly MentorDataContext _context;

      
        public MentorsController(MentorDataContext context)
        {
            _context = context;
        }

        // GET: Mentors
        public async Task<IActionResult> Index()
        {
            return View(await _context.mentors.ToListAsync());
        }

        // GET: Mentors/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.mentors
                .FirstOrDefaultAsync(m => m.mentorId == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // GET: Mentors/Create
        public IActionResult Create()
        {
            Mentor m = new Mentor();
            fillSubjectList(m);
            fillWeekdaysList(m);


            return View(m);
        }
        private void fillSubjectList(Mentor m)
        {
            //Mentor m = new Mentor();
            m.subjectList = new List<CheckBox_Subject>();
            var subject = from v in _context.subject
                          select v;

            foreach (var s in subject)
            {
                m.subjectList.Add(new CheckBox_Subject { Text = s.title, Value = s.subjectId, IsChecked = false });
            }
        }
        private void fillWeekdaysList(Mentor m)
        {
            //Mentor m = new Mentor();
            m.weekdayList = new List<CheckBox_Weekdays>();
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Monday", Value = 1, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Tuesday", Value = 2, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Wednesday", Value = 3, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Thursday", Value = 4, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Friday", Value = 5, IsChecked = false });
        }
        // POST: Mentors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mentor mentor)
        {
          //StringBuilder sb = new StringBuilder();
          foreach (var item in mentor.weekdayList)
            {
                if (item.IsChecked)
                    mentor.availableDay += item.Text + ", " ;
            }

          foreach (var item in mentor.subjectList)
            {
                if (item.IsChecked)
                    mentor.subject += item.Text + ", ";
            }
            if (ModelState.IsValid)
            {     
                _context.Add(mentor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mentor);
        }

        // GET: Mentors/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.mentors.FindAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }
            mentor.subjectList = new List<CheckBox_Subject>();
            var subject = from v in _context.subject
                          select v;

            foreach (var s in subject)
            {
                mentor.subjectList.Add(new CheckBox_Subject { Text = s.title, Value = s.subjectId, IsChecked = false });
            }



            fillWeekdaysList(mentor);

            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Mentor mentor)
        {
            
            //fillSubjectList(mentor);
            //fillWeekdaysList(mentor);

            foreach (var item in mentor.weekdayList)
            {
                if (item.IsChecked)
                    mentor.availableDay += item.Text + ", ";
            }

            foreach (var item in mentor.subjectList)
            {
                if (item.IsChecked)
                    mentor.subject += item.Text + ", ";
            }

            //if (id != mentor.mentorId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(mentor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorExists(mentor.mentorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mentor);
        }

        // GET: Mentors/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.mentors
                .FirstOrDefaultAsync(m => m.mentorId == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mentor = await _context.mentors.FindAsync(id);
            _context.mentors.Remove(mentor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorExists(long id)
        {
            return _context.mentors.Any(e => e.mentorId == id);
        }


        [HttpGet]
        public IActionResult SearchMentor(string searchString, string searchSubject)
        {
            List<Mentor> mList = new List<Mentor>();
            var mentor = from m in _context.mentors
                         select m;
            foreach (var m in mentor)
            {
                mList.Add(m);
            }
            BindSubjectDropDown();

            if (!String.IsNullOrEmpty(searchString))
            {
                mList = mList.Where(m => m.firstName.Contains(searchString)
                                    || m.lastName.Contains(searchString)).ToList();
            }
            if(!String.IsNullOrEmpty(searchSubject))
            {
                mList = mList.Where(m=>m.subject.Contains(searchSubject)).ToList();
            }
           
            return View(mList);
        }

        private void BindSubjectDropDown()
        {
            var subject = from s in _context.subject
                          select s;
            List<SelectListItem> subjectList = new List<SelectListItem>();
            foreach(var s in subject)
            {
                subjectList.Add(new SelectListItem { Text = s.title, Value = s.title.ToString() }); 
            }
            TempData["Subjects"] = subjectList;
        }
    }
}
