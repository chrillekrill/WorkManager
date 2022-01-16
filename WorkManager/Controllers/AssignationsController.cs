#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkManager.Models;

namespace WorkManager.Controllers
{
    public class AssignationsController : Controller
    {
        private readonly AssignmentManageDBContext _context;

        public AssignationsController(AssignmentManageDBContext context)
        {
            _context = context;
        }

        // GET: Assignations
        public async Task<IActionResult> Index()
        {
            var assignmentManageDBContext = _context.Assignations.Include(a => a.Assignment).Include(a => a.Programmer);
            return View(await assignmentManageDBContext.ToListAsync());
        }

        // GET: Assignations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignation = await _context.Assignations
                .Include(a => a.Assignment)
                .Include(a => a.Programmer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignation == null)
            {
                return NotFound();
            }

            return View(assignation);
        }

        // GET: Assignations/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id");
            ViewData["ProgrammerId"] = new SelectList(_context.Programmers, nameof(Programmer.Id), nameof(Programmer.FullName));
            return View();
        }

        // POST: Assignations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgrammerId,AssignmentId")] Assignation assignation, long id)
        {
            if (!ModelState.IsValid)
            {
                assignation.AssignmentId = id;
                _context.Add(assignation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Assignments");
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id", assignation.AssignmentId);
            ViewData["ProgrammerId"] = new SelectList(_context.Programmers, "Id", "Id", assignation.ProgrammerId);
            return View(assignation);
        }

        // GET: Assignations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignation = await _context.Assignations.FindAsync(id);
            if (assignation == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id", assignation.AssignmentId);
            ViewData["ProgrammerId"] = new SelectList(_context.Programmers, "Id", "Id", assignation.ProgrammerId);
            return View(assignation);
        }

        // POST: Assignations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ProgrammerId,AssignmentId")] Assignation assignation)
        {
            if (id != assignation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignationExists(assignation.Id))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Id", assignation.AssignmentId);
            ViewData["ProgrammerId"] = new SelectList(_context.Programmers, "Id", "Id", assignation.ProgrammerId);
            return View(assignation);
        }

        // GET: Assignations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignation = await _context.Assignations
                .Include(a => a.Assignment)
                .Include(a => a.Programmer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignation == null)
            {
                return NotFound();
            }

            return View(assignation);
        }

        // POST: Assignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var assignation = await _context.Assignations.FindAsync(id);
            _context.Assignations.Remove(assignation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignationExists(long id)
        {
            return _context.Assignations.Any(e => e.Id == id);
        }
    }
}
