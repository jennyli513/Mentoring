using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mentoring.Models;

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
             m.subjectList = new List<CheckBox_Subject>();
            var subject = from v in _context.subject
                              select v;

            foreach (var s in subject)
            {
                m.subjectList.Add(new CheckBox_Subject { Text = s.title, Value = s.subjectId, IsChecked = false });
            }

            m.weekdayList = new List<CheckBox_Weekdays>();
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Monday", Value = 1, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Tuesday", Value = 2, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Wednesday", Value = 3, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Thursday", Value = 4, IsChecked = false });
            m.weekdayList.Add(new CheckBox_Weekdays { Text = "Friday", Value = 5, IsChecked = false });
            return View(m);
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mentorId,firstName,lastName,studentNumber,email,availableDay,availableTime,subjectId")] Mentor mentor)
        {
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
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("mentorId,firstName,lastName,studentNumber,email,availableDay,availableTime,subjectId")] Mentor mentor)
        {
            if (id != mentor.mentorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentor);
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
    }
}
