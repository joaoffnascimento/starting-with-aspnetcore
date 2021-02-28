using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using starting_with_aspnetcore.Data;
using starting_with_aspnetcore.Models;

namespace starting_with_aspnetcore3._1.Controllers
{
    public class TechController : Controller
    {
        private readonly DbSetup _context;

        public TechController(DbSetup context)
        {
            _context = context;
        }

        // GET: Tech
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tech.ToListAsync());
        }

        // GET: Tech/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tech == null)
            {
                return NotFound();
            }

            return View(tech);
        }

        // GET: Tech/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tech/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,Id,CreatedAt,UpdatedAt")] Tech tech)
        {
            if (ModelState.IsValid)
            {
                tech.Id = Guid.NewGuid();
                _context.Add(tech);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tech);
        }

        // GET: Tech/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech.FindAsync(id);
            if (tech == null)
            {
                return NotFound();
            }
            return View(tech);
        }

        // POST: Tech/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("name,Id,CreatedAt,UpdatedAt")] Tech tech)
        {
            if (id != tech.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tech);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechExists(tech.Id))
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
            return View(tech);
        }

        // GET: Tech/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tech = await _context.Tech
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tech == null)
            {
                return NotFound();
            }

            return View(tech);
        }

        // POST: Tech/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tech = await _context.Tech.FindAsync(id);
            _context.Tech.Remove(tech);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechExists(Guid id)
        {
            return _context.Tech.Any(e => e.Id == id);
        }
    }
}
