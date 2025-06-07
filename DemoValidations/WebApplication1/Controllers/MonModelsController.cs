using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MonModelsController : Controller
    {
        private readonly WebApplication1Context _context;

        public MonModelsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: MonModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MonModel.ToListAsync());
        }

        // GET: MonModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monModel = await _context.MonModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monModel == null)
            {
                return NotFound();
            }

            return View(monModel);
        }

        // GET: MonModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valeur,Requis,Optionnel")] MonModel monModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monModel);
        }

        // GET: MonModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monModel = await _context.MonModel.FindAsync(id);
            if (monModel == null)
            {
                return NotFound();
            }
            return View(monModel);
        }

        // POST: MonModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valeur,Requis,Optionnel")] MonModel monModel)
        {
            if (id != monModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonModelExists(monModel.Id))
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
            return View(monModel);
        }

        // GET: MonModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monModel = await _context.MonModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monModel == null)
            {
                return NotFound();
            }

            return View(monModel);
        }

        // POST: MonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monModel = await _context.MonModel.FindAsync(id);
            if (monModel != null)
            {
                _context.MonModel.Remove(monModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonModelExists(int id)
        {
            return _context.MonModel.Any(e => e.Id == id);
        }
    }
}
