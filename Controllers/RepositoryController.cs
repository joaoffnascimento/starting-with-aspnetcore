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
    public class RepositoryController : Controller
    {
        private readonly DbSetup _context;

        public RepositoryController(DbSetup context)
        {
            _context = context;
        }

        // GET: Repository
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repository.ToListAsync());
        }

        // GET: Repository/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repository = await _context.Repository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repository == null)
            {
                return NotFound();
            }

            return View(repository);
        }

        // GET: Repository/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repository/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Stars,About,Id")] Repository repository)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repository);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repository);
        }

        // GET: Repository/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repository = await _context.Repository.FindAsync(id);
            if (repository == null)
            {
                return NotFound();
            }
            return View(repository);
        }

        // POST: Repository/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Stars,About,Id,createdAt,updatedAt")] Repository repository)
        {
            if (id != repository.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repository);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepositoryExists(repository.Id))
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
            return View(repository);
        }

        // GET: Repository/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repository = await _context.Repository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repository == null)
            {
                return NotFound();
            }

            return View(repository);
        }

        // POST: Repository/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var repository = await _context.Repository.FindAsync(id);
            _context.Repository.Remove(repository);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepositoryExists(Guid id)
        {
            return _context.Repository.Any(e => e.Id == id);
        }
    }
}
