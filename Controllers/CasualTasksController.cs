using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BCX_Assessment_01.EF;

namespace BCX_Assessment_01.Controllers
{
    public class CasualTasksController : Controller
    {
        private readonly bcxassignment01Context _context;

        public CasualTasksController(bcxassignment01Context context)
        {
            _context = context;
        }

        // GET: CasualTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasualTasks.ToListAsync());
        }

        // GET: CasualTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualTasks = await _context.CasualTasks
                .FirstOrDefaultAsync(m => m.CasualTaskId == id);
            if (casualTasks == null)
            {
                return NotFound();
            }

            return View(casualTasks);
        }

        // GET: CasualTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasualTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasualTaskId,CasualTask,TimeEstiamteInHours,DateStarted,DateCompleted,IsEnabled")] CasualTasks casualTasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casualTasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casualTasks);
        }

        // GET: CasualTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualTasks = await _context.CasualTasks.FindAsync(id);
            if (casualTasks == null)
            {
                return NotFound();
            }
            return View(casualTasks);
        }

        // POST: CasualTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasualTaskId,CasualTask,TimeEstiamteInHours,DateStarted,DateCompleted,IsEnabled")] CasualTasks casualTasks)
        {
            if (id != casualTasks.CasualTaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casualTasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasualTasksExists(casualTasks.CasualTaskId))
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
            return View(casualTasks);
        }

        // GET: CasualTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualTasks = await _context.CasualTasks
                .FirstOrDefaultAsync(m => m.CasualTaskId == id);
            if (casualTasks == null)
            {
                return NotFound();
            }

            return View(casualTasks);
        }

        // POST: CasualTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casualTasks = await _context.CasualTasks.FindAsync(id);
            _context.CasualTasks.Remove(casualTasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasualTasksExists(int id)
        {
            return _context.CasualTasks.Any(e => e.CasualTaskId == id);
        }
    }
}
