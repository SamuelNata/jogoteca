using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jogoteca.DbContexts;
using Jogoteca.Models.Entities;

namespace Jogoteca.Web.Controllers
{
    public class BorrowingController : Controller
    {
        private readonly JogotecaDbContext _context;

        public BorrowingController(JogotecaDbContext context)
        {
            _context = context;
        }

        // GET: Borrowing
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameBorrowings.ToListAsync());
        }

        // GET: Borrowing/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameBorrowing = await _context.GameBorrowings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameBorrowing == null)
            {
                return NotFound();
            }

            return View(gameBorrowing);
        }

        // GET: Borrowing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Borrowing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartDate,PredictedEndDate,RealEndDate,Id")] GameBorrowing gameBorrowing)
        {
            if (ModelState.IsValid)
            {
                gameBorrowing.Id = Guid.NewGuid();
                _context.Add(gameBorrowing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameBorrowing);
        }

        // GET: Borrowing/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameBorrowing = await _context.GameBorrowings.FindAsync(id);
            if (gameBorrowing == null)
            {
                return NotFound();
            }
            return View(gameBorrowing);
        }

        // POST: Borrowing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StartDate,PredictedEndDate,RealEndDate,Id")] GameBorrowing gameBorrowing)
        {
            if (id != gameBorrowing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameBorrowing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameBorrowingExists(gameBorrowing.Id))
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
            return View(gameBorrowing);
        }

        // GET: Borrowing/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameBorrowing = await _context.GameBorrowings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameBorrowing == null)
            {
                return NotFound();
            }

            return View(gameBorrowing);
        }

        // POST: Borrowing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var gameBorrowing = await _context.GameBorrowings.FindAsync(id);
            _context.GameBorrowings.Remove(gameBorrowing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameBorrowingExists(Guid id)
        {
            return _context.GameBorrowings.Any(e => e.Id == id);
        }
    }
}
