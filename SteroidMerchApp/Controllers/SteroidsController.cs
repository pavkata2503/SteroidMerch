using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SteroidMerchApp.Data;
using SteroidMerchApp.Models;

namespace SteroidMerchApp.Controllers
{
    public class SteroidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SteroidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Steroids
        public async Task<IActionResult> Index()
        {
            return View(await _context.Steroid.ToListAsync());
        }

        // GET: Steroids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steroid = await _context.Steroid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (steroid == null)
            {
                return NotFound();
            }

            return View(steroid);
        }

        // GET: Steroids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Steroids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,URL,Name,Description,Price,Category,Status")] Steroid steroid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(steroid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(steroid);
        }

        // GET: Steroids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steroid = await _context.Steroid.FindAsync(id);
            if (steroid == null)
            {
                return NotFound();
            }
            return View(steroid);
        }

        // POST: Steroids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,URL,Name,Description,Price,Category,Status")] Steroid steroid)
        {
            if (id != steroid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(steroid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SteroidExists(steroid.Id))
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
            return View(steroid);
        }

        // GET: Steroids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var steroid = await _context.Steroid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (steroid == null)
            {
                return NotFound();
            }

            return View(steroid);
        }

        // POST: Steroids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var steroid = await _context.Steroid.FindAsync(id);
            if (steroid != null)
            {
                _context.Steroid.Remove(steroid);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SteroidExists(int id)
        {
            return _context.Steroid.Any(e => e.Id == id);
        }
    }
}
