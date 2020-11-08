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
    public class CasualRolesController : Controller
    {
        private readonly bcxassignment01Context _context;

        public CasualRolesController(bcxassignment01Context context)
        {
            _context = context;
        }

        // GET: CasualRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasualRoles.ToListAsync());
        }

        // GET: CasualRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualRoles = await _context.CasualRoles
                .FirstOrDefaultAsync(m => m.CasualRoleId == id);
            if (casualRoles == null)
            {
                return NotFound();
            }

            return View(casualRoles);
        }

        // GET: CasualRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasualRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasualRoleId,CasualRole,HourlyRateInZar,IsEnabled")] CasualRoles casualRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casualRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casualRoles);
        }

        // GET: CasualRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualRoles = await _context.CasualRoles.FindAsync(id);
            if (casualRoles == null)
            {
                return NotFound();
            }
            return View(casualRoles);
        }

        // POST: CasualRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasualRoleId,CasualRole,HourlyRateInZar,IsEnabled")] CasualRoles casualRoles)
        {
            if (id != casualRoles.CasualRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casualRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasualRolesExists(casualRoles.CasualRoleId))
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
            return View(casualRoles);
        }

        // GET: CasualRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualRoles = await _context.CasualRoles
                .FirstOrDefaultAsync(m => m.CasualRoleId == id);
            if (casualRoles == null)
            {
                return NotFound();
            }

            return View(casualRoles);
        }

        // POST: CasualRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casualRoles = await _context.CasualRoles.FindAsync(id);
            _context.CasualRoles.Remove(casualRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasualRolesExists(int id)
        {
            return _context.CasualRoles.Any(e => e.CasualRoleId == id);
        }
    }
}
