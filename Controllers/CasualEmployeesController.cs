using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BCX_Assessment_01.EF;
using Microsoft.AspNetCore.Http;

namespace BCX_Assessment_01.Controllers
{
    public class CasualEmployeesController : Controller
    {
        private readonly bcxassignment01Context _context;

        public CasualEmployeesController(bcxassignment01Context context)
        {
            _context = context;
        }

        // GET: CasualEmployees
        public async Task<IActionResult> Index()
        {
            var bcxassignment01Context = _context.CasualEmployees.Include(c => c.CasualRole);
            return View(await bcxassignment01Context.ToListAsync());
        }

        // GET: CasualEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualEmployees = await _context.CasualEmployees
                .Include(c => c.CasualRole)
                .FirstOrDefaultAsync(m => m.CasualEmployeeId == id);
            if (casualEmployees == null)
            {
                return NotFound();
            }

            return View(casualEmployees);
        }

        // GET: CasualEmployees/Create
        public IActionResult Create()
        {
            ViewData["CasualRoleId"] = new SelectList(_context.CasualRoles, "CasualRoleId", "CasualRole");
            return View();
        }

        // POST: CasualEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasualEmployeeId,CasualRoleId,Name,Surname,Email,CurrentHourlyRateInZar,IsEnabled")] CasualEmployees casualEmployees, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    if (image.Length > 0)
                    {

                        byte[] p1 = null;
                        using (var fs1 = image.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }

                        casualEmployees.ProfilePicture = p1;

                    }
                }

                var role = _context.CasualRoles.FirstOrDefault(x => x.CasualRoleId == casualEmployees.CasualRoleId);
                casualEmployees.CurrentHourlyRateInZar = role.HourlyRateInZar;
                _context.Add(casualEmployees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CasualRoleId"] = new SelectList(_context.CasualRoles, "CasualRoleId", "CasualRole", casualEmployees.CasualRoleId);
            return View(casualEmployees);
        }

        // GET: CasualEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualEmployees = await _context.CasualEmployees.FindAsync(id);
            if (casualEmployees == null)
            {
                return NotFound();
            }
            ViewData["CasualRoleId"] = new SelectList(_context.CasualRoles, "CasualRoleId", "CasualRole", casualEmployees.CasualRoleId);
            return View(casualEmployees);
        }

        // POST: CasualEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasualEmployeeId,CasualRoleId,Name,Surname,Email,ProfilePicture,CurrentHourlyRateInZar,IsEnabled")] CasualEmployees casualEmployees, IFormFile image)
        {
            if (id != casualEmployees.CasualEmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        if (image.Length > 0)
                        {

                            byte[] p1 = null;
                            using (var fs1 = image.OpenReadStream())
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }

                            casualEmployees.ProfilePicture = p1;

                        }
                    }
                    _context.Update(casualEmployees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasualEmployeesExists(casualEmployees.CasualEmployeeId))
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
            ViewData["CasualRoleId"] = new SelectList(_context.CasualRoles, "CasualRoleId", "CasualRole", casualEmployees.CasualRoleId);
            return View(casualEmployees);
        }

        // GET: CasualEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casualEmployees = await _context.CasualEmployees
                .Include(c => c.CasualRole)
                .FirstOrDefaultAsync(m => m.CasualEmployeeId == id);
            if (casualEmployees == null)
            {
                return NotFound();
            }

            return View(casualEmployees);
        }

        // POST: CasualEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casualEmployees = await _context.CasualEmployees.FindAsync(id);
            _context.CasualEmployees.Remove(casualEmployees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasualEmployeesExists(int id)
        {
            return _context.CasualEmployees.Any(e => e.CasualEmployeeId == id);
        }
    }
}
