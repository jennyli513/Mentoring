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
    public class MenteesController : Controller
    {
        private readonly MentorDataContext _context;

        public MenteesController(MentorDataContext context)
        {
            _context = context;
        }

        // GET: Mentees
        public async Task<IActionResult> Index()
        {
            return View(await _context.mentee.ToListAsync());
        }

        // GET: Mentees/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentee = await _context.mentee
                .FirstOrDefaultAsync(m => m.menteeId == id);
            if (mentee == null)
            {
                return NotFound();
            }

            return View(mentee);
        }

        // GET: Mentees/Create
        public IActionResult Create()
        {
            Mentee m = new Mentee();
            
            return View(m);
        }

        // POST: Mentees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("menteeId,firstName,lastName,studentNumber,email,request,subjectId")] Mentee mentee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mentee);
        }


       

        //private void BindSubjectDropDown()
        //{
        //    throw new NotImplementedException();
        //}


















        // GET: Mentees/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentee = await _context.mentee.FindAsync(id);
            if (mentee == null)
            {
                return NotFound();
            }
            return View(mentee);
        }

        // POST: Mentees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("menteeId,firstName,lastName,studentNumber,email,request,subjectId")] Mentee mentee)
        {
            if (id != mentee.menteeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenteeExists(mentee.menteeId))
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
            return View(mentee);
        }

        // GET: Mentees/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentee = await _context.mentee
                .FirstOrDefaultAsync(m => m.menteeId == id);
            if (mentee == null)
            {
                return NotFound();
            }

            return View(mentee);


        }




        [HttpGet]
        public IActionResult SearchMentee(string searchString)
        {
            List<Mentee> mList = new List<Mentee>();
            var mentee = from m in _context.mentee select m;
            foreach (var m in mentee)
            {
                mList.Add(m);
            }
            //BindSubjectDropDown();

            if (!String.IsNullOrEmpty(searchString))
            {
                mList = mList.Where(m => m.firstName.Contains(searchString)
                                    || m.lastName.Contains(searchString)).ToList();
            }
            //if (!String.IsNullOrEmpty(searchSubject))
            //{
            //    mList = mList.Where(m => m.subjectId.Contains(searchSubject)).ToList();
            //}

            return View(mList);
        }

        // POST: Mentees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mentee = await _context.mentee.FindAsync(id);
            _context.mentee.Remove(mentee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenteeExists(long id)
        {
            return _context.mentee.Any(e => e.menteeId == id);
        }
    }
}
